using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject levelChanger;

    public void StartGame()
    {
        levelChanger.GetComponent<LevelChanger>().FadeToLevel("LoadUniverse2");
        //SceneManager.LoadScene("Universe1");
    }


    public void Tutorial()
    {
        levelChanger.GetComponent<LevelChanger>().FadeToLevel("Universe1");
        //SceneManager.LoadScene("Universe2");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Tchau!");
    }

}
