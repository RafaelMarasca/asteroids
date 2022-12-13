using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI timerText;
    
    [SerializeField]
    private GameObject lm;

    private LevelManager manager;

    [SerializeField]
    private float currentTime;


    // Start is called before the first frame update
    void Start()
    {
        manager = lm.GetComponent<LevelManager>();  
    }


    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        DisplayText(currentTime);

    }

    void DisplayText(float Time)
    {
        int minutes = (int)currentTime/60;
        int seconds = ((int)currentTime)%60;

        timerText.text = minutes.ToString("00") + " : " + seconds.ToString("00");

        if(currentTime <= 0)
        {
            timerText.color = Color.red;
            enabled = false;
            manager.GameOver();
        }   
    }

    void InitTimer(float time)
    {
        currentTime = time;
    }

    public void StopTimer()
    {
        timerText.color = Color.green;
        enabled = false;
    }
}
