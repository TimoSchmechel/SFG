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

public class Knockback : MonoBehaviour
{
    public Vector3 direction;
    public float force = 10;

    Vector3 knockbackForce;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnCollisionEnter(Collision col)
    {

        Debug.Log("Knockback. Colliding with: " + col.gameObject.name);

    }

    void OnTriggerEnter(Collider col)
    {

        Debug.Log("Knockback. Trigger entered: " + col.gameObject.name);


        //knock back the rigidbody
        Rigidbody r;
        r = col.gameObject.GetComponent<Rigidbody>();
        PushBody(r);

        col.gameObject.SendMessage("Knockback", SendMessageOptions.DontRequireReceiver);
    }

    public void PushBody(Rigidbody r)
    {
        //just take the direction from the vector and give it the scalar force
        knockbackForce = direction.normalized * force;

        //check if you're part of a player...
        Attack a = GetComponent<Attack>();
        if(a != null)
        {
            //flip the force if the hit subject is to the left of the knocker backer..
            if(a.myAttackManager != null)
            {
                if(transform.position.x < a.myAttackManager.transform.position.x)
                {
                    knockbackForce.x *= -1;
                }
            }
        }
        
        //apply the force..
        if (r != null)
        {
            //r.AddForce(knockbackForce);
            r.velocity = knockbackForce;
        }
    }
}
