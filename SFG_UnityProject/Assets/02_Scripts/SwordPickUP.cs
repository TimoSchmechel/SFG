using UnityEngine;
using System.Collections;

public class SwordPickUP : MonoBehaviour {
    private SwordThrow st;
    public GameObject sword;
    void Awake()
    {
        st = sword.GetComponent<SwordThrow>();
    }

    // Update is called once per frame
    void OnTriggerEnter (Collider col) {
        if (col.tag == "Player1Sword")
        {
            Destroy(col.gameObject);
            st.hasSword = true;
        }
    }
}
