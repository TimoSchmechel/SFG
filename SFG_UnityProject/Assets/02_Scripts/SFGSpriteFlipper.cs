using UnityEngine;
using System.Collections;

public class SFGSpriteFlipper : MonoBehaviour
{
    public SFGCharacterController myController;

    private Vector3 originalScale;
    private Vector3 flipScale;

    // Use this for initialization
    void Start ()
    {
        originalScale = transform.localScale;
        flipScale = originalScale;
        flipScale.x *= -1;

        if (myController == null)
        {
            myController = transform.root.GetComponent<SFGCharacterController>();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(myController != null)
        { 
	        if(Input.GetKeyDown(myController.leftKey))
            {
                transform.localScale = flipScale;
            }

            //assume original right facing...
            if (Input.GetKeyDown(myController.rightKey))
            {
                transform.localScale = originalScale;
            }
        }
    }
}
