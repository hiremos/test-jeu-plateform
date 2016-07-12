using UnityEngine;
using System.Collections;

public class movePlateformAround : MonoBehaviour {

    public float distance;
    public float speed;
    public GameObject plateform1;
    public GameObject plateform2;
    public bool goRight = true;

	// Use this for initialization
	void Start () {
        plateform1.transform.position = new Vector2(gameObject.transform.position.x + distance, gameObject.transform.position.y);
        plateform1.transform.position = new Vector2(gameObject.transform.position.x - distance, gameObject.transform.position.y);

    }

    // Update is called once per frame
    void Update () {
        
	}
}
