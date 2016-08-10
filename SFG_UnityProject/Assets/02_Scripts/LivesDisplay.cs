using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LivesDisplay : MonoBehaviour
{
    public CharacterSpawner mySpawner;
    public int playerID = 0;
    public Text myText;


	// Use this for initialization
	void Start ()
    {
        mySpawner = transform.root.GetComponent<CharacterSpawner>();
        myText = GetComponent<Text>();

    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(mySpawner != null)
        {
            myText.text = mySpawner.characterLives[playerID].ToString();
        }
	}
}
