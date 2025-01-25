using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class BulletMove: MonoBehaviour
{
   [SerializeField] protected float speed;
   
   protected Rigidbody2D Rigid { get; private set; }
   protected abstract void Move();

   private void Awake()
   {
      Rigid = GetComponent<Rigidbody2D>();
   }

   private void FixedUpdate()
   {
      Move();
   }
}
