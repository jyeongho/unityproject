using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimationPicker : MonoBehaviour {

	Animator anim;
	int AnimChoose;

	public float speed ;

    private Rigidbody rb;

    // Update is called once per frame
    void Start () {

        rb = GetComponent<Rigidbody>();


        /*
        anim = GetComponent<Animator> ();
		anim.speed = speed = 1 * (Random.Range (.5f, 1.5f));

		AnimChoose = Random.Range(1,3);
		anim.SetInteger("Idle", AnimChoose);
        */
	}


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }



}
