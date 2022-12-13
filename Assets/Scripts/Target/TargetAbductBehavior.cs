using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAbductBehavior : MonoBehaviour
{    
    [SerializeField]
    protected float abductionEnergy = 100f;

    [SerializeField]
    protected float regenerateRate = 0.1f;

    [SerializeField]
    protected GameObject abductionPrefab;

    protected Renderer rend;
    protected float currentAbductionEnergy;
    protected float timeToRegenerate = 0f;
    protected bool abducted = false;

    protected GameObject Inventory;


    public enum BlendMode
    {
        Opaque,
        Transparent
    }

    public static void SetupBlendMode(Material material, BlendMode blendMode)
    {
        switch (blendMode)
        {
            case BlendMode.Transparent:
                material.SetOverrideTag("RenderType", "Transparent");
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.SetInt("_ZWrite", 0);
                material.DisableKeyword("_ALPHATEST_ON");
                material.EnableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
                material.SetFloat("_Surface", 1.0f);
                break;
            case BlendMode.Opaque:
                material.SetOverrideTag("RenderType", "");
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                material.SetInt("_ZWrite", 1);
                material.DisableKeyword("_ALPHATEST_ON");
                material.DisableKeyword("_ALPHABLEND_ON");
                material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                material.renderQueue = -1;
                material.SetFloat("_Surface", 0.0f);
                break;
        }
    }

    void Start()
    {
        rend = GetComponent<Renderer>();
        currentAbductionEnergy = abductionEnergy;
        abducted = false;
        Inventory = GameObject.Find("Player/Inventory"); 
    }

    public virtual void OnAbduct(float energyDrain)
    {

        if(!abducted)
        {
            if(rend.material.GetFloat("_Surface") != 1.0f)
            {
                SetupBlendMode(rend.material,BlendMode.Transparent);
            }
        
            timeToRegenerate = Time.time + 1/regenerateRate;
        
            currentAbductionEnergy -= energyDrain;
            Color color = rend.material.color;

            if(color.a > 0f)
            {
                color.a -= 0.1f;
            }
            
            rend.material.color = color;

            if(currentAbductionEnergy <= 0f)
            {
                abductionComplete();
            }
        }
    }

    public virtual void ResetAbduction()
    {
        currentAbductionEnergy = abductionEnergy;
        Color color = rend.material.color;
        color.a = 1.0f;
        rend.material.color = color;
        SetupBlendMode(rend.material,BlendMode.Opaque);
    }


    private void abductionComplete()
    {
        if(!abducted)
        {
            abducted = true;

            Collector c = Inventory.GetComponent<Collector>();

            c.AddItem(gameObject.tag);

            GameObject abd = GameObject.Instantiate(abductionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(abd,2f);
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
