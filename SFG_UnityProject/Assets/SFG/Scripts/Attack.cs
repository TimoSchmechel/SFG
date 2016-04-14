/*
Script for Simple Fighting Game
By IGDA Macquarie University

Project Contributors:
Matt Cabanag
Garion Knapp
Joshia Braico

This Script:
Matt Cabanag

test branchs
*/

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Knockback))]
[RequireComponent(typeof(Damager))]
public class Attack : MonoBehaviour
{
    public bool attackActive = false;
    public float activeTime = 0.5f;
    public AttackManager myAttackManager;

    float timer;

	// Use this for initialization
	void Start ()
    {
	    if(myAttackManager == null)
        {
            myAttackManager = transform.root.GetComponent<AttackManager>();
        }
	}

    public void StartAttack()
    {
        timer = activeTime;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }

	}
}
