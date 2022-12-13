using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{

    [SerializeField]
    private float maxHealth = 500f;

    [SerializeField]
    private GameObject levelManager;
    
    private float health = 500f;

    [SerializeField]
    private Image healthBarImage;

    [SerializeField]
    private GameObject explosion;

    private PlayerWireFrameBehavior wfBehavior;

    private LevelManager manager;


    void Start()
    {
        wfBehavior = GetComponent<PlayerWireFrameBehavior>();
        manager = levelManager.GetComponent<LevelManager>();
    }

    void Update()
    {
        if(Input.GetKeyDown("up"))
        {
            OnHit(100f);
        }
    }


    public void OnHit(float damage)
    {
        if(!wfBehavior.GetWireFrame())
        {
            health -= damage;

            healthBarImage.fillAmount = health/maxHealth;

            if(health <= 0f)
            {
                Die();
            }
        }   

        Debug.Log("Health: " + health);
    }
   
    public virtual void Die()
    {   
        var aux = Instantiate(explosion, transform.position, transform.rotation);     
        //Destroy(aux,3f);
        manager.GameOver();
        gameObject.SetActive(false);
    }
}
