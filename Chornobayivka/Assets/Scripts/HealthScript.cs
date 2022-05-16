using System;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public Image healthBar;

    float health, maxHealth = 100;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        HealthBarFiller();
    }

    public void HealthBarFiller()
    {
        healthBar.fillAmount = health/maxHealth;
    }
}
