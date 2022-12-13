using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class UniverseVisualization : MonoBehaviour
{

    [SerializeField]
    private CinemachineVirtualCamera playerCam;

    [SerializeField]
    private CinemachineVirtualCamera universeCam;

    void Awake()
    {
        playerCam.Priority = 10;
        universeCam.Priority = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
        
            playerCam.Priority = 10 - playerCam.Priority;
            universeCam.Priority = 10 - universeCam.Priority;
        }
    }
}
