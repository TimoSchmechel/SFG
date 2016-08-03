using UnityEngine;
using System.Collections;

public class ShowSword : MonoBehaviour {
    private SwordThrow st;
    public GameObject sword;
    void Awake()
    {
        st = sword.GetComponent<SwordThrow>();
    }

    // Update is called once per frame
    void Update () {
        if (st.hasSword)
        {
            this.gameObject.GetComponent<Renderer>().enabled = true;
        }
        else if (!st.hasSword)
        {
            this.gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
