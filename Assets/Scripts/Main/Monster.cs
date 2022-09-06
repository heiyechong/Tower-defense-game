using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
public class Monster : MonoBehaviour
{
    
   public float Blood ;

    private NavMeshAgent navMeshAgent;

    public  Action<Monster> deadEvent;

    private Animator animator;

    private float monsterValue;
    private void Awake()
    {
       navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    public void SetMonster(float monsterblood,float Speed,Transform target,float monsterValue)
    {
        Blood = monsterblood;
        navMeshAgent.speed = Speed;
        navMeshAgent.SetDestination(target.position);
        this.monsterValue  = monsterValue; 
    }

    public void Damage(float damage)
    {
        Blood -= damage;
        if (Blood <= 0)
        {
            ButtonClick.buttonClick.currentMoney += monsterValue;
            ButtonClick.buttonClick.UpdateMoney();
            animator.SetTrigger("IsDead");
            navMeshAgent.isStopped = true;
            deadEvent.Invoke(this);
            Destroy(gameObject, 0.9f);

        }
        if (Blood >0)
        {
            animator.SetTrigger("IsDamage");
            
        }
    }
}
