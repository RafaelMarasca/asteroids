using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectorTutorial : MonoBehaviour
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

    public void AddItem(string tag, Vector3 position, Quaternion rotation, float time, Transform parent)
    {
        if(tag == "cow")
        {
            cowNum += 1;
            spawner.SpawnWithDelay(Spawner.Itens.cow, position, rotation, time, parent);

        }else if(tag == "barrel")
        {
            barrelNum += 1;
            spawner.SpawnWithDelay(Spawner.Itens.barrel, position, rotation, time, parent);
        }else if(tag == "astronaut")
        {
            astronautNum += 1;
            spawner.SpawnWithDelay(Spawner.Itens.astronaut, position, rotation, time, parent);
        }

        Debug.Log("Vacas: " + cowNum);
        Debug.Log("Barris: " + barrelNum);
        Debug.Log("Astronautas: " + astronautNum);

        mission.AddItem(tag);

        
        amountText.text = mission.current.ToString();


        if(mission.IsReached())
        {
            mission.Complete();
        }
    }

    public void AddPowerUp(string tag, Vector3 position, Quaternion rotation, float time, Transform parent)
    {
        if(tag == "wireFrame")
        {
            currentPower = powers.wireFrame;
            wfPower.enabled = true;
            Debug.Log("WireFrame");
            
        }else if(tag == "shoot")
        {
            currentPower = powers.shoot;
            laserPower.enabled = true;

        }else if(tag == "speed")
        {
            currentPower = powers.speed;
            speedPower.enabled = true;
        }

        spawner.SpawnWithDelay(Spawner.Itens.lootBox, position, rotation, time, parent);
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
        amountText.text = mission.current.ToString();
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
