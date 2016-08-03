/*
Simple Fighting Game

CharacterSpawner.cs
character spawning thingie to handle character spawning based on character selections
from a character selection screen.

Contributors:
-Matt Cabanag

*/

using UnityEngine;
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

    public Transform[] spawnPoints;

	// Use this for initialization
	void Start ()
    {
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

        }
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
                SpawnCharacter(characterList[charIndex], spawnPoints[i], characterControls[i]);
        }
    }

    public void SpawnCharacter(GameObject prefab, Transform spawnPoint, SFGCharacterController controller)
    {
        GameObject newPlayerChar = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation) as GameObject;

        SFGCharacterMotor motor = newPlayerChar.GetComponent<SFGCharacterMotor>();
        SFGSpriteFlipper spriteFlipper = newPlayerChar.GetComponentInChildren<SFGSpriteFlipper>();

        if (motor != null)
            controller.myMotor = motor;

        if (spriteFlipper != null)
            spriteFlipper.myController = controller;
    }
}
