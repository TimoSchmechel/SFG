using UnityEngine;
using System.Collections;

public class ChooseCharacter : MonoBehaviour {

    public int charIndex = 0;
    public string SetMode = "Empty";
    private int numOfC = 2;//Should access a static script that contails all of the character details

    private DisplayCharacterSelected dChar;

    void Start()
    {
        dChar = gameObject.GetComponent<DisplayCharacterSelected>();
        dChar.CreateCharacter(charIndex);
    }
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
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Left();
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Right();
            }
            dChar.CreateCharacter(charIndex);
        }
        }
    //Controls the character selection with WASD keys
    private void WASDMovement()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Left();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Right();
            }
            dChar.CreateCharacter(charIndex);
        }
    }
}
