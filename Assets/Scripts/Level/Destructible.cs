using UnityEngine;
using System.Collections;

public class Destructible : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other);
        if(other.GetComponent<ShotsParameters>().isEnemyShot == false)
        {
            Destroy(gameObject);
        }
    }
}
