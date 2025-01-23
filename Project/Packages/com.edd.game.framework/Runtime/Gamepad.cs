using UnityEngine;
using UnityEngine.InputSystem;

namespace EDD
{
    [RequireComponent(typeof(PlayerInput))]
    public class Gamepad : MonoBehaviour
    {
        public void OnMove(InputValue inputValue)
        {
            var dir = inputValue.Get<Vector2>();
            if (dir == Vector2.zero)
                return;
            
            var degree = Quaternion.FromToRotation(Vector3.up, dir).eulerAngles.z;
            EventMessenger.Broadcast((int)EEventType.GamepadOnMove, new GamepadMoveEventArg(dir, degree));
        }
    }

    public class GamepadMoveEventArg : EventArg
    {
        public Vector2 Dir { get; private set; }
        public float Degree { get; private set; }

        public GamepadMoveEventArg(Vector2 dir, float degree)
        {
            Dir = dir;
            Degree = degree;
        }

        public override string ToString()
        {
            return $"{nameof(Dir)}: {Dir}, {nameof(Degree)}: {Degree}";
        }
    }
}
