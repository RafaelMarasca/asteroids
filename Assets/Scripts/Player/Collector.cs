using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Collector : MonoBehaviour
{

    private int cowNum = 0;
    private int barrelNum = 0;
    private int astronautNum = 0;
    

    public enum powers
    {
        none,
        wireFrame,
        shoot,
        speed
    };

    private powers currentPower;

    [SerializeField]
    public Mission mission;

    [SerializeField]
    public TextMeshProUGUI amountText;
   
    [SerializeField]
    public Image laserPower;

    [SerializeField]
    public Image wfPower;

    [SerializeField]
    public Image speedPower;

    private Spawner spawner;

    public void AddItem(string tag)
    {
        if(tag == "cow")
        {
            cowNum += 1;
            spawner.Spawn(Spawner.Itens.cow);

        }else if(tag == "barrel")
        {
            barrelNum += 1;
            spawner.Spawn(Spawner.Itens.barrel);
        }else if(tag == "astronaut")
        {
            astronautNum += 1;
            spawner.Spawn(Spawner.Itens.astronaut);
        }

        Debug.Log("Vacas: " + cowNum);
        Debug.Log("Barris: " + barrelNum);
        Debug.Log("Astronautas: " + astronautNum);

        mission.AddItem(tag);

        amountText.text = mission.current.ToString() + "/" + mission.required.ToString();

        if(mission.IsReached())
        {
            mission.Complete();
        }
    }

    public void AddPowerUp(string tag)
    {
        if(tag == "wireFrame")
        {
            currentPower = powers.wireFrame;
            wfPower.enabled = true;
            //Debug.Log("usaremos um wireFrame");
            
        }else if(tag == "shoot")
        {
            currentPower = powers.shoot;
            laserPower.enabled = true;
            //Debug.Log("usaremos um Tiro");

        }else if(tag == "speed")
        {
            currentPower = powers.speed;
            speedPower.enabled = true;
            //Debug.Log("usaremos uma velocidade");
        }

        spawner.Spawn(Spawner.Itens.lootBox);
    }

    public void ConsumePowerUp()
    {
        currentPower = powers.none;
        laserPower.enabled = false;
        wfPower.enabled = false;
        speedPower.enabled = false;
    }

    public powers GetCurrentPowerUp()
    {
        return currentPower;
    }

    void Awake()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        amountText.text = mission.current.ToString() + "/" + mission.required.ToString();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left"))
        {
            AddPowerUp("wireFrame");
        }
    }
}
