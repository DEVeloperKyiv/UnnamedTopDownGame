using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public Text timer;
    private float rawtime = 0f;

    void Update()
    {
        rawtime += Time.deltaTime;
        float _time = Mathf.Round(rawtime);
        timer.text = _time.ToString();
    }
}
