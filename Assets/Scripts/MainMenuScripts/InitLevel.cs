using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitLevel : MonoBehaviour
{
    [SerializeField]
    private string level;

    [SerializeField]
    private GameObject changer;


    public void Init()
    {
        changer.GetComponent<LevelChanger>().FadeToLevel(level);
    }
}
