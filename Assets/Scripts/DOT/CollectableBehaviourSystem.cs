using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;


public class MoveSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float elapsedTime = (float)Time.ElapsedTime;
        Entities.ForEach((ref Rotation rot, ref CollectedComponent collectable) =>
        {
            collectable.rotationAngle = collectable.rotationAngle+0.02f;
            float3 targetDirection = new float3((float)Math.Sin(collectable.rotationAngle), 0, (float)Math.Cos(collectable.rotationAngle));
            rot.Value = quaternion.LookRotationSafe(targetDirection, Vector3.right);
        }).Run();
    }
}
