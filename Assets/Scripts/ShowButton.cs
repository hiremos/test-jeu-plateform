using UnityEngine;
using System.Collections;

public class ShowButton : MonoBehaviour {


    public Transform buttonPrefab;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("enter:"+ other.gameObject);
        if (other.tag == "TalkablePNJ")
        {
            Transform button = Instantiate(buttonPrefab) as Transform;

            button.SetParent(gameObject.transform);

            button.GetComponent<Transform>().localPosition = buttonPrefab.GetComponent<Transform>().position;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("exit");

        Destroy(gameObject.transform.GetChild(0).gameObject);
    }

}
