using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterHealth))]

public class HeightKiller : MonoBehaviour
{
    public float yLimit = -10;
    private CharacterHealth charHealth;

    // Use this for initialization
    void Start ()
    {
        charHealth = GetComponent<CharacterHealth>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(transform.position.y <= yLimit)
        {
            charHealth.Kill();
        }
	}
}
