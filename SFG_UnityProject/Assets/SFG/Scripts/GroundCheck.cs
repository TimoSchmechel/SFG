using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {
	private Player player;
	// Use this for initialization
	void Start () {
		player = gameObject .GetComponentInParent<Player> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider col){
		player.grounded = true;

	}

	void OnTriggerStay(Collider col){
		player.grounded = true;
	}

	void OnTriggerExit(Collider col){

		player.grounded = false;
	}
}
