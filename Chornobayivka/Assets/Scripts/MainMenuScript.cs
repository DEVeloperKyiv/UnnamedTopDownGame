using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject Credits;
    public GameObject Tutorial;

    public void StartButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void TutorialButton()
    {
        Tutorial.SetActive(true);
    }

    public void CreditsButton()
    {
        Credits.SetActive(true);
    }

    public void ExitButton()
    {
        Debug.Log("Quit");
    }
}
