using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject controlsText;
    public GameObject controlsContent;
    public GameObject playText;
    public GameObject quitText;
    public GameObject nameText;
    public GameObject creditsText;
    public GameObject creditsContent;
    public GameObject gameplayInsText;
    public GameObject gameplayInsContent;


    public GameObject CrWyPt;
    Vector3 controlsPos;
    Vector3 creditsPos;
    Vector3 gameplayInsPos;

    private void Start()
    {
        controlsPos = controlsText.transform.position;
        creditsPos = creditsText.transform.position;
        gameplayInsPos = gameplayInsText.transform.position;
    }

    public void ChangeScene(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void Controls()
    {
        controlsText.transform.position = new Vector3(controlsText.transform.position.x, 650, controlsText.transform.position.z);
        playText.SetActive(false);
        quitText.SetActive(false);
        nameText.SetActive(false);
        creditsText.SetActive(false);
        gameplayInsText.SetActive(false);
        controlsContent.SetActive(true);
        
    }

    public void ControlsBack()
    {
        controlsText.transform.position = controlsPos;
        playText.SetActive(true);
        quitText.SetActive(true);
        nameText.SetActive(true);
        creditsText.SetActive(true);
        gameplayInsText.SetActive(true);
        controlsContent.SetActive(false);
        
    }

    public void Credits()
    {
        creditsText.transform.position = CrWyPt.transform.position;
        playText.SetActive(false);
        quitText.SetActive(false);
        nameText.SetActive(false);
        controlsText.SetActive(false);
        gameplayInsText.SetActive(false);
        creditsContent.SetActive(true);
    }

    public void CreditsBack()
    {
        creditsText.transform.position = creditsPos;
        playText.SetActive(true);
        quitText.SetActive(true);
        nameText.SetActive(true);
        controlsText.SetActive(true);
        gameplayInsText.SetActive(true);
        creditsContent.SetActive(false);

    }

    public void GameplayIns()
    {
        gameplayInsText.transform.position = CrWyPt.transform.position;
        playText.SetActive(false);
        quitText.SetActive(false);
        nameText.SetActive(false);
        controlsText.SetActive(false);
        creditsText.SetActive(false);
        gameplayInsContent.SetActive(true);
    }

    public void GameplayInsBack()
    {
        gameplayInsText.transform.position = gameplayInsPos;
        playText.SetActive(true);
        quitText.SetActive(true);
        nameText.SetActive(true);
        controlsText.SetActive(true);
        creditsText.SetActive(true);
        gameplayInsContent.SetActive(false);

    }

    public void Quit()
    {
        Application.Quit();
    }
}
