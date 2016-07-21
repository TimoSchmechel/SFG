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

    void OnTriggerEnter(Collider col)
    {
        CharacterHealth h = col.GetComponent<CharacterHealth>();
        //If the character attacked is both vulnerable and has a CharacterHealthScript
        //They will take 1 damage
        if (h != null && !h.invunerable)
        {
            h.UpdateHealth(-damage);
        }
    }
}
