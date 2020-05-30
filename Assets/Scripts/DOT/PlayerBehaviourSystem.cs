using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Specialized;

public class PlayerBehaviourSystem : SystemBase
{


    // Update is called once per frame
    protected override void OnUpdate()
    {
        Entities.ForEach((ref PlayerComponent player, ref Translation trans, ref Rotation rot) =>
        {

            player.rotationAngle = player.rotationAngle +Input.GetAxis("Horizontal") * player.speed;
            float3 targetDirection = new float3((float)Math.Sin(player.rotationAngle), 0, (float)Math.Cos(player.rotationAngle));
            rot.Value = quaternion.LookRotationSafe(targetDirection, Vector3.up);
            trans.Value = trans.Value+( targetDirection*player.speed * Input.GetAxis("Vertical"));
        }).Run();

    }
}
