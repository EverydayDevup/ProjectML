using System;
using EDD;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    private Action<EventMessengerArg> _onMove;
    
    private void Awake()
    {
        _onMove ??= OnMove;
        EventMessenger.Register((int)EEventType.GamepadMove, _onMove);
    }

    private void OnDestroy()
    {
        EventMessenger.Unregister((int)EEventType.GamepadMove, _onMove);
    }

    private void OnMove(EventMessengerArg arg)
    {
        if (arg is not GamepadEventMessenger gamepadEvent)
            return;
        
        transform.localRotation = Quaternion.Euler(0, 0, gamepadEvent.Degree);
    }
}
