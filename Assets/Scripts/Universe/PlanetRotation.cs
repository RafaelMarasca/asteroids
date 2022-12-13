using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{

    [SerializeField]
    private float rotationSpeed = 30f;

    [SerializeField]
    private float orbitSpeed = 30f;

    private GameObject sun;

    // Start is called before the first frame update
    void Start()
    {
        sun = GameObject.FindWithTag("sun");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(0,rotationSpeed*Time.deltaTime, 0); 

        if(sun != null)
        {
            gameObject.transform.RotateAround(sun.transform.position, Vector3.up, orbitSpeed*Time.deltaTime);
        }
    }
}
