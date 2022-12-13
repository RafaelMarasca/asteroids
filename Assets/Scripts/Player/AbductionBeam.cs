using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent (typeof(LineRenderer))]
public class AbductionBeam : MonoBehaviour
{
    /*[SerializeField]
    private float range = 100f;


    [SerializeField]
    private GameObject beamPosition;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float AbductionDrain = 25f;

    [SerializeField]
    private float AbductRate = 2f;



    private TargetBehavior target;

    private LineRenderer beamLine;
    //private Transform muzzle;
    //private List<Transform> transList;

    private float inputAbduction = 0f;
    private float nextTimeToAbduct = 0f;


    
    void Awake()
    {

        beamLine = GetComponent<LineRenderer>();
        beamLine.enabled = false;

        /*transList = new List<Transform>();

        muzzle = gameObject.transform.Find("Muzzle"); 

        foreach(Transform child in muzzle)
        {
            transList.Add(child);
            Debug.Log(child.name);        
        }*//*

    }


    public void OnAbduct(InputAction.CallbackContext context)
    {
        inputAbduction = context.ReadValue<float>();
    }

    void Update()
    {
        if(inputAbduction > 0.5f)
        {
            if(Time.time > nextTimeToAbduct)
            {
                Abduct();
                beamLine.enabled = true;
                nextTimeToAbduct = Time.time + 1/AbductRate;
            }
           
        }else
        {
            beamLine.enabled = false;
            if(target != null)
            {
                target.ResetAbduction();
            }
        }
    }


    private void Abduct()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            beamLine.SetPosition(0, beamPosition.transform.position);
            beamLine.SetPosition(1, hit.point);

            target = hit.transform.GetComponent<TargetBehavior>();
           
            if(target != null)
            {
                target.OnAbduct(AbductionDrain);
            }
        }else
        {
            beamLine.SetPosition(0, beamPosition.transform.position);
            beamLine.SetPosition(1, beamPosition.transform.position + cam.transform.forward * range);
        }
    }*/
}
