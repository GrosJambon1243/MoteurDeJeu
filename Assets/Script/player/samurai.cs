
using System;
using UnityEngine;

public class Samurai : MonoBehaviour
{
   private Animator _animator;
   private bool _canAttack = true;
   private float _atkCd = 3f;
   private float _atkTimer;
   private int combo;
   private float comboTimeWindow;
   


   private void Start()
   {
      _animator = GetComponent<Animator>();
   }

   private void Update()
   {
      if (Input.GetMouseButtonDown(0) )
      {
         if (_canAttack)
         {
            _animator.SetInteger("ComboCount", combo);
            _animator.SetTrigger("Attack");
            combo++;
            combo %= 2;
            comboTimeWindow = 0.5f;
           // _atkTimer = _atkCd;
         }

         if (comboTimeWindow>0 )
         {
            comboTimeWindow -= Time.deltaTime;
            if (comboTimeWindow <= 0)
            {
               combo = 0;
            }
         }

      }
     // KatanaAttack();
   }

   public void KatanaAttack()
   {
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
