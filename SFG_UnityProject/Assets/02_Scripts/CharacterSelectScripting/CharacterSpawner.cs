using UnityEngine;
using System.Collections;

public class CharacterSpawner : MonoBehaviour
{
    [System.Serializable]
    public class SpawnSettings
    {
        public int [] characterSelections = new int[4];
    }
    public SpawnSettings spawnSettings;

    public GameObject[] CharacterList;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
