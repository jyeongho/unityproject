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
    public int condition=0;
    public Text gameovertext;
    public AudioSource audioSource;
    
    private void Awake()
    {
        input = GameObject.Find("InputField").GetComponent<InputField>();
        button.enabled = false;
    }
    public void GetInput(string str)
    {
        int j;
        if (Int32.TryParse(str, out j) && str.IndexOf("0") != 0 && Int32.Parse(str) > 0)
        {
            Debug.Log("shortestinput = " + text.text);
            if (text.text == "Path")
            {
                text.text = str;
                startTime = Time.time;
                condition = Int32.Parse(str);
            }
            else
            {
                if (Int32.Parse(text.text) > Int32.Parse(str))
                {
                    text.text = str;
                    condition = Int32.Parse(text.text);
                    startTime = Time.time;
                }
            }
            input.text = "";
        } else
        {
            input.text = "";
        }
    }

    private void Update()
    {
        if (text.text != "Path")
        {
            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");
            limitTimer.text = minutes + ":" + seconds;
            if (minutes == "0")
            {
                button.enabled = true;
                limitTimer.text = "";
                gameovertext.text = "Time over!";
                audioSource.volume = 1;
            }
        }
    }
}
