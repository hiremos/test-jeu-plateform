using UnityEngine;
using System.Collections;

public class hideWithOtherElementTrigger : MonoBehaviour {

    public GameObject trigger1;
    public GameObject trigger2;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(trigger1.GetComponent<SwapColorOnHit>().isActivate == true && trigger2.GetComponent<SwapColorOnHit>().isActivate == true)
        {
            gameObject.SetActive(false);
            Debug.Log("hide");
        } else
        {
            gameObject.SetActive(true);
            Debug.Log("visible");
        }

    }
}
