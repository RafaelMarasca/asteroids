using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBehavior : MonoBehaviour
{

    [SerializeField]
    private Vector3 target;
    
    [SerializeField]
    private float speed = 600f;

    [SerializeField]
    private GameObject explosionPrefab;
 

    void Update()
    {
        float step = speed * Time.deltaTime;

        if(target!= null)
        {
            if(transform.position == target)
            {
                explode();
                return;
            }
            transform.position = Vector3.MoveTowards(transform.position, target,step);
        }
    }


    public void SetTarget(Vector3 newTarget)
    {
        target = newTarget;
    }


    void explode()
    {
        GameObject explosion = GameObject.Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(explosion,1f);
    }


}
