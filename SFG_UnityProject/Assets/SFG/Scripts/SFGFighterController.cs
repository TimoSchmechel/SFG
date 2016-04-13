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
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(ThirdPersonCharacter))]
public class SFGFighterController : MonoBehaviour
{
    public float moveSpeed = 10;
    
    [System.Serializable]
    public class AxisRestrictor
    {
        public bool x;
        public bool y;
        public bool z;

    }
    public AxisRestrictor axisRestrictions;

    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode jumpKey;

    public ThirdPersonCharacter myController;

	public Animator myAnimator;


    private Vector3 originalPos;

    private bool jumping = false;
	Vector3 moveDir = Vector3.zero;

    // Use this for initialization
    void Start ()
    {
        myController = GetComponent<ThirdPersonCharacter>();
        originalPos = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
		moveDir = Vector3.zero;
        jumping = false;

        if(Input.GetKey(leftKey))
        {

            moveDir.x = -moveSpeed * Time.deltaTime;
            
        }

        if(Input.GetKey(rightKey))
        {
            moveDir.x = moveSpeed * Time.deltaTime;
        }

        if(Input.GetKey(jumpKey))
        {
            jumping = true;
        }

		ManageAnimations ();

        myController.Move(moveDir, false, jumping);

        AxisRestrict();


    }

	void ManageAnimations()
	{
		if (myAnimator != null) 
		{
			
			myAnimator.SetFloat ("Speed", moveDir.magnitude);
		}
	}

    void AxisRestrict()
    {
        Vector3 newPos = transform.position;

        if(axisRestrictions.x)
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
