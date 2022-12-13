using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShootBehavior: MonoBehaviour
{

    [Header("Shoot Settings")]

    [SerializeField]
    private float damage = 10f;

    [SerializeField]
    private float range = 1000f;

    [SerializeField]
    private float fireRate = 10f;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private GameObject laserPrefab;


    private float fireInput = 0f;
    private float nextTimeToFire = 0f;

    private Transform muzzle;
    private List<Transform> transList;

    public void OnFire(InputAction.CallbackContext context)
    {
        fireInput = context.ReadValue<float>();
    }

    void Start()
    {
        transList = new List<Transform>();

        muzzle = gameObject.transform.Find("Muzzle"); 

        foreach(Transform child in muzzle)
        {
            transList.Add(child);     
        }
    }


    void Update()
    {
        if(fireInput>0.5f && Time.time > nextTimeToFire)
        {
            Shoot(); 
            nextTimeToFire = Time.time + 1f/fireRate;
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            foreach(Transform obj in transList)
            {
                GameObject laser = GameObject.Instantiate(laserPrefab, obj.position, obj.rotation) as GameObject;
                laser.GetComponent<ShotBehavior>().SetTarget(hit.point);
                GameObject.Destroy(laser,1f);
            }


            TargetHitBehavior target = hit.transform.GetComponent<TargetHitBehavior>();
           
            if(target != null)
            {
                target.OnHit(damage);
            }
        }else
        {
            foreach(Transform obj in transList)
            {
                GameObject laser = GameObject.Instantiate(laserPrefab, obj.position, obj.rotation) as GameObject;
                laser.GetComponent<ShotBehavior>().SetTarget(cam.transform.position + (transform.TransformDirection(Vector3.forward)*range));
                GameObject.Destroy(laser,1f);
            }
        }
    }

    public void SetDamage(float newDamage)
    {
        damage = newDamage;
    }

    public float GetDamage()
    {
        return damage;
    }
}