using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotation : MonoBehaviour
{

    private float xRotation;
    private float yRotation;
    private float zRotation;

    private Transform p;

    // Start is called before the first frame update
    void Start()
    {
        p = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {   
        transform.rotation = Quaternion.Euler(90, p.eulerAngles.y, 0);
    }
}
