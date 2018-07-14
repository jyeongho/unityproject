using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    GameObject Walls;

    public float speed;

    private int i = 0;
    private bool isMove = false;
    private Rigidbody rb;

    private void Awake()
    {
        Walls = GameObject.FindGameObjectWithTag("Walls");
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) == true && !isMove)
        {
            i = 1;
            isMove = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) == true && !isMove)
        {
            i = 2;
            isMove = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) == true && !isMove)
        {
            i = 3;
            isMove = true;       
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) == true && !isMove)
        {
            i = 4;
            isMove = true;          
        }

        switch (i)
        {
            case 1:
                if (isMove)
                {
                    transform.Translate(Vector3.left * speed * Time.deltaTime);
                }
                break;
            case 2:
                if (isMove)
                {
                    transform.Translate(-Vector3.left * speed * Time.deltaTime);
                }
                break;
            case 3:
                if (isMove)
                {
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                }
                break;
            case 4:
                if (isMove)
                {
                    transform.Translate(-Vector3.forward * speed * Time.deltaTime);
                }
                break;
        }

        if (!isMove)
        {
            
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Walls")
        {
            isMove = false;
            Debug.Log(isMove.ToString());
        }
    }
}
