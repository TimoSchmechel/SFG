﻿/*
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
*/

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SFGCharacterMotor))]
public class SFGCharacterController : MonoBehaviour
{

    public KeyCode leftKey = KeyCode.LeftArrow;
    public KeyCode rightKey = KeyCode.RightArrow;
    public KeyCode upKey = KeyCode.UpArrow;
    public KeyCode downKey = KeyCode.DownArrow;
    public KeyCode jumpKey = KeyCode.RightShift;

    public SFGCharacterMotor myMotor;
    [System.Serializable]
    public class AxisRestrictor
    {
        public bool x;
        public bool y;
        public bool z;

    }
    public AxisRestrictor axisRestrictions;


    private bool jumping = false;
    private Vector2 hVector = Vector3.zero;
    private Vector3 originalPos;

    // Use this for initialization
    void Start ()
    {
        if (myMotor == null)
            myMotor = gameObject.GetComponent<SFGCharacterMotor>();

        originalPos = transform.position;

        //apply the fighter's constraint settings to the rigidbody;
        Rigidbody r = gameObject.GetComponent<Rigidbody>();
        r.constraints = RigidbodyConstraints.None;

        if(axisRestrictions.x)
            r.constraints = RigidbodyConstraints.FreezePositionX;

        if(axisRestrictions.y)
            r.constraints = RigidbodyConstraints.FreezePositionY;

        if (axisRestrictions.z)
            r.constraints = RigidbodyConstraints.FreezePositionZ;

        //assume rotation restriction
        r.constraints = RigidbodyConstraints.FreezeRotation;

    }
	
	// Update is called once per frame
	void Update ()
    {
        ManageKeys();
        SyncWithCharacterMotor();
        AxisRestrict();
    }

    void ManageKeys()
    {
        hVector = Vector2.zero;
        
        if(Input.GetKey(rightKey))
        {           
            hVector.x += 1;
        }

        if(Input.GetKey(leftKey))
        {
            hVector.x -= 1;
        }

        if(Input.GetKey(upKey))
        {
            hVector.y += 1;
            Debug.Log(hVector);
        }

        if(Input.GetKey(downKey))
        {
            hVector.y -= 1;
            Debug.Log(hVector);
        }


        jumping = Input.GetKey(jumpKey);
    }

    void SyncWithCharacterMotor()
    {
        if(myMotor != null)
        {
            myMotor.hVector = hVector;
            myMotor.jumpSwitch = jumping;
        }
    }

    void AxisRestrict()
    {
        Vector3 newPos = transform.position;

        if (axisRestrictions.x)
        {
            newPos.x = originalPos.x;
        }

        if (axisRestrictions.y)
        {
            newPos.y = originalPos.y;
        }

        if (axisRestrictions.z)
        {
            newPos.z = originalPos.z;
        }

        transform.position = newPos;
    }
}