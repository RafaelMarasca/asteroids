using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapFollow : MonoBehaviour
{

    [SerializeField]
    private Transform target;
    private float initRotation;

    // Start is called before the first frame update
    void Start()
    {
       // transform.rotation = Quaternion.Euler(90, target.rotation.eulerAngles.y, 0);  

    }

    // Update is called once per frame
    void Update()
    {
        if(target)
        {
            transform.rotation = Quaternion.Euler(90, target.rotation.eulerAngles.y, 0);    
            transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);
        }
       
    }
}
