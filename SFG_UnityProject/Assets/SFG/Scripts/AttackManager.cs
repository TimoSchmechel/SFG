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

public class AttackManager : MonoBehaviour
{
    public Attack [] attacks;
    public KeyCode [] attackKeys;
    public string [] animationStrings;
    public Animator animator;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckKeys();
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


            }

        }

        
    }

}
