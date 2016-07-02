using UnityEngine;
using System.Collections;

public class DisplayCharacterSelected : MonoBehaviour {

    private string charSelected;

	// Use this for initialization
	void Start () {

	}


    public void CreateCharacter(int index)
    {
        string[] characterNames = { "Main Character", "Deer Character" };
        charSelected = characterNames[index];

        if (transform.childCount == 1)
        {
            Destroy(transform.GetChild(0).gameObject);
        }

        GameObject newChar = Instantiate(Resources.Load(charSelected) as GameObject);
        newChar.transform.parent = gameObject.transform;
        newChar.transform.position = gameObject.transform.position;
        newChar.transform.rotation = gameObject.transform.rotation;
        
    }
}
