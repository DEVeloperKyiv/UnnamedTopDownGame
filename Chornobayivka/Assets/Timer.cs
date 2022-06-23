using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text text;
    public float rawtime;
    public float time;
    private void Start()
    {
        rawtime = 0f;
    }

    void Update()
    {
        rawtime += Time.deltaTime;
        time = Mathf.Round(rawtime);
        text.text = time.ToString();
    }
}
