using System;
using UnityEngine;

public class Samurai : MonoBehaviour
{
   private Animator _animator;

   [SerializeField]  private float coolDownTime = 3f;
   private float timeBetweenAtk;
   private bool _canAttack = true;
   private bool _canSecondAttack;

   private void Start()
   {
      _animator = GetComponent<Animator>();
   }

   private void Update()
   {
      SamuraiAttack();
      AttackCoolDown();
   }

   private void AttackCoolDown()
   {
      if (timeBetweenAtk > 0)
      {
         timeBetweenAtk -= Time.deltaTime;
         if (timeBetweenAtk <= 0)
         {
            _canAttack = true;
            _canSecondAttack = true;
         }
      }
   }

   private void SamuraiAttack()
   {
      if (Input.GetMouseButtonDown(0) && _canAttack)
      {
         _animator.SetTrigger("Attack");
         _animator.SetInteger("ComboCount",0);
         timeBetweenAtk = coolDownTime;
         _canAttack = false;
         _canSecondAttack = true;

      }
      if (Input.GetMouseButtonDown(0) && timeBetweenAtk< coolDownTime - 0.4f && timeBetweenAtk>= 1.5f && _canSecondAttack)
      {
         _animator.SetTrigger("Attack");
         _animator.SetInteger("ComboCount",1);
         _canSecondAttack = false;
      }
   }
}
