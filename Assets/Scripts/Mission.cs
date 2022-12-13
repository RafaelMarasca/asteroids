using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Mission
{

    public bool isActive;

    public string title;

    public int required;
    public int current;

    public string objTag;

    [SerializeField]
    private GameObject lm;

    private LevelManager manager;



    public bool IsReached()
    {
        return current == required;
    }


    public void AddItem(string tag)
    {
        if(tag == objTag)
        {
            current +=1;
        }
    }


    public void Complete()
    {
        isActive = false;
        if(!manager)
            manager = lm.GetComponent<LevelManager>();
        manager.LevelComplete();
        Debug.Log(title + " foi completada!");
    }


}
