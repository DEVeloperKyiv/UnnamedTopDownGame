using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelsScript : MonoBehaviour
{
    public GameObject Credits;
    public GameObject Tutorial;
    
    public void CloseButton1()
    {
        Credits.SetActive(false);
    }

    public void CloseButton2()
    {
        Tutorial.SetActive(false);
    }
}
