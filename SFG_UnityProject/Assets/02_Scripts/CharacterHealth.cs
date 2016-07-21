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

    //Keeps track of weather the player can be hurt by attacks or not
    public bool invunerable;
    public bool justRespawned;
    //Keeps track of how long the player will stay dead before respawn
    public float deadTime;
    public float invulnerableTime;

    public GameObject [] deathSpawn;
    public HealthBar myHealhBar;

    private HeightKiller heightKiller;
    public float yCharHeightLimit = -10;

	// Use this for initialization
	void Start ()
    {
        if(myHealhBar != null)
            myHealhBar.SetHealth(health);

        //If the character just respawned
        if (justRespawned)
        {
            //Hide the character from the player
            gameObject.SetActive(false);
            Invoke("showCharacter", deadTime);
            //And when they appear make them invulnerable for a period of time
            if (invunerable)
            {
                Invoke("setToVulnerable", deadTime + invulnerableTime);
            }
        }
        heightKiller = gameObject.AddComponent<HeightKiller>();
        heightKiller.yLimit = yCharHeightLimit;
    }

    //Shows the character on the screen
    private void showCharacter()
    {
        gameObject.SetActive(true);
    }

    //Sets the character to vulnerable so they can be attacked
    private void setToVulnerable()
    {
        invunerable = false;
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

            RespawnPlayer();
        }
	}

    //Respawn player at designated position
    private void RespawnPlayer(Vector3 newPosition)
    {
        //Health is reset so that new new character has the same starting health
        health = maxHealth;
        //Creates the new Character and sets the character to invulnerable
        //and hides the character from being seen
        GameObject newPlayer = gameObject;
        CharacterHealth newPlayerChar = newPlayer.GetComponent<CharacterHealth>();
        newPlayerChar.invunerable = true;
        newPlayerChar.justRespawned = true;
        Instantiate(newPlayer, newPosition, new Quaternion(0, 0, 0, 0));

        //Destroys the old one
        Destroy(gameObject);
    }
    //Respawn player at origin point
    private void RespawnPlayer()
    {
        RespawnPlayer(Vector3.zero);
    }


    public void UpdateHealth(int h)
    {
        health += h;

        if(myHealhBar != null)
            myHealhBar.SetHealth(health);
    }

    public void Kill()
    {
        health = 0;
    }
}
