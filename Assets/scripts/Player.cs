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
        speed1 = 10;
        speed2 = 0;
        speed3 = 0;
        speed4 = 0;
    }

    void Update()
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

    void switchToPlayer(GameObject camera)
    {
        currentcamera = camera;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb1.AddForce(movement * speed1);
        rb2.AddForce(movement * speed2);
        rb3.AddForce(movement * speed3);
        rb4.AddForce(movement * speed4);
        defaultcamera.transform.position = currentcamera.transform.position;
        defaultcamera.transform.rotation = currentcamera.transform.rotation;

    }
}
