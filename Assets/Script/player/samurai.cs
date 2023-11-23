
using System;
using UnityEngine;

public class Samurai : MonoBehaviour
{
   private Animator _animator;
   private bool _canAttack = true;
   private float _atkCd = 3f;
   private float _atkTimer;


   private void Start()
   {
      _animator = GetComponent<Animator>();
   }

   private void FixedUpdate()
   {
      if (Input.GetMouseButton(0) )
      {
         if (_canAttack)
         {
            _animator.SetTrigger("Attack");
            _atkTimer = _atkCd;
         }

      }

      if (_atkTimer > 0)
      {
         _canAttack = false;
         _atkTimer -= Time.deltaTime;
         if (_atkTimer<= 0)
         {
            _canAttack = true;
         }
      }
   }

   

}
