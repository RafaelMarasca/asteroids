using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBehavior : MonoBehaviour
{

    [SerializeField]
    private float explosionForce = 2000f;

    [SerializeField]
    private float explosionRadius = 2f;

    [SerializeField]
    private GameObject explosionPrefab;

    public void Explode()
    {
        foreach(Transform child in transform)
        {
            Rigidbody rb = child.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(explosionForce, rb.transform.position, explosionRadius);
            }
        }

        GameObject explosion = GameObject.Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(explosion,2f);

        Destroy(gameObject,5f);
    }
}
