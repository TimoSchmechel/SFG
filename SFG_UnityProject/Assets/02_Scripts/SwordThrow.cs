using UnityEngine;
using System.Collections;

public class SwordThrow : MonoBehaviour {
    public Rigidbody sword;
    public float speed = 30f;
    public bool hasSword = true;
    public KeyCode throwKey = KeyCode.E;
    public GameObject facing;

    private SFGSpriteFlipper sf;

    // Use this for initialization
    void Awake () {
        sf = facing.GetComponent<SFGSpriteFlipper>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(throwKey) && hasSword)
        {
            if (sf.facingRight)
            {
                hasSword = false;
                Rigidbody spawnSword = Instantiate(sword, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody;
                //spawnSword.velocity = new Vector3(speed, 0,0);
                spawnSword.AddForce(new Vector3(speed, 0, 0));
                
                Debug.Log("hasSword: "+hasSword);
            }else
            {
                hasSword = false;
                Rigidbody spawnSword = Instantiate(sword, transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) as Rigidbody;
                //spawnSword.velocity = new Vector3(-speed, 0, 0);
                spawnSword.AddForce(new Vector3(-speed, 0, 0));
            }
        }
	}
}
