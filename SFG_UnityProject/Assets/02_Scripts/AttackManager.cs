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

public class AttackManager : MonoBehaviour
{
    public Attack [] attacks;
    public KeyCode [] attackKeys;
    public string [] animationStrings;
    public Animator animator;
    private CharacterHealth charHealth;
    public bool useLocalKeys = false;

    // Use this for initialization
    void Start ()
    {
        charHealth = GetComponent<CharacterHealth>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //If the player is not invulnerable they can attack
        if (!charHealth.invunerable)
        {
            if(useLocalKeys)
                CheckKeys();
        }
    }

    public void StartAttack(int i)
    {
        if (animator != null)
        {
            animator.SetTrigger(animationStrings[i]);
            attacks[i].gameObject.SetActive(true);
            attacks[i].StartAttack();

        }
        else
        {
            attacks[i].gameObject.SetActive(true);
            attacks[i].StartAttack();
        }

    }

    void CheckKeys()
    {
        if(attackKeys != null && attacks != null &&
            attackKeys.Length == attacks.Length)
        {
            for (int i = 0; i < attackKeys.Length; i++)
            { 
               if(Input.GetKeyDown(attackKeys[i]))
                {
                    StartAttack(i);
                }


            }

        }

        
    }

}
