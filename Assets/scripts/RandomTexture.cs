using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token
{
    string name;
    //1: red, 2: blue, 3:yellow, 4:green, 0:joker
    int color;
    float x_axis;
    float z_axis;

    public Token(string name, int color, float x_axis, float z_axis)
    {
        this.name = name;
        this.color = color;
        this.x_axis = x_axis;
        this.z_axis = z_axis;
    }

    public string getName()
    {
        return this.name;
    }

    public float getXaxis()
    {
        return this.x_axis;
    }

    public float getZaxis()
    {
        return this.z_axis;
    }

    public int getColor()
    {
        return this.color;
    }
}


public class RandomTexture : MonoBehaviour {

    GameObject[] tokens;
    GameObject currentObject;
    public int index;
    public string randomToken;
    public Token mainToken;
    private int select;

	// Use this for initialization
	void Start () {
        tokens = GameObject.FindGameObjectsWithTag("TokenTag");
        index = Random.Range(0, tokens.Length);

        randomToken = tokens[index].name;

        Debug.Log("----------------------- Random index is set");

        Debug.Log("RandomTextures : " + tokens[index].name);
        if (randomToken.Contains("Red"))
        {
            select = 1;
        }
        else if (randomToken.Contains("Blue"))
        {
            select = 2;
        }
        else if (randomToken.Contains("Yellow"))
        {
            select = 3;
        }
        else if (randomToken.Contains("Green"))
        {
            select = 4;
        }
        else
        {
            select = 0;
        }
        mainToken = new Token(randomToken, select, tokens[index].transform.position.x, tokens[index].transform.position.z);
        Debug.Log(mainToken.getName());
        Debug.Log(mainToken.getXaxis().ToString());
        Debug.Log(mainToken.getZaxis().ToString());
        Debug.Log(mainToken.getColor().ToString());


        currentObject = Instantiate(tokens[index]);

        //Debug.Log("RandomTextures : " + currentObject.name);
       
        currentObject.transform.position = new Vector3(0, 0.5f, 0);

	}
}
