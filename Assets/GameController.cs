using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class GameController : MonoBehaviour {

    private InputField input;
    public Text text;
    public Text limitTimer;
    private float startTime;
    public Button button;
    
    private void Awake()
    {
        input = GameObject.Find("InputField").GetComponent<InputField>();
        button.enabled = false;
    }
    public void GetInput(string str)
    {
        if (text.text == "Shortest path")
        {
            text.text = str;
            startTime = Time.time;
        } else
        {
            if (Int32.Parse(text.text) > Int32.Parse(str))
            {
                text.text = str;
                startTime = Time.time;
            }
        }
        input.text = "";
    }

    private void Update()
    {
        if (text.text != "Shortest path")
        {
            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");
            limitTimer.text = minutes + ":" + seconds;
            if (minutes == "0")
            {
                limitTimer.text = "Time over!";
                button.enabled = true;
            }
        }
    }
}
