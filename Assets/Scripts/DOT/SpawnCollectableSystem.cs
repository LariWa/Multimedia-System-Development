using System.Diagnostics;
using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnCollectableSystem : SystemBase
{
    BeginInitializationEntityCommandBufferSystem m_EntityCommandBufferSystem;
    protected override void OnCreate()
    {
        // Cache the BeginInitializationEntityCommandBufferSystem in a field, so we don't have to create it every frame
        m_EntityCommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();       

    }

    protected override void OnUpdate()
    {
        var commandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer().ToConcurrent();
        var randomArray = World.GetExistingSystem<RandomSystem>().RandomArray;

        Entities
            .WithNativeDisableParallelForRestriction(randomArray)
            .ForEach((Entity entity,int nativeThreadIndex, int entityInQueryIndex, in SpawnCollectableComponent collectables) =>
            {

                for (int i = 1; i <= collectables.number; i++)
                {
                    var random = randomArray[nativeThreadIndex];
                    Entity entityInstance = commandBuffer.Instantiate(entityInQueryIndex, collectables.CollectablePrefab);
                    float3 position = new float3(random.NextInt(-5, 5), 0,random.NextInt(-5, 5));                 
                    commandBuffer.AddComponent(entityInQueryIndex, entityInstance, new Translation { Value = position });
                    commandBuffer.AddComponent(entityInQueryIndex, entityInstance, new CollectedComponent { isCollected = false, rotationAngle=0f});
                    randomArray[nativeThreadIndex] = random;
                }

                commandBuffer.DestroyEntity(entityInQueryIndex, entity);
            }).ScheduleParallel();;

        m_EntityCommandBufferSystem.AddJobHandleForProducer(Dependency);
    }
  
}

