using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastMenu : MonoBehaviour
{
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
