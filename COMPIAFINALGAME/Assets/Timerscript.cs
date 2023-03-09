using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timerscript : MonoBehaviour
{
   
    public float currentTime;
    public Text timerText;

    public bool hasFormat;
    public TimerFormats format;
    private Dictionary<TimerFormats, string> timeFormats = new Dictionary<TimerFormats, string>();

    // Start is called before the first frame update
    void Start()
    {
        timeFormats.Add(TimerFormats.Whole, "0");
        timeFormats.Add(TimerFormats.Tenth, "0.0");
        timeFormats.Add(TimerFormats.Hundreths, "0.00");
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = currentTime += Time.deltaTime;
        timerText.text =  hasFormat ? currentTime.ToString(timeFormats[format]) : currentTime.ToString();
    }

    public enum TimerFormats
    {
        Whole,
        Tenth,
        Hundreths
    }
}
