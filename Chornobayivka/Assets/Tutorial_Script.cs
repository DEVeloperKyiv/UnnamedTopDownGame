using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Tutorial_Script : MonoBehaviour
{

    public int currentDialogue;
    public Text TextPrompt;
    public GameObject continueButton;
    public bool hasMoved;
    public List<GameObject> enemies;
    public GameObject dummy;
    public GameObject heal;
    bool wasSpawned;
    GameObject currentEnemy;
    GameObject player;
    PlayerMovement pmov;
    bool canSpawn;
    public string[] T_Text =
        {
        "Hello!", //0
        "Here im gonna teach you how to play this game",//1
        "So first lets try moving",//2
        "Move by pressing WASD",//3
        "Great job!",//4
        "Now lets try shooting. To shoot press MB1. Im gonna put this idiot here, kill him",//5
        "Nice",//6
        "You can also shoot 5 bullets at once in a shotgun pattern. Press MB2 to do so",//7
        "Pog",//8
        "Every 20 seconds first aid kit will appear somewhere. Make sure to pick it up",//9
        "I will put one here for tutorials sake. Pick it up",//10
        "You picked it up!",//11
        "Congratulations! Now you are certified to shoot ruzzians! I will send you back to menu now"//12
        };

    private void Start()
    {
        currentDialogue = 0;
        wasSpawned = false;
        player = GameObject.FindGameObjectWithTag("Player");
        pmov = player.GetComponent<PlayerMovement>();
    }
    public void nextDialogue()
    {
        currentDialogue += 1;
        canSpawn = true;
        if(currentDialogue == 10)
        {
            pmov.TakeDamage(10);
        }
    }
    private void Update()
    {
        TextPrompt.text = T_Text[currentDialogue];
        if (currentDialogue == 3 && hasMoved == false)
        {
            continueButton.SetActive(false);
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                hasMoved = true;
                continueButton.SetActive(true);
            }
        }
        if (currentDialogue == 5)
        {
            continueButton.SetActive(false);
            if (canSpawn)
            {
                GameObject _dummy = Instantiate(dummy, new Vector3(0, 0, 0), Quaternion.identity);
                currentEnemy = _dummy;
                canSpawn = false;
            }

            
            if (currentEnemy==null)
            {
                continueButton.SetActive(true);
            }
        }
        if(currentDialogue == 7)
        {
            continueButton.SetActive(false);
            if(canSpawn)
            {
                GameObject _dummy = Instantiate(dummy, new Vector3(0, 0, 0), Quaternion.identity);
                currentEnemy = _dummy;
                canSpawn = false;
            }

            if (currentEnemy==null)
            {
                continueButton.SetActive(true);

            }
        }
        if(currentDialogue == 10)
        {
            continueButton.SetActive(false);
            if (canSpawn)
            {
                GameObject _heal = Instantiate(heal, new Vector3(0, 0, 0), Quaternion.identity);
                currentEnemy = _heal;
                canSpawn = false;
            }

            if (currentEnemy == null)
            {
                continueButton.SetActive(true);
            }
        }
        





    }

}
