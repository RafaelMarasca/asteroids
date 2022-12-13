using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbAbductBehavior : TargetAbductBehavior
{    
    /*[SerializeField]
    private float abductionEnergy = 100f;

    [SerializeField]
    private float regenerateRate = 0.1f;

    [SerializeField]
    private GameObject abductionPrefab;

    private Renderer rend;
    private float currentAbductionEnergy;
    private float timeToRegenerate = 0f;
    private bool abducted = false;

    private GameObject Inventory;*/

    private bool isInAbduction;
    private ParticleSystem pop;

    private string [] itens = {"wireFrame", "shoot", "speed"};
    


    void Awake()
    {
        currentAbductionEnergy = abductionEnergy;
        abducted = false;
        Inventory = GameObject.Find("Player/Inventory"); 
        isInAbduction = false;
        pop = gameObject.GetComponentInChildren<ParticleSystem>();

        if(pop == null)
        {
            Debug.LogError("Falha de Instancia de Componentes!");
        }
        pop.Stop();
       
    }

    public override void OnAbduct(float energyDrain)
    {

        if(!isInAbduction)
        {
            pop.Play();
        }

        if(!abducted)
        {
            isInAbduction = true;
            timeToRegenerate = Time.time + 1/regenerateRate;
        
            currentAbductionEnergy -= energyDrain;
    
            if(currentAbductionEnergy <= 0f)
            {
                abductionComplete();
            }
        }
    }

    public override void ResetAbduction()
    {
        currentAbductionEnergy = abductionEnergy;

        pop.Stop();
    }


    private void abductionComplete()
    {
        if(!abducted)
        {
            abducted = true;

            Collector c = Inventory.GetComponent<Collector>();

            string s = itens[(int)Random.Range(0,2)];

            Debug.Log("PowerUp: "+ s);
            c.AddPowerUp(s);
    
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if(Time.time > timeToRegenerate)
        {
            ResetAbduction();
            timeToRegenerate = Time.time + 1/regenerateRate;
        }

    }
}
