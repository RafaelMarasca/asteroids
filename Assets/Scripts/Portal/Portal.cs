using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    [SerializeField]
    private string nextLevel;


    [SerializeField]
    private LevelChanger levelChanger;
    
    private GameObject player;

    void Awake()
    {
        player = GameObject.Find("Player");
    }

    private bool notCollision = true;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "PlayerPortal" && notCollision)
        {
            notCollision = false;
            Debug.Log(collider.name);
            
            player.GetComponent<PlayerMovement>().enabled = false;
            
            var rb = player.GetComponent<Rigidbody>();

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            
            levelChanger.FadeToLevel(nextLevel);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        notCollision = true;
    }
}
