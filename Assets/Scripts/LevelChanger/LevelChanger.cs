using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{

    [SerializeField]
    private Animator animator;

    private string nextLevel;


    public void FadeToLevel(string level)
    {
        nextLevel = level;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeOutComplete()
    {
        SceneManager.LoadScene(nextLevel);
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
