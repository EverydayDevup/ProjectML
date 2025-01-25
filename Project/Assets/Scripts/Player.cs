using System;
using Cysharp.Threading.Tasks;
using EDD;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector2 dir = Vector2.up;
    private Action<EventArg> onMove;
    private Action<EventArg> onMoveRelease;
    private Rigidbody2D _rigidbody2D;
    private float _speed;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    public Vector2 Dir => dir;
    
    private void Awake()
    {
        onMove = OnMove;
        EventMessenger.Register((int)EEventType.GamepadOnMove, onMove);

        onMoveRelease = OnMoveRelease;
        EventMessenger.Register((int)EEventType.GamepadOnRelease, onMoveRelease);
        
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        Attack().Forget();
    }

    private async UniTaskVoid Attack()
    {
        while (true)
        {
            await UniTask.Delay(200);
            _animator.SetTrigger("Attack");
        }
    }

    private void OnDestroy()
    {
        EventMessenger.Unregister((int)EEventType.GamepadOnMove, onMove);
    }
    
    private void OnMoveRelease(EventArg arg)
    {
        _speed = 0;
        _animator.SetBool("IsMove", false);
    }

    private void OnMove(EventArg arg)
    {
        if (arg is GamepadMoveEventArg moveArg)
        {
            dir = moveArg.Dir;
            _speed = speed;
            _animator.SetBool("IsMove", true);
            if (dir.x > 0)
                _spriteRenderer.flipX = true;
            else
                _spriteRenderer.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        var nextVec = dir * _speed * Time.fixedDeltaTime;
        _rigidbody2D.MovePosition(_rigidbody2D.position + nextVec);
    }
}
