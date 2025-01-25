using System;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
   [SerializeField] private float damage;
   [SerializeField] protected BulletMove bulletMove;

   private void OnEnable()
   {
      SetConfig();
   }

   protected abstract void SetConfig();
}