using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

    public int maxHealth = 5;
    public GameObject notch;
    public int offset = 25;

    public int playerID = 0;

    private GameObject[] notches;

    // Use this for initialization
    void Start()
    {
        notches = new GameObject[maxHealth];
        notches[0] = notch;//initial notch
        for (int i = 1; i < maxHealth; i++)
        {
            notches[i] = GameObject.Instantiate(notches[i - 1]); //copies the prior notch
            notches[i].transform.SetParent(gameObject.transform);

            //changes the position of the copy to right next to the original
            notches[i].GetComponent<RectTransform>().anchoredPosition = notches[i - 1].GetComponent<RectTransform>().anchoredPosition + new Vector2(offset, 0);
        }
    }

    //This updates the health bar
    public void SetHealth(int health)
    {
        for (int i = 0; i < notches.Length; i++)
        {
            notches[i].SetActive(i < health);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {

    }
}
