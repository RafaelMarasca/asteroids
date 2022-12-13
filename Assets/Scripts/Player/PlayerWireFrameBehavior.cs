using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWireFrameBehavior : MonoBehaviour
{ 

    [SerializeField]
    private Material wireFrameMaterial;

    private bool isWireFrame = false;

    private Transform renderChild;
    
    private List<Renderer> rendList;

    private List<Material> oldMaterials;

    void Awake()
    {
        renderChild = gameObject.transform.GetChild(0).GetChild(0);

        rendList = new List<Renderer>();
        oldMaterials = new List<Material>();

        if(renderChild != null)
        {
            foreach(Transform child in renderChild)
            {
                Renderer rend = child.GetComponent<Renderer>();
                if(rend != null)
                {
                    rendList.Add(rend);
                    oldMaterials.Add(rend.material);
                }
            }
        }
       
    }

     void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            setWireFrame(!isWireFrame);
        }*/
    }


    public void SetWireFrame(bool wf)
    {
        if(isWireFrame != wf)
        {
            isWireFrame = wf;
            
            if(wf)
            {
                foreach(Renderer rend in rendList)
                {
                    rend.material = wireFrameMaterial;
                }
            }else
            {
                int i = 0;
                foreach(Renderer rend in rendList)
                {
                    rend.material = oldMaterials[i];
                    i++;
                }
            }
        }
    }

    public bool GetWireFrame()
    {
        return isWireFrame;
    }
}
