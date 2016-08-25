using UnityEngine;
using System.Collections;

public class ShowButton : MonoBehaviour {
    
    public Transform buttonPrefab;

    private bool canTalk;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "TalkablePNJ" && canTalk == false)
        {
            Transform button = Instantiate(buttonPrefab) as Transform;

            button.SetParent(gameObject.transform);

            button.GetComponent<Transform>().localPosition = buttonPrefab.GetComponent<Transform>().position;

            canTalk = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "TalkablePNJ" && canTalk == true)
        {
            Destroy(gameObject.transform.GetChild(0).gameObject);

            canTalk = false;
        }
    }
    
}
