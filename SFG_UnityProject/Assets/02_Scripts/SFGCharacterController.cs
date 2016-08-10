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
*/

using UnityEngine;
using System.Collections;

public class SFGCharacterController : MonoBehaviour
{

    public KeyCode leftKey = KeyCode.LeftArrow;
    public KeyCode rightKey = KeyCode.RightArrow;
    public KeyCode upKey = KeyCode.UpArrow;
    public KeyCode downKey = KeyCode.DownArrow;
    public KeyCode jumpKey = KeyCode.RightShift;
    public KeyCode attack = KeyCode.E;
    public KeyCode throwAttack = KeyCode.Q;

    public bool autoAssign = false;

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
    Rigidbody rBody;

    // Use this for initialization
    void Start ()
    {
        if(autoAssign)
        {
            Init();
        }
    }

    public void Init()
    {
        if (myMotor == null)
            myMotor = gameObject.GetComponent<SFGCharacterMotor>();

        originalPos = transform.position;

        //apply the fighter's constraint settings to the rigidbody;
        if (rBody == null)
            rBody = myMotor.GetComponent<Rigidbody>();

        rBody.constraints = RigidbodyConstraints.None;

        if (axisRestrictions.x)
            rBody.constraints = rBody.constraints | RigidbodyConstraints.FreezePositionX;

        if (axisRestrictions.y)
            rBody.constraints = rBody.constraints | RigidbodyConstraints.FreezePositionY;

        if (axisRestrictions.z)
            rBody.constraints = rBody.constraints | RigidbodyConstraints.FreezePositionZ;

        //assume rotation restriction
        rBody.constraints = rBody.constraints | RigidbodyConstraints.FreezeRotation;
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
            //Debug.Log(hVector);
        }

        if(Input.GetKey(downKey))
        {
            hVector.y -= 1;
            //Debug.Log(hVector);
        }

        if(Input.GetKeyDown(attack))
        {
            myMotor.GetComponent<AttackManager>().StartAttack(0);
        }


        jumping = Input.GetKeyDown(jumpKey);
        
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
