using UnityEngine;
using System.Collections;

public class SwordPickUP : MonoBehaviour {
    private SwordThrow st;
    private SwordID sID;

   // public GameObject swordPrefab;
    public GameObject thorw;
    void Awake()
    {
        st = thorw.GetComponent<SwordThrow>();
        //sID = swordPrefab.GetComponent<SwordID>();
    }

    // Update is called once per frame
    void OnTriggerEnter (Collider col) {
        if (col.GetComponent<SwordID>().swordid == 1)
        {
            Destroy(col.gameObject);
            st.hasSword = true;
        }
    }
}
