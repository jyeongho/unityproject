using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTexture : MonoBehaviour {

    GameObject[] tokens;
    GameObject currentObject;
    int index;



	// Use this for initialization
	void Start () {
        tokens = GameObject.FindGameObjectsWithTag("TokenTag");
        index = Random.Range(0, tokens.Length);

        foreach(GameObject item in tokens)
        {
            Debug.Log(item.name);
            Debug.Log(item.name.Substring(0,1));
        }

        Debug.Log("-----------------------");

        currentObject = Instantiate(tokens[index]);

        Debug.Log(currentObject.name);
       
        currentObject.transform.position = new Vector3(0.5f, 0.5f, 0.0f);

	}

    private void Update()
    {
        

    }









}
