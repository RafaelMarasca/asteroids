using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject timer;

    [SerializeField]
    private GameObject completeLevel;

    [SerializeField]
    private GameObject gameOverScreen;

    [SerializeField]
    private GameObject otherUI;

    [SerializeField]
    private GameObject portal;

    [SerializeField]
    private GameObject player;


    private void HideCompleteLevel()
    {
        completeLevel.SetActive(false);
        
        //var movement = player.GetComponent<PlayerInput>();
        //var pInput = player.GetComponent<PlayerInput>();
        //movement.enabled = true;
        //pInput.DeactivateInput();
    }


    private void ShowCompleteLevel()
    {

        completeLevel.SetActive(true);
        Invoke("HideCompleteLevel",3f);
    }


    public void LevelComplete()
    {
        timer.GetComponent<Timer>().StopTimer();
        ShowCompleteLevel();
        portal.SetActive(true);
    }
    
    
    public void GameOver()
    {
        //var movement = player.GetComponent<PlayerMovement>();
        //movement.enabled = false;
        var pInput = player.GetComponent<PlayerInput>();
        pInput.DeactivateInput();


        otherUI.SetActive(false);
        Time.timeScale = 0.3F;
        gameOverScreen.SetActive(true);

    }

    public void Awake()
    {
        Time.timeScale = 1F;
    }


    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }


    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
