using System;
using UnityEngine;

public class BulletLinearMove : BulletMove
{
    private Vector2 Dir { get; set; }

    private void OnEnable()
    {
        Rigid.position = Vector2.zero;
    }

    public void SetDir(Vector2 dir)
    {
        Dir = dir;
        
        var degree = Quaternion.FromToRotation(Vector3.up, dir).eulerAngles.z - 90;
        transform.rotation = Quaternion.Euler(0, 0, degree);
    }
    
    protected override void Move()
    {
        var nextVec = Dir * (speed * Time.fixedDeltaTime);
        Rigid.MovePosition(Rigid.position + nextVec);
    }
}
