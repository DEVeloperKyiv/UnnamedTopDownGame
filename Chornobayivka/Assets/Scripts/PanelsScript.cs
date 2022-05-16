using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScript : MonoBehaviour
{
    public GameObject Credits;
    
    public void CloseButton()
    {
        Credits.SetActive(false);
    }
}
