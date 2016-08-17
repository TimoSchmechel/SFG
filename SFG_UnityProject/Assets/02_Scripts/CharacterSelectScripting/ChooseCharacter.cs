using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ChooseCharacter : MonoBehaviour {

    public int charIndex = -1;
    public int playerNumber;
    //Needs to be non-empty
    public string SetMode = "Empty";
    private int numOfC = 6;

    void Start()
    {
    }
    void Update()
    {
        MoveCamera();

        if (Input.anyKeyDown)
        {
            //Controller can be selected from SetMode string
            SelectController(SetMode);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                chooseCharacter();
            }
        }
        
    }
    
    public void chooseCharacter()
    {
        Debug.Log("Calling Character Select : " + playerNumber + "-" + charIndex);
        CharacterSelectionSettings.Instance.characterSelections[playerNumber] = charIndex;
    }

    //Controls the navigation of the character
    private void Left()
        {
            charIndex = charIndex - 1;
            if (charIndex < 0)
            {
                charIndex = numOfC - 1;
            }
        }
        private void Right()
        {
            charIndex = (charIndex + 1) % numOfC;
        }

        //Sets what controller will be used
        public void SelectController(string mode)
        {
		if (mode.Equals ("Arrows")) {
			ArrowMovement ();
		} else if (mode.Equals ("WASD")) {
			WASDMovement ();
		} else if (mode.Equals ("TFGH")) {
			TFGHMovement ();
		} else if (mode.Equals ("IJKL")) {
			IJKLMovement ();
		}
        }


        //Controls the character selection with arrow keys
        private void ArrowMovement()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Left();
            }else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Right();
            }
        }
    //Controls the character selection with WASD keys
    private void WASDMovement()
    {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Left();
            }else if (Input.GetKeyDown(KeyCode.D))
            {
                Right();
            }
    }

	//Controls the character selection with TFGH keys
	private void TFGHMovement(){
		if (Input.GetKeyDown (KeyCode.F)) {
			Left ();
		} else if (Input.GetKeyDown(KeyCode.H)) {
			Right ();
		}
	}
		

	//Controls the character selection with IJKL Keys
	private void IJKLMovement(){
		if (Input.GetKeyDown (KeyCode.J)) {
			Left ();
		} else if (Input.GetKeyDown (KeyCode.L)) {
			Right ();
		}
	}
	//Controls camera movement
    private void MoveCamera()
    {
        transform.localPosition = new Vector3(charIndex*2, 0, 0);
    }
}
