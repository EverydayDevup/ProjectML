using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace EDD
{
    [RequireComponent(typeof(PlayerInput))]
    public class Gamepad : MonoBehaviour
    {
        public void OnMove(InputValue value)
        {
            var dir = value.Get<Vector2>();

            if (dir == Vector2.zero)
                return;
            
            var degree = Quaternion.FromToRotation(Vector3.up, dir).eulerAngles.z;
            EventMessenger.Broadcast((int)EEventType.GamepadMove, new GamepadEventMessenger(dir, degree));
        }
    }

    public class GamepadEventMessenger : EventMessengerArg
    {
        public Vector2 Direction { get; private set; }
        public float Degree { get; private set; }

        public GamepadEventMessenger(Vector2 dir, float degree)
        {
            Direction = dir;
            Degree = degree;
        }
    }
}
