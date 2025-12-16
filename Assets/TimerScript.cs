using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public float time;
    public TextMeshProUGUI timerText;

    void Update()
    {
        time += Time.deltaTime;
        timerText.text=Mathf.Floor(time).ToString();
    }
}
