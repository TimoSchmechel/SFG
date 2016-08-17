/*
Simple Fighting Game

CharacterSpawner.cs
character spawning thingie to handle character spawning based on character selections
from a character selection screen.

Contributors:
-Matt Cabanag

*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterSpawner : MonoBehaviour
{
    //character selections per player..
    //index 0 represents player 1's selection and so on..
    //selection is index in the characterList array.
    public int [] characterSelections = new int[4];

    //list of spawnable characters.
    //what is spawned is based on characterSelections content
    public GameObject [] characterList;

    //character controllers for each player..
    //index 0 represents player 1 and so on..
    public SFGCharacterController [] characterControls;

    //life count for each player.. index rules apply ie 0 is p1, etc.
    public int [] characterLives = new int[4];

    public Transform[] spawnPoints;

    public GameObject winTree;
    public Text winnerLabel;

	// Use this for initialization
	void Start ()
    {
        if (characterControls.Length <= 0)
            characterControls = GetComponentsInChildren<SFGCharacterController>();
	    if(CharacterSelectionSettings.Instance != null)
        {
            //match selections
            characterSelections = new int[CharacterSelectionSettings.Instance.characterSelections.Length];
            for (int i = 0; i < characterSelections.Length; i++)
            {
                characterSelections[i] = CharacterSelectionSettings.Instance.characterSelections[i];
            }

            //spawn the characters! 
            SpawnCharacters();

        }else SpawnCharacters();//currently for testing purposes - Hayden
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    [ContextMenu("SpawnChars")]
    public void SpawnCharacters()
    {
        for(int i = 0; i < characterControls.Length; i++)
        {
            int charIndex = characterSelections[i];

            if(charIndex >= 0)
                SpawnCharacter(characterList[charIndex], spawnPoints[i], characterControls[i],i);
        }
    }

    public void SpawnCharacter(GameObject prefab, Transform spawnPoint, SFGCharacterController controller, int playerID)
    {
        //using int i as player id to refer back when respawning.
        //may want to set justSpawned and vunerable on characterHealth?
        GameObject newPlayerChar = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation) as GameObject;

        SFGCharacterMotor motor = newPlayerChar.GetComponent<SFGCharacterMotor>();
        SFGSpriteFlipper spriteFlipper = newPlayerChar.GetComponentInChildren<SFGSpriteFlipper>();
        CharacterHealth charHp = newPlayerChar.GetComponent<CharacterHealth>();

        if (charHp != null)//set playerID
            charHp.setPlayerID(playerID);

        if (motor != null)
            controller.myMotor = motor;

        if (spriteFlipper != null)
            spriteFlipper.myController = controller;
    }

    public void respawn(int ID)
    {
        if (characterLives[ID] > 0)
        {

            if (characterLives[ID] > 1)
                SpawnCharacter(characterList[characterSelections[ID]], spawnPoints[ID], characterControls[ID], ID);

            characterLives[ID]--;
        }
        else
        {
            Debug.Log("No more lives. Sorreh. Lel");

        }


        int winId = CheckWinner();
        Debug.Log("Check Wiiner:" + winId);

        if(winId > -1)
        {
            winTree.SetActive(true);
            winnerLabel.text = "Player " + (winId+1).ToString();
        }
    }

    public int CountLiving()
    { 
        int result = 0;

        for(int i = 0; i < characterLives.Length; i++)
        {
            if (characterLives[i] > 0)
                result++;
        }

        Debug.Log("CountLiving: " + result);
        return result;
    }

    //checks who the winning player is..
    //-1 mean so one wins
    public int CheckWinner()
    {
        int winner = -1;

        if(CountLiving() == 1)
        {
            for (int i = 0; i < characterLives.Length; i++)
            {
                if(characterLives[i] > 0)
                {
                    return i;
                }
            }
        }

        return winner;
    }
}
