using System;
using EDD;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    private Action<EventArg> _onMove;
    
    private void Awake()
    {
        _onMove ??= OnMove;
        EventMessenger.Register((int)EEventType.GamepadOnMove, _onMove);
    }

    private void OnDestroy()
    {
        EventMessenger.Unregister((int)EEventType.GamepadOnMove, _onMove);
    }

    private void OnMove(EventArg arg)
    {
        if (arg is not GamepadMoveEventArg gamepadEvent)
            return;
        
        transform.localRotation = Quaternion.Euler(0, 0, gamepadEvent.Degree);
    }
}
