

using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float maxSpeed = 5;
	public float speed = 100f;
	public float jumpPower = 200f;


	public bool grounded;
	public bool doubleJump;

	public int currentHealth;
	public int maxHealth = 5;

	private Rigidbody rb2d;
	public Animator anim;


    // Use this for initialization
    void Start () {
		rb2d = gameObject.GetComponent<Rigidbody> ();
		currentHealth = maxHealth;
		//gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMaster> ();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Jump", !grounded);
        anim.SetFloat ("Speed", Mathf.Abs (rb2d.velocity.x));


		//turning the player

		if (Input.GetAxis ("Horizontal") < -0.1f) 
		{
			transform.localScale = new Vector3(-1,1,1);
		}

		if (Input.GetAxis ("Horizontal") > 0.1f) 
		{
			transform.localScale = new Vector3(1,1,1);
		}




        //jumping 

        if (Input.GetButtonDown("Jump"))
        {


            if (grounded)
            {

                rb2d.AddForce(Vector3.up * jumpPower);

                doubleJump = true;



            }
            else {
                if (doubleJump)
                {
                    rb2d.velocity = new Vector3(rb2d.velocity.x, 0.0f);
                    rb2d.AddForce(Vector3.up * jumpPower);
                    doubleJump = false;

                }
            }
        }

          
		
        /*
		if (currentHealth <= 0) 
		{
			Application.LoadLevel(Application.loadedLevel);
		}
        */

	}

	void FixedUpdate ()
    {

		float h = Input.GetAxis ("Horizontal");

		rb2d.AddForce (Vector2.right * speed * h);

		if (rb2d.velocity.x > maxSpeed) 
		{
			rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
		}
		if (rb2d.velocity.x < -maxSpeed) 
		{
			rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
		}
	}

	public void Damage(int dmg){

		currentHealth -= dmg;
		gameObject.GetComponent<Animation> ().Play ("Player_RedFlash");
	}

	public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir){
		float timer = 0;
		while (knockDur > timer) {
			timer += Time.deltaTime;
			rb2d.velocity = new Vector2 (0, 0);
			rb2d.AddForce(new Vector3(knockbackDir.x * -100, knockbackDir.y * knockbackPwr, transform.position.z));
		}

		yield return 0;

	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.CompareTag ("Coin")) {
			Destroy(col.gameObject);
			//gm.points++;
		}

	}

    
}