/*
Script for Simple Fighting Game
By IGDA Macquarie University

Project Contributors:
Matt Cabanag
Garion Knapp
Joshia Braico

This Script:
Matt Cabanag
*/

using UnityEngine;
using System.Collections;

public class Damager : MonoBehaviour
{
    public int damage = 1;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        CharacterHealth h = col.GetComponent<CharacterHealth>();

        if(h != null)
        {
            h.health -= damage;
        }
    }
}
