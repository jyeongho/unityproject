using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
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
    float speed1;
    float speed2;
    float speed3;
    float speed4;
    private GameObject currentcamera;
    private bool button;
    private int i = 0;
    private bool isMove;
    private int n = 0;

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
        speed1 = 0;
        speed2 = 0;
        speed3 = 0;
        speed4 = 0;
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
                speed1 = 10;
                speed2 = 0;
                speed3 = 0;
                speed4 = 0;
            }
            if (Input.GetKeyDown("b"))
            {
                switchToPlayer(cameraplayer2);
                speed1 = 0;
                speed2 = 10;
                speed3 = 0;
                speed4 = 0;
            }
            if (Input.GetKeyDown("y"))
            {
                switchToPlayer(cameraplayer3);
                speed1 = 0;
                speed2 = 0;
                speed3 = 10;
                speed4 = 0;
            }
            if (Input.GetKeyDown("g"))
            {
                switchToPlayer(cameraplayer4);
                speed1 = 0;
                speed2 = 0;
                speed3 = 0;
                speed4 = 10;
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
            switch (i)
            {
                case 1:
                    transform.Translate(Vector3.left * speed1 * Time.deltaTime);
                    transform.Translate(Vector3.left * speed2 * Time.deltaTime);
                    transform.Translate(Vector3.left * speed3 * Time.deltaTime);
                    transform.Translate(Vector3.left * speed4 * Time.deltaTime);
                    break;
                case 2:
                    transform.Translate(-Vector3.left * speed1 * Time.deltaTime);
                    transform.Translate(-Vector3.left * speed2 * Time.deltaTime);
                    transform.Translate(-Vector3.left * speed3 * Time.deltaTime);
                    transform.Translate(-Vector3.left * speed4 * Time.deltaTime);
                    break;
                case 3:
                    transform.Translate(Vector3.forward * speed1 * Time.deltaTime);
                    transform.Translate(Vector3.forward * speed2 * Time.deltaTime);
                    transform.Translate(Vector3.forward * speed3 * Time.deltaTime);
                    transform.Translate(Vector3.forward * speed4 * Time.deltaTime);
                    break;
                case 4:
                    transform.Translate(-Vector3.forward * speed1 * Time.deltaTime);
                    transform.Translate(-Vector3.forward * speed2 * Time.deltaTime);
                    transform.Translate(-Vector3.forward * speed3 * Time.deltaTime);
                    transform.Translate(-Vector3.forward * speed4 * Time.deltaTime);
                    break;
            }
        }

    }

    void switchToPlayer(GameObject camera)
    {
        currentcamera = camera;
    }

    void FixedUpdate()
    {
        /*
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb1.AddForce(movement * speed1);
        rb2.AddForce(movement * speed2);
        rb3.AddForce(movement * speed3);
        rb4.AddForce(movement * speed4);
        */
        defaultcamera.transform.position = currentcamera.transform.position;
        defaultcamera.transform.rotation = currentcamera.transform.rotation;

    }


    public void buttonOn()
    {
        button = true;
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(i.ToString());
        if (i > 0) {
            if ((i < 3) && (other.transform.tag == "VerticalWalls"))
        {
                //move to center
                if (i == 1)
                {
                    transform.position = Vector3.MoveTowards
                        (transform.position,
                        transform.position + new Vector3(0.135f, 0, 0),
                        speed1 * Time.deltaTime);
                    transform.position = Vector3.MoveTowards
    (transform.position,
    transform.position + new Vector3(0.135f, 0, 0),
    speed2 * Time.deltaTime);
                    transform.position = Vector3.MoveTowards
    (transform.position,
    transform.position + new Vector3(0.135f, 0, 0),
    speed3 * Time.deltaTime);
                    transform.position = Vector3.MoveTowards
    (transform.position,
    transform.position + new Vector3(0.135f, 0, 0),
    speed4 * Time.deltaTime);
                }
                else
                {
                    transform.position = Vector3.MoveTowards
                        (transform.position,
                        transform.position + new Vector3(-0.135f, 0, 0),
                        speed1 * Time.deltaTime);
                    transform.position = Vector3.MoveTowards
    (transform.position,
    transform.position + new Vector3(-0.135f, 0, 0),
    speed2 * Time.deltaTime);
                    transform.position = Vector3.MoveTowards
    (transform.position,
    transform.position + new Vector3(-0.135f, 0, 0),
    speed3 * Time.deltaTime);
                    transform.position = Vector3.MoveTowards
    (transform.position,
    transform.position + new Vector3(-0.135f, 0, 0),
    speed4 * Time.deltaTime);
                }
            }
            if ((i >= 3) && (other.transform.tag == "HorizontalWalls"))
            {
                //move to center
                if (i == 3)
                {
                    transform.position = Vector3.MoveTowards
                        (transform.position,
                        transform.position + new Vector3(0, 0, -0.045f),
                        speed1 * Time.deltaTime);
                    transform.position = Vector3.MoveTowards
    (transform.position,
    transform.position + new Vector3(0, 0, -0.045f),
    speed2 * Time.deltaTime);
                    transform.position = Vector3.MoveTowards
    (transform.position,
    transform.position + new Vector3(0, 0, -0.045f),
    speed3 * Time.deltaTime);
                    transform.position = Vector3.MoveTowards
    (transform.position,
    transform.position + new Vector3(0, 0, -0.045f),
    speed4 * Time.deltaTime);
                }
                else
                {
                    transform.position = Vector3.MoveTowards
                        (transform.position,
                        transform.position + new Vector3(0, 0, 0.045f),
                        speed1 * Time.deltaTime);
                    transform.position = Vector3.MoveTowards
    (transform.position,
    transform.position + new Vector3(0, 0, 0.045f),
    speed2 * Time.deltaTime);
                    transform.position = Vector3.MoveTowards
    (transform.position,
    transform.position + new Vector3(0, 0, 0.045f),
    speed3 * Time.deltaTime);
                    transform.position = Vector3.MoveTowards
    (transform.position,
    transform.position + new Vector3(0, 0, 0.045f),
    speed4 * Time.deltaTime);
                }
            }
        }

        button = true;
        isMove = false;
        n += 1;
        i = 0;
    }
}
