using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Sprite carAccu;

    public GameObject shopPanel;
    public GameObject openShopPanel;
    public GameObject closeShopPanel;

    public GameObject gameOverPanel;
    public GameObject gameOverCamera;

    public GameObject generatorNeedWirePanel;
    public GameObject generatorGotWirePanel;

    public GameObject vicPanel;
    public GameObject accuPanel;
    public GameObject needAccuPanel;

	void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;

        shopPanel.SetActive(false);
        openShopPanel.SetActive(false);
        closeShopPanel.SetActive(false);

        gameOverPanel.SetActive(false);
        gameOverCamera.SetActive(false);

        generatorNeedWirePanel.SetActive(false);
        generatorGotWirePanel.SetActive(false);

        vicPanel.SetActive(false);
        accuPanel.SetActive(false);
        needAccuPanel.SetActive(false);
	}

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has Quit");
    }
}
