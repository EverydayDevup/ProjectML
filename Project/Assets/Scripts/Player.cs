using System;
using EDD;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector2 dir;
    private Action<EventArg> onMove;
    private Action<EventArg> onMoveRelease;
    private Rigidbody2D _rigidbody2D;
    private float _speed;
    
    private void Awake()
    {
        onMove = OnMove;
        EventMessenger.Register((int)EEventType.GamepadOnMove, onMove);

        onMoveRelease = OnMoveRelease;
        EventMessenger.Register((int)EEventType.GamepadOnRelease, onMoveRelease);
        
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnDestroy()
    {
        EventMessenger.Unregister((int)EEventType.GamepadOnMove, onMove);
    }
    
    private void OnMoveRelease(EventArg arg)
    {
        _speed = 0;
    }

    private void OnMove(EventArg arg)
    {
        if (arg is GamepadMoveEventArg moveArg)
        {
            dir = moveArg.Dir;
            _speed = speed;
        }
    }

    private void FixedUpdate()
    {
        var nextVec = dir * _speed * Time.fixedDeltaTime;
        _rigidbody2D.MovePosition(_rigidbody2D.position + nextVec);
    }
}
