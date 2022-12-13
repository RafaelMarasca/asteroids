using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInsideMinimap : MonoBehaviour
{

    private GameObject miniMapCam;

    [SerializeField]
    private float miniMapSize;


    private Transform obj;
    

    private Vector3 camPos;


    private Vector3 aux;

    private float dist;


    // Start is called before the first frame update
    void Start()
    {
        obj = transform.parent.gameObject.transform;
        miniMapCam = GameObject.Find("Minimap/MiniMapCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if(obj != null)
        {
            camPos = miniMapCam.transform.position;
            camPos.y = 0f;

            aux = obj.transform.position;

            aux.y = 0f;

            dist = Vector3.Distance(aux,camPos);

            if(dist>miniMapSize)
            {

                aux = camPos + (obj.position - camPos)*miniMapSize/dist;
                aux.y = obj.position.y;
                transform.position = aux;
            }else
            {
                transform.position = obj.position;
            }
        }
    }
}
