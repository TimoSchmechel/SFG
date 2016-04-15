/*
Script for Simple Fighting Game
By IGDA Macquarie University

Project Contributors:
Matt Cabanag
Garion Knapp
Joshia Braico
Michael Baker
Allan Dominguez

This Script:
Matt Cabanag
Michael Baker

*/

using UnityEngine;
using System.Collections;

public class SFGCharacterMotor : MonoBehaviour {

    public float maxSpeed = 2;
    public float speed = 2;
    public float jumpPower = 50f;
    public Vector2 hVector;
    public bool jumpSwitch;
    public float sanityCoEfficient = 200;


    public bool grounded;

    private Rigidbody rBody;
    public Animator anim;
    Vector3 mVector;

    

    // Use this for initialization
    void Start()
    {
        rBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Jump", !grounded);
        anim.SetFloat("Speed", Mathf.Abs(rBody.velocity.x));

        HorizontalMove();
        Jumping();

    }

    void Jumping()
    {
        //jumping 
        if (jumpSwitch)
        {
            if (grounded)
            {
                rBody.AddForce(Vector3.up * jumpPower * sanityCoEfficient);
            }
        }
    }

    void HorizontalMove()
    {

        //float h = Input.GetAxis("Horizontal");

        hVector.Normalize();

        //translate between vector2 space and vector3 space...
        mVector = Vector3.zero;
        mVector.x = hVector.x;
        mVector.z = hVector.y;

        //make the rigidbody move, but constrain it with maxspeed
        //if (rBody.velocity.magnitude < maxSpeed)
        rBody.AddForce(mVector * speed * sanityCoEfficient);

    }
}
