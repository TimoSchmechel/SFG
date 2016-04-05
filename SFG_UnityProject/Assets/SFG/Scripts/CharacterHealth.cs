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

public class CharacterHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;

    public GameObject [] deathSpawn;
    public HealthBar myHealhBar;

	// Use this for initialization
	void Start ()
    {
        if(myHealhBar != null)
            myHealhBar.SetHealth(health);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (health > maxHealth)
            health = maxHealth;

        if (health <= 0)
        {

            foreach(GameObject o in deathSpawn)
            {
                Instantiate(o, transform.position, transform.rotation);
            }

            Destroy(gameObject);
        }
	}

    public void UpdateHealth(int h)
    {
        health += h;

        if(myHealhBar != null)
            myHealhBar.SetHealth(health);
    }
}
