using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AsteroidHitBehavior: TargetHitBehavior
{

    [SerializeField]
    private GameObject fracturedObject;

    private Spawner spawner;

    private Vector3 initPosition;
    private Quaternion initRotation;

    private Spawner.Itens asteroidType;


    public void Start()
    {
        initPosition = transform.position;
     
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
     
        if(tag == "commomAsteroid")
        {
            asteroidType = Spawner.Itens.commomAsteroid;

        }else if(tag == "iceAsteroid")
        {
            asteroidType = Spawner.Itens.iceAsteroid;

        }else if(tag == "lavaAsteroid")
        {
            asteroidType = Spawner.Itens.lavaAsteroid;
        }
    }


    public override void Die()
    {
        GameObject fracObj = Instantiate(fracturedObject, transform.position, transform.rotation) as GameObject;
        fracObj.GetComponent<ExplosiveBehavior>().Explode();
        spawner.SpawnWithDelay(asteroidType, initPosition, Quaternion.identity, 5, transform.parent);
        Destroy(gameObject);
    }



}
