using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame(Button Start)
    {
        SceneManager.LoadScene("GameSecondBackupMatty");
        Debug.Log("Start Game");
    }

    public void QuitGame(Button Quit)
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
