using System.Collections;
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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("On Trigger Enter!!!");
    }
}
