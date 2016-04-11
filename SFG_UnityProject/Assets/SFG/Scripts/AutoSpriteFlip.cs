using UnityEngine;
using System.Collections;

public class AutoSpriteFlip : MonoBehaviour 
{
	private Vector3 originalScale;
	private Vector3 flipScale;

		private Vector3 prevPosition;


	// Use this for initialization
	void Start () 
	{
		originalScale = transform.localScale;
		flipScale = originalScale;
		flipScale.x *= -1;

		prevPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(prevPosition.x > transform.position.x)
		{
			transform.localScale = flipScale;
			//Debug.Log ("FLIP!");
		}


		if (prevPosition.x < transform.position.x)
		{
			transform.localScale = originalScale;


		}

		prevPosition = transform.position;
	
	}
}
