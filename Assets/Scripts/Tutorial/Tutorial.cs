using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tutorial : MonoBehaviour
{
    public GameObject [] popUps;
    private int index;

    [SerializeField]
    private GameObject asteroids;
    [SerializeField]
    private GameObject abduction;
    [SerializeField]
    private GameObject orb;
    [SerializeField]
    private GameObject portal;

    // Start is called before the first frame update
    void Awake()
    {
        index = 0;
    }


    void ActivateTutorial(int index)
    {
        if(index == 3)
        {
            asteroids.SetActive(true);
        }else if (index ==4)
        {
            abduction.SetActive(true);
        }else if (index ==5)
        {
            orb.SetActive(true);
        }else if(index == 6)
        {
            portal.SetActive(true);
        }
    }

    void DisableTutorial(int index)
    {
        if(index == 3)
        {
            asteroids.SetActive(false);
        }else if(index == 4)
        {
            abduction.SetActive(false);
        }else if (index ==5)
        {
            orb.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            popUps[index].SetActive(false);
            DisableTutorial(index);
            
            if(index <  popUps.Length-1)
            {
                index +=1;
                popUps[index].SetActive(true);
            }

            ActivateTutorial(index);
        }
    }
}
