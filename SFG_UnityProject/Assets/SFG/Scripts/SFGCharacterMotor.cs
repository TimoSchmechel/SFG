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

    public float maxSpeed = 5;
    public float speed = 100f;
    public float jumpPower = 200f;
    public Vector2 hVector;
    public bool jumpSwitch;


    public bool grounded;
    public bool doubleJump;

    public int currentHealth;
    public int maxHealth = 5;

    private Rigidbody rBody;
    public Animator anim;


    // Use this for initialization
    void Start()
    {
        rBody = gameObject.GetComponent<Rigidbody>();
        currentHealth = maxHealth;
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

                rBody.AddForce(Vector3.up * jumpPower);
                doubleJump = true;

            }
            else
            {
                if (doubleJump)
                {
                    rBody.velocity = new Vector3(rBody.velocity.x, 0.0f);
                    rBody.AddForce(Vector3.up * jumpPower);
                    doubleJump = false;
                }
            }
        }
    }

    void HorizontalMove()
    {


        //float h = Input.GetAxis("Horizontal");

        hVector.Normalize();

        //translate between vector2 space and vector3 space...
        Vector3 mVector = Vector3.zero;
        mVector.x = hVector.x;
        mVector.z = hVector.y;

        //make the rigidbody move, but constrain it with maxspeed
        if (rBody.velocity.magnitude < maxSpeed)
            rBody.AddForce(mVector * speed);

    }
}
