using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollisionBehavior : MonoBehaviour
{

    
    private AsteroidHitBehavior asteroid;
    private PlayerDamage player;

    [SerializeField]
    private float damage = 100f;

    private bool hitted;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player") && hitted == false) 
        {
            hitted = true;
            asteroid.Die();

            if(!player)
                player = collision.gameObject.GetComponent<PlayerDamage>();
        
            Debug.Log(collision.gameObject.name);

            player.OnHit(damage);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        hitted = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        asteroid = GetComponent<AsteroidHitBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
