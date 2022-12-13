using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniverseLimits : MonoBehaviour
{

    [SerializeField]
    private GameObject hitPrefab;

    private Rigidbody rb;

    private Vector3 aux;

    void OnCollisionEnter(Collision collision)
    {
        rb = collision.rigidbody;

        GameObject hit = GameObject.Instantiate(hitPrefab, rb.position, rb.rotation);
        Destroy(hit,1f);

    }
}
