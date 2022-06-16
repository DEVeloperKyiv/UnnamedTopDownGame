using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject Credits;


    public Animator scene_transitioner;

    private int LevelToLoad;

    public void StartButton()
    {
        FadeToLevel(1);
    }



    public void CreditsButton()
    {
        Credits.SetActive(true);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
    public void FadeToLevel(int levelIndex)
    {
        LevelToLoad = levelIndex;
        scene_transitioner.SetTrigger("Fade_Out");
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}
