using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBelt : MonoBehaviour
{

    [SerializeField]
    private GameObject Asteroid;

    [SerializeField]
    private float Radius;

    [SerializeField]
    private float stepVertical;

    [SerializeField]
    private float stepHorizontal;

    [SerializeField]
    private float height;
    

    void Awake()
    {
        float phi = 0f;
        float theta = 15f;
        Quaternion rot = Quaternion.identity;
        float x = 0f;
        float y = 0f;
        float z = 0f;
        Vector3 aux = Vector3.zero;

        while(phi<360)
        {
            x = Mathf.Cos(phi*Mathf.Deg2Rad);
            z = Mathf.Sin(phi*Mathf.Deg2Rad);

            while(theta<180)
            {
                aux = Mathf.Sin(theta*Mathf.Deg2Rad)*(Vector3.right*x + Vector3.forward*z);
                y = Mathf.Cos(theta*Mathf.Deg2Rad);

                aux.y = y;
                
                var newAsteroid = Instantiate(Asteroid, Radius*aux, rot);
            
                newAsteroid.transform.parent = gameObject.transform;
                theta += stepVertical;
            }
            theta = 15f;
            phi+=stepHorizontal;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
