using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbductBehavior : MonoBehaviour
{
    [SerializeField]
    private float range = 100f;

    [SerializeField]
    private GameObject laserBeam;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private float abductionDrain = 10f;

    [SerializeField]
    private float abductRate = 2f;

    private float nextTimeToAbduct = 0f;
    private float inputAbduction = 0f;
    private LineRenderer beamLine;
    private ParticleSystem particles;


    public static void EnableEmission(ParticleSystem particles, bool state)
    {
        ParticleSystem.EmissionModule em = particles.emission;
        em.enabled = state;
    }

    void Awake()
    {
        beamLine = laserBeam.GetComponentInChildren<LineRenderer>();
        particles = laserBeam.GetComponentInChildren<ParticleSystem>();

        if(beamLine == null || particles == null)
        {
            Debug.LogError("Falha de Instancia de Componentes!");
        }
        
        beamLine.enabled = false;
        EnableEmission(particles,false);
        
    }

    public void OnAbduct(InputAction.CallbackContext context)
    {
        inputAbduction = context.ReadValue<float>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inputAbduction > 0.5f)
        {
            beamLine.enabled = true;
            AbductHandler();
           
        }else
        {
            beamLine.enabled = false;
            EnableEmission(particles,false);
        }   
    }


    private void AbductHandler()
    {
        RaycastHit hit;
        TargetAbductBehavior target;

        beamLine.SetPosition(0, laserBeam.transform.position);

        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            EnableEmission(particles,true);
            
            beamLine.SetPosition(1, hit.point);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);

            target = hit.transform.GetComponent<TargetAbductBehavior>();
           
            if(Time.time > nextTimeToAbduct && target != null)
            {
                
                target.OnAbduct(abductionDrain);
                nextTimeToAbduct = Time.time + 1/abductRate;
            }

        }else
        {
            
            beamLine.SetPosition(1, cam.transform.position + (cam.transform.forward * range));
                
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }
    }


}
