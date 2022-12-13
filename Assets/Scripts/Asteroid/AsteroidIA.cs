using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidIA : MonoBehaviour
{
    
    [SerializeField]
    private float velocity = 200f;

    private Transform asteroid;
    private Rigidbody asteroidRB;
    private Transform playerTransform;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerTransform = other.transform;
        }
    }  

    void OnTriggerStay(Collider other)
    {
        if(playerTransform == null)
        {
            if(other.CompareTag("Player"))
            {
                playerTransform = other.transform;
            }
        }else
        {
            asteroidRB.velocity = velocity*(playerTransform.position - asteroidRB.position).normalized;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            asteroidRB.velocity = Vector3.zero;
            asteroidRB.angularVelocity = Vector3.zero;
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        asteroid = transform.parent;
        asteroidRB = asteroid.GetComponent<Rigidbody>();
    }
}
