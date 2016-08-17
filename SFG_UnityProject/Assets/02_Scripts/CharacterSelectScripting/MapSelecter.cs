using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapSelecter : MonoBehaviour {

    public Sprite[] imgs;
    public string[] levels = { "Map Forest", "Map Rooftop Alley", "Map Space", "Map Train", "Map Volcano" };
    private int index = 0;

    private Image imageBoard;
	// Use this for initialization
	void Start () {
        imageBoard = GameObject.Find("Image").GetComponent<Image>();
        imageBoard.sprite = imgs[index];
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Left();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Right();
        }
    }

    public void confirm()
    {
        //load selected level
        SceneManager.LoadScene(levels[index]);
    }
    public void back()
    {
        //go back to main menu???
        SceneManager.LoadScene("MainMenu Canvas");
    }

    public void Left()
    {
        if(index == 0)
        {
            index = imgs.Length;
        }else
        {
            index--;
        }
        imageBoard.sprite = imgs[index];
    }

    public void Right()
    {
        if (index == imgs.Length)
        {
            index = 0;
        }
        else
        {
            index++;
        }
        imageBoard.sprite = imgs[index];
    }
}
