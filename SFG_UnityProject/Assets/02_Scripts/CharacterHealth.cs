
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

public class CharacterHealth : MonoBehaviour {
    public int maxHealth;
    public int health;

    //Keeps track of weather the player can be hurt by attacks or not
    public bool invunerable;
    public bool justRespawned;
    //Keeps track of how long the player will stay dead before respawn
    public float deadTime;
    public float invulnerableTime;

    public GameObject[] deathSpawn;
    public HealthBar myHealhBar;
    public Transform spawnPoint;

    private HeightKiller heightKiller;
    public float yCharHeightLimit = -10;

    private int playerID = 1;//player 1 by default

    // Use this for initialization
    void Start() {
        if (myHealhBar != null)
            myHealhBar.SetHealth(health);


        //If the character just respawned
        if (justRespawned) {
            //Hide the character from the player
            gameObject.SetActive(false);
            Invoke("showCharacter", deadTime);
            //And when they appear make them invulnerable for a period of time
            if (invunerable) {
                Invoke("setToVulnerable", deadTime + invulnerableTime);
            }
        }
        heightKiller = gameObject.AddComponent<HeightKiller>();
        heightKiller.yLimit = yCharHeightLimit;
    }

    //Shows the character on the screen
    private void showCharacter() {
        gameObject.SetActive(true);
    }

    //Sets the character to vulnerable so they can be attacked
    private void setToVulnerable() {
        invunerable = false;
    }

    // Update is called once per frame
    void Update() {
        if (health > maxHealth)
            health = maxHealth;

        if (health <= 0) {
            health = maxHealth;//here to stop relooping during wait
            StartCoroutine(runDeathAnimation());
        }
    }

    IEnumerator runDeathAnimation() {//needs to be ran like this in order to wait
        //run animation
        GetComponentInChildren<Animator>().SetBool("IsDead", true);
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeAll;//so they don't fall through map
        rb.detectCollisions = false;//can't collide with others
        GetComponent<SFGCharacterMotor>().enabled = false;//stop movement
        //other things might need to be done here?

        yield return new WaitForSeconds(1);// waits for 1 seconds for animation to finish

        foreach (GameObject o in deathSpawn) {//prev respawning code
            Instantiate(o, transform.position, transform.rotation);
        }
        GameObject.Find("Spawner").GetComponent<CharacterSpawner>().respawn(playerID);
        StopAllCoroutines();
        Destroy(gameObject);
    }

    public void UpdateHealth(int h) {
        health += h;

        if (myHealhBar != null)
            myHealhBar.SetHealth(health);
    }

    public void Kill() {
        health = 0;
    }

    public void setPlayerID(int input) {
        playerID = input;
    }
}