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

public class SFGGroundCheck : MonoBehaviour
{

    private SFGCharacterMotor player;


    // Use this for initialization
    void Start()
    {
        player = gameObject.GetComponentInParent<SFGCharacterMotor>();
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        player.grounded = true;

    }

    void OnTriggerStay(Collider col)
    {
        player.grounded = true;
    }

    void OnTriggerExit(Collider col)
    {

        player.grounded = false;
    }
}
