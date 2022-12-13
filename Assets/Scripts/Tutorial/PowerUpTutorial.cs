using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PowerUpTutorial : MonoBehaviour
{

    private CollectorTutorial collector;

    private PlayerShootBehavior playerShoot;
    private PlayerWireFrameBehavior playerWF;
    private PlayerMovement playerMov;

    private float initDamage;
    private float initVelocity;
    private float initDrag;
    private Rigidbody rb;
    private float initThrust;

    bool notInUse = true;

    private float powerInput = 0f;

    private IEnumerator coroutine;

    private float timeToFinish = 0f;

    void Awake()
    {
        collector = GetComponentInChildren<CollectorTutorial>();
        rb = GetComponent<Rigidbody>();

        playerShoot = GetComponent<PlayerShootBehavior>();
        playerWF = GetComponent<PlayerWireFrameBehavior>();
        playerMov = GetComponent<PlayerMovement>();

        initDamage = playerShoot.GetDamage();
        initVelocity = playerMov.GetMaxSpeed();
        initDrag = rb.drag;
        initThrust = playerMov.GetThrust();
    }


    public void OnPower(InputAction.CallbackContext context)
    {
        powerInput = context.ReadValue<float>();
    }


    public void UsePowerUp()
    {
        Debug.Log("Usando...");
        playerWF.SetWireFrame(false);
        playerShoot.SetDamage(initDamage);
        playerMov.SetMaxSpeed(initVelocity);
        playerMov.SetThrust(initThrust);
        collector.ConsumePowerUp();
        notInUse = true;
    }

    public void powerHandler()
    {
        if(collector.GetCurrentPowerUp() == CollectorTutorial.powers.wireFrame)
        {
            playerWF.SetWireFrame(true);

            timeToFinish = Time.time + 5.0f;

        }else if(collector.GetCurrentPowerUp() == CollectorTutorial.powers.shoot)
        {
            playerShoot.SetDamage(initDamage*4);
            timeToFinish = Time.time + 5.0f;

        }else if(collector.GetCurrentPowerUp() == CollectorTutorial.powers.speed)
        {
            playerMov.SetMaxSpeed(initVelocity*4);
            playerMov.SetThrust(initThrust*4);
            timeToFinish = Time.time + 5.0f;
        }else
        {
            notInUse = true;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(powerInput >0.5 && notInUse)
        {
            notInUse = false;
            powerHandler();
            Debug.Log("Usando");
        }

        if(Time.time >= timeToFinish && notInUse==false)
        {
            UsePowerUp();
        }
    }
}
