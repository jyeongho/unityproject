﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb1;
    private Rigidbody rb2;
    private Rigidbody rb3;
    private Rigidbody rb4;
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;
    public GameObject defaultcamera;
    public GameObject cameraplayer1;
    public GameObject cameraplayer2;
    public GameObject cameraplayer3;
    public GameObject cameraplayer4;
    public float speed;
    private GameObject currentcamera;
    private bool button;
    public int i = 0;
    private bool isMove;
    private int n = 0;
    private Ray ray;
    private RaycastHit hit, h;
    private Vector3 dis;
    private int select = 0;
    private int rayCount = 0;
    private RandomTexture randomObject;
    private string randomTokenString;

    private Vector3 temp = new Vector3();

    private void Awake()
    {
        isMove = false;
    }

    void Start()
    {
        rb1 = Player1.GetComponent<Rigidbody>();
        rb1.freezeRotation = true;
        rb2 = Player2.GetComponent<Rigidbody>();
        rb2.freezeRotation = true;
        rb3 = Player3.GetComponent<Rigidbody>();
        rb3.freezeRotation = true;
        rb4 = Player4.GetComponent<Rigidbody>();
        rb4.freezeRotation = true;
        currentcamera = defaultcamera;
        button = false;
        randomObject = GameObject.Find("RandomToken").GetComponent<RandomTexture>();

        randomTokenString = randomObject.randomToken;

        Debug.Log("Random index is " + randomTokenString);
        
    }

    void Update()
    {
        if (button)
        {
            if (Input.GetKeyDown("r"))
            {
                switchToPlayer(cameraplayer1);
                select = 1;
            }
            if (Input.GetKeyDown("b"))
            {
                switchToPlayer(cameraplayer2);
                select = 2;
            }
            if (Input.GetKeyDown("y"))
            {
                switchToPlayer(cameraplayer3);
                select = 3;
            }
            if (Input.GetKeyDown("g"))
            {
                switchToPlayer(cameraplayer4);
                select = 4;

                Debug.Log("Green Key");
            }
        }

        /* (i = 1, Left), (i = 2, Right), (i = 3, UpArrow), (i = 4, DownArrow) */

        if (Input.GetKeyDown(KeyCode.LeftArrow) == true && !isMove)
        {
            i = 1;
            isMove = true;
            button = false;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) == true && !isMove)
        {
            i = 2;
            isMove = true;
            button = false;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) == true && !isMove)
        {
            Debug.Log("UpArrow");

            i = 3;
            isMove = true;
            button = false;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) == true && !isMove)
        {
            i = 4;
            isMove = true;
            button = false;
        }

        if (isMove)
        {
            switch (select)
            {
                case 1:
                    MovePlayer(rb1, i);
                    break;
                case 2:
                    MovePlayer(rb2, i);
                    break;
                case 3:
                    MovePlayer(rb3, i);
                    break;
                case 4:
                    MovePlayer(rb4, i);
                    break;
            }
        }
    }

    /* (i = 1, Left), (i = 2, Right), (i = 3, UpArrow), (i = 4, DownArrow) */
    void MovePlayer(Rigidbody rb, int color)
    {
        switch (color)
        {
            case 1:
                if (rayCount == 0)
                {
                    ray = new Ray(rb.transform.position, Vector3.left);
                    Physics.Raycast(ray, out h);
                    rayCount++;
                    temp = rb.transform.position;
                    dis = new Vector3(Mathf.Floor(h.distance), 0, 0);
                    Debug.Log("Case 1, hit distnace : " + h.distance);
                    Debug.Log("case1    , hit collider name is : " + h.collider.name);
                    Debug.Log("case1, hit collider tag is : " + h.collider.tag);
                    if (h.collider.gameObject.CompareTag("TokenTag"))
                    {
                        dis = dis + new Vector3(1.0f, 0.0f, 0.0f);
                        Debug.Log("case1 tag is tokenTag");
                        //h.collider.gameObject.SetActive(false);
                    }

                }
                break;
            case 2:
                if (rayCount == 0)
                {
                    ray = new Ray(rb.transform.position, -Vector3.left);
                    Physics.Raycast(ray, out h);
                    rayCount++;
                    temp = rb.transform.position;
                    dis = new Vector3(-Mathf.Floor(h.distance), 0, 0);
                    Debug.Log("Case 2, hit distnace : " + h.distance);
                    Debug.Log("case2, hit collider name is : " + h.collider.name);
                    Debug.Log("case2, hit collider tag is : " + h.collider.tag);
                    Debug.Log("case2 dis vector is " + dis.x + "/" + dis.y + "/" + dis.z + "/");

                    if (h.collider.gameObject.CompareTag("TokenTag"))
                    {
                        dis = dis - new Vector3(1.0f, 0.0f, 0.0f);
                        Debug.Log("case2 tag is tokenTag" + dis.x + "/" + dis.y + "/" + dis.z + "/");
                    }


                }
                break;
            case 3:
                if (rayCount == 0)
                {
                    ray = new Ray(rb.transform.position, Vector3.forward);
                    Physics.Raycast(ray, out h);
                    rayCount++;
                    temp = rb.transform.position;
                    dis = new Vector3(0, 0, -Mathf.Floor(h.distance));
                    Debug.Log("Case 3, hit distnace : " + h.distance);
                    Debug.Log("case3, hit collider name is : " + h.collider.name);
                    Debug.Log("case3, hit collider tag is : " + h.collider.tag);
                    if (h.collider.gameObject.CompareTag("TokenTag"))
                    {
                        dis = dis - new Vector3(0.0f, 0.0f, 1.0f);
                        Debug.Log("case3 tag is tokenTag"+ dis.x +"/" + dis.y +"/"+dis.z+"/");
                    }

                }
                break;
            case 4:
                if (rayCount == 0)
                {
                    ray = new Ray(rb.transform.position, -Vector3.forward);
                    Physics.Raycast(ray, out h);
                    rayCount++;
                    temp = rb.transform.position;
                    dis = new Vector3(0, 0, Mathf.Floor(h.distance));
                    Debug.Log("Case 4, hit distnace : " + h.distance);
                    Debug.Log("case4, hit collider name is : " + h.collider.name);
                    Debug.Log("case4, hit collider tag is : " + h.collider.tag);
                    if (h.collider.gameObject.CompareTag("TokenTag"))
                    {
                        dis = dis + new Vector3(0.0f, 0.0f, 1.0f);
                        Debug.Log("case4 tag is tokenTag");
                    }

                }
                break;
        }

        if (rb.transform.position != temp - dis)
            rb.transform.position = Vector3.MoveTowards(rb.transform.position, temp - dis, speed * Time.deltaTime);
        else
        {
            isMove = false;
            button = true;
            n += 1;
            i = 0;
            rayCount = 0;
        }
    }

    void switchToPlayer(GameObject camera)
    {
        currentcamera = defaultcamera;
    }

    void FixedUpdate()
    {
        defaultcamera.transform.position = currentcamera.transform.position;
        defaultcamera.transform.rotation = currentcamera.transform.rotation;
    }


    public void buttonOn()
    {
        button = true;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("On Trigger Enter!!!");
        Debug.Log("On Trigger Enter!!!~~~");
        Debug.Log("On Trigger Enter!!!@#@#");
    }


}
