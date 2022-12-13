using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionGetter : MonoBehaviour
{
    public Mission mission;

    public Collector c;

    public void AcceptMission()
    {
        c.mission = mission;
    }
}
