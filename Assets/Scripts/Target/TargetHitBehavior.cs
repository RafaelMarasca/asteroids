using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(Rigidbody))]
public class TargetHitBehavior : MonoBehaviour
{

    [SerializeField]
    private float health = 100f;

    public void OnHit(float damage)
    {
        health -= damage;

        if(health <= 0f)
        {
            Die();
        }   
    }
   
    public virtual void Die()
    {        
        Destroy(gameObject);
    }
}
