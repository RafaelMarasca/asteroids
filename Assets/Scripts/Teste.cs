using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teste : MonoBehaviour
{

    private Rigidbody g;

    // Start is called before the first frame update
    void Start()
    {
        g = GetComponent<Rigidbody>();
        g.velocity = new Vector3(-1000, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        g.velocity = new Vector3(-100, 0, 0);
    }
}
