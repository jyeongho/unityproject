﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Count : MonoBehaviour {
    private int n = 0;
    Text CountText;

    // Use this for initialization
    void Start () {
        CountText = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        CountText.text = "Count is :" + n;
	}

    void CountUp()
    {
        n++;
    }
}
