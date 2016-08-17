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
Hayden Munday

*/

using UnityEngine;
using System.Collections;

public class SFGCharacterMotor : MonoBehaviour
{
    public float maxSpeed = 6;
    public float speed = 4;
    public float jumpPower = 90f;//guessed
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

        if (!grounded)
            anim.SetBool("InAir", true);
        else
            anim.SetBool("InAir", false);
    }

    void Knockback()
    {
        if (GetComponent<CharacterHealth>().health > 1)//only knockback if it's not going to cause death otherwise death anim can take it's place
            anim.SetTrigger("TakeHit");
    }

    void HorizontalMove()
    {

        //float h = Input.GetAxis("Horizontal");

        hVector.Normalize();

        //translate between vector2 space and vector3 space...
        mVector = Vector3.zero;
        mVector.x = hVector.x;
        mVector.z = hVector.y;


        //don't go past a certain speed..
        Vector3 output = mVector * speed * sanityCoEfficient;
        rBody.AddForce(output);
        Vector3 vel = rBody.velocity, result = new Vector3(0, 0, 0);
        if ((!(rBody.velocity.magnitude < maxSpeed && rBody.velocity.magnitude > -maxSpeed)) && grounded)// if grounded and too fast then basic slow down.
        {
            result = vel * -1;
            result.Normalize();
            //result = result * (vel.magnitude - maxSpeed);
            rBody.AddForce(result * speed * sanityCoEfficient);
        }
        else if ((!(rBody.velocity.magnitude < maxSpeed && rBody.velocity.magnitude > -maxSpeed)) && !grounded)// if in air restrict vertical movment
        {
            if (vel.x > maxSpeed)
            {
                result.x = -(vel.x-maxSpeed);//slow down but don't stop player
            }
            if (vel.x < -maxSpeed)
            {
                result.x = -(vel.x + maxSpeed);//slow down but don't stop player
            }
            if (vel.y > maxSpeed)
            {
                result.y = -(maxSpeed/3);
            }
            rBody.AddForce(result * speed * sanityCoEfficient);
        }

    }
}
