using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterSelectionSettings : MonoBehaviour
{
    public static CharacterSelectionSettings Instance;

    public int [] characterSelections = new int[4];

    public string nextLevel;

    // Use this for initialization
    void Start ()
    {
        Debug.Log("Characterrasdasdasusndfbasdfasdfasdf");
        DontDestroyOnLoad(this);

        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    [ContextMenu("LoadLevel")]
    public void LoadLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
