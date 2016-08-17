using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterSelectController : MonoBehaviour {

	//Handles the character select screen

	//Go To Main Menu
	public void MainMenu(){
		SceneManager.LoadScene ("MainMenu Canvas");
	}
}
