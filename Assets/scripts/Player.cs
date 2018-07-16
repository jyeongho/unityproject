using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

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
    public float speed;
    public GameObject CountText;
    private GameObject currentcamera;
    private bool button;
    public int i = 0;
    private bool isMove;
    private Ray ray;
    private RaycastHit h;
    private Vector3 dis;
    private int select = 0;
    private int rayCount = 0;

    private RandomTexture rt;
    private Token mainToken;
    private Count count;

    private GameController gameController;
    private int condition;

    public InputField inputField;
    public AudioClip MusicClip;
    public AudioSource MusicSource;
    public AudioClip MusicClip1;
    public AudioSource MusicSource1;
    public AudioSource MusicSource2;
    public AudioClip MusicClip3;
    public AudioSource MusicSource3;
    public Image image;
    public TextMeshProUGUI succestext;
    public TextMeshProUGUI failtext;

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
        button = false;

        rt = GameObject.Find("RandomToken").GetComponent<RandomTexture>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        count = GameObject.Find("CountText").GetComponent<Count>();
        CountText = GameObject.Find("CountText");
        mainToken = rt.mainToken;
        MusicSource.clip = MusicClip;
        MusicSource1.clip = MusicClip1;
        MusicSource3.clip = MusicClip3;
    }

    void Update()
    {
        if (button)
        {
            if (Input.GetKeyDown("r"))
            {
                select = 1;
                image.color = Color.red;
                MusicSource3.Play();
            }
            if (Input.GetKeyDown("b"))
            {
                select = 2;
                image.color = Color.blue;
                MusicSource3.Play();
            }
            if (Input.GetKeyDown("y"))
            {
                select = 3;
                image.color = Color.yellow;
                MusicSource3.Play();
            }
            if (Input.GetKeyDown("g"))
            {
                select = 4;
                image.color = Color.green;
                MusicSource3.Play();
            }
        }

        /* (i = 1, Left), (i = 2, Right), (i = 3, UpArrow), (i = 4, DownArrow) */

        if (Input.GetKeyDown(KeyCode.LeftArrow) == true && !isMove)
        {
            i = 1;
            isMove = true;
            button = false;
            MusicSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) == true && !isMove)
        {
            i = 2;
            isMove = true;
            button = false;
            MusicSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) == true && !isMove)
        {
            i = 3;
            isMove = true;
            button = false;
            MusicSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) == true && !isMove)
        {
            i = 4;
            isMove = true;
            button = false;
            MusicSource.Play();
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
    void MovePlayer(Rigidbody rb, int direction)
    {
        switch (direction)
        {
            case 1:
                if (rayCount == 0)
                {
                    ray = new Ray(rb.transform.position, Vector3.left);
                    Physics.Raycast(ray, out h);
                    rayCount++;
                    temp = rb.transform.position;
                    dis = new Vector3(Mathf.Floor(h.distance), 0, 0);
                    //Debug.Log("Case 1, hit distnace : " + h.distance);
                    //Debug.Log("case1    , hit collider name is : " + h.collider.name);
                    //Debug.Log("case1, hit collider tag is : " + h.collider.tag);
                    if (h.collider.gameObject.CompareTag("TokenTag"))
                    {
                        dis = dis + new Vector3(1.0f, 0.0f, 0.0f);
                        //Debug.Log("case1 tag is tokenTag");
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
                    //Debug.Log("Case 2, hit distnace : " + h.distance);
                    //Debug.Log("case2, hit collider name is : " + h.collider.name);
                    //Debug.Log("case2, hit collider tag is : " + h.collider.tag);
                    //Debug.Log("case2 dis vector is " + dis.x + "/" + dis.y + "/" + dis.z + "/");

                    if (h.collider.gameObject.CompareTag("TokenTag"))
                    {
                        dis = dis - new Vector3(1.0f, 0.0f, 0.0f);
                        //Debug.Log("case2 tag is tokenTag" + dis.x + "/" + dis.y + "/" + dis.z + "/");
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
                    //Debug.Log("Case 3, hit distnace : " + h.distance);
                    //Debug.Log("case3, hit collider name is : " + h.collider.name);
                    //Debug.Log("case3, hit collider tag is : " + h.collider.tag);
                    if (h.collider.gameObject.CompareTag("TokenTag"))
                    {
                        dis = dis - new Vector3(0.0f, 0.0f, 1.0f);
                        //Debug.Log("case3 tag is tokenTag"+ dis.x +"/" + dis.y +"/"+dis.z+"/");
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
                    //Debug.Log("Case 4, hit distnace : " + h.distance);
                    //Debug.Log("case4, hit collider name is : " + h.collider.name);
                    //Debug.Log("case4, hit collider tag is : " + h.collider.tag);
                    if (h.collider.gameObject.CompareTag("TokenTag"))
                    {
                        dis = dis + new Vector3(0.0f, 0.0f, 1.0f);
                        //Debug.Log("case4 tag is tokenTag");
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
            i = 0;
            rayCount = 0;
            //TODO: do not count when it is not moving
            count.SendMessage("CountUp");
            //Game Over (Times up / count exceed)
            condition = gameController.condition;
            Debug.Log(condition.ToString());
            if (count.n == condition)
            {
                if ((mainToken.getColor() == 0) || (mainToken.getColor() == select))
                {
                    float distance = Vector3.Distance(
                        rb.transform.position,
                        new Vector3(mainToken.getXaxis(), 0.3f, mainToken.getZaxis()));
                    if (distance < 0.5)
                    { //TODO: add condition of counrt
                        Debug.Log("You success!!");
                        succestext.text = "SUCCESS";
                    }
                    else
                    {
                        Debug.Log("You failed...");
                        failtext.text = "FAIL";
                    }
                }
                else
                {
                    Debug.Log("You failed...");
                    failtext.text = "FAIL";
                }
            }
        }
    }

    public void buttonOn()
    {
        button = true;
        inputField.enabled = false;
        MusicSource1.Play();
        MusicSource2.Pause();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("On Trigger Enter!!!");
        Debug.Log("On Trigger Enter!!!~~~");
        Debug.Log("On Trigger Enter!!!@#@#");
    }


}
