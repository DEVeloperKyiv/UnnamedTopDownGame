using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public PlayerMovement pM;

    public Animator transitioner;

    private int LevelToLoad;
    void Update()
    {
        if(pM.isDead == true)
        {
            // Debug.Log("do");
        }
    }

    public void RestartButton()
    {
        FadeToLevel(1);

    }

    public void MainMenuButton()
    {
        FadeToLevel(0);
    }
    public void FadeToLevel(int levelIndex)
    {
        LevelToLoad = levelIndex;
        transitioner.SetTrigger("Fade_Out");
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}
