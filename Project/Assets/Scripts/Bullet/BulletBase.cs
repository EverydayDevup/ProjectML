using System;
using Unity.Profiling;
using UnityEngine;

public class BulletBase : Bullet
{
    protected override void SetConfig()
    {
        if (bulletMove is BulletLinearMove move)
        {
            move.SetDir(Game.Instance.player.Dir);
        }
    }
}
