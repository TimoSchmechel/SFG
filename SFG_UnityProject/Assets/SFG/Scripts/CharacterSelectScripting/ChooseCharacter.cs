using UnityEngine;
using System.Collections;

public class ChooseCharacter : MonoBehaviour {

    public int charIndex = 0;
    public string SetMode = "Empty";
    private int numOfCharacters = 8;//Should access a static script that contails all of the character details


    void Update()
    {
        //Controller can be selected from SetMode string
        SelectController(SetMode);
    }   
        //Controls the navigation of the character
        private void Left()
        {
            charIndex = charIndex - 1;
            if (charIndex < 0)
            {
                charIndex = numOfCharacters - 1;
            }
        }
        private void Right()
        {
            charIndex = (charIndex + 1) % numOfCharacters;
        }

        //Sets what controller will be used
        public void SelectController(string mode)
        {
            if (mode.Equals("Arrows"))
            {
                ArrowMovement();
            }
            if (mode.Equals("WASD"))
            {
                WASDMovement();
            }
        }
        //Controls the character selection with arrow keys
        private void ArrowMovement()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Left();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
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
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Right();
        }
    }
}
