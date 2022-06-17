using UnityEngine;
using UnityEngine.UI;
public class Points : MonoBehaviour
{
    public Text pointText;
    public int points;
    private void Start()
    {
        points = 0;
    }

    void Update()
    {
        pointText.text = points.ToString();
    }
}
