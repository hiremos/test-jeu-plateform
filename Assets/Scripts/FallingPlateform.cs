using UnityEngine;
using System.Collections;

public class FallingPlateform : MonoBehaviour
{
    private AudioClip sound;
    private bool hasPlayed = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {

            if (hasPlayed == false)
            {
                hasPlayed = true;
                GetComponent<AudioSource>().PlayOneShot(sound);
                gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }

        }
    }
}
