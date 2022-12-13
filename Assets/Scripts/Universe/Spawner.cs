using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public enum Itens
    {
        cow,
        barrel,
        astronaut,
        lootBox,
        commomAsteroid,
        iceAsteroid,
        lavaAsteroid
    };


    [SerializeField]
    private GameObject cowPrefab;

    [SerializeField]
    private GameObject barrelPrefab;

    [SerializeField]
    private GameObject astronautPrefab;

    [SerializeField]
    private GameObject lootBoxPrefab;

    [SerializeField]
    private GameObject commomAsteroidPrefab;
    
    [SerializeField]
    private GameObject iceAsteroidPrefab;

    [SerializeField]
    private GameObject lavaAsteroidPrefab;

    private IEnumerator coroutine;


    public void Spawn(Itens item, Transform parent = null)
    {
        Vector3 position = new Vector3(Random.Range(-500,500), Random.Range(-500,500), Random.Range(-500,500));
        Quaternion rotation = Quaternion.Euler(90,0,0); 

        GameObject aux = null;

        if(item == Itens.cow)
        {
            aux = Instantiate(cowPrefab, position, rotation);
        }else if(item == Itens.barrel)
        {
            aux = Instantiate(barrelPrefab, position, rotation);
        }else if(item == Itens.astronaut)
        {
            aux = Instantiate(astronautPrefab, position, rotation);
        }else if(item == Itens.commomAsteroid)
        {
            aux = Instantiate(commomAsteroidPrefab, position, rotation);
        }else if(item == Itens.iceAsteroid)
        {
            aux = Instantiate(iceAsteroidPrefab, position, rotation);
        }else if(item == Itens.lavaAsteroid)
        {
            aux = Instantiate(lavaAsteroidPrefab, position, rotation);
        }else if(item == Itens.lootBox)
        {
            aux = Instantiate(lootBoxPrefab, position, rotation);
        }

        if(aux != null)
        {
            aux.transform.parent = parent;
        }
    }


    public IEnumerator SpawnAtDelay(Itens item, Vector3 position, Quaternion rotation, float time, Transform parent = null)
    {

        yield return new WaitForSeconds(5); 

        GameObject aux = null;

        if(item == Itens.cow)
        {
            aux = Instantiate(cowPrefab, position, rotation);
        }else if(item == Itens.barrel)
        {
            aux = Instantiate(barrelPrefab, position, rotation);
        }else if(item == Itens.commomAsteroid)
        {
            aux = Instantiate(commomAsteroidPrefab, position, rotation);
        }else if(item == Itens.iceAsteroid)
        {
            aux = Instantiate(iceAsteroidPrefab, position, rotation);
        }else if(item == Itens.lavaAsteroid)
        {
            aux = Instantiate(lavaAsteroidPrefab, position, rotation);
        }else if(item == Itens.lootBox)
        {
            aux = Instantiate(lootBoxPrefab, position, rotation);
        }

        if(aux != null)
        {
            aux.transform.parent = parent;
        }

    }



    public void SpawnAt(Itens item, Vector3 position, Quaternion rotation, float time, Transform parent = null)
    {

        GameObject aux = null;

        if(item == Itens.cow)
        {
            aux = Instantiate(cowPrefab, position, rotation);
        }else if(item == Itens.barrel)
        {
            aux = Instantiate(barrelPrefab, position, rotation);
        }else if(item == Itens.commomAsteroid)
        {
            aux = Instantiate(commomAsteroidPrefab, position, rotation);
        }else if(item == Itens.iceAsteroid)
        {
            aux = Instantiate(iceAsteroidPrefab, position, rotation);
        }else if(item == Itens.lavaAsteroid)
        {
            aux = Instantiate(lavaAsteroidPrefab, position, rotation);
        }else if(item == Itens.lootBox)
        {
            aux = Instantiate(lootBoxPrefab, position, rotation);
        }

        if(aux != null)
        {
            aux.transform.parent = parent;
        }
    }


    public void SpawnWithDelay(Itens item, Vector3 position, Quaternion rotation, float time, Transform parent = null)
    {
        coroutine = SpawnAtDelay(item, position, rotation, time, parent);
        StartCoroutine(coroutine);
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
