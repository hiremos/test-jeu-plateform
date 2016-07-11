using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour {

    public GameObject teleporterSortie;
    private Vector2 positionTpSortie;
    public bool passageJoueur = true;
    public bool passageTir = false;
    //private Vector2 positionJoueur;

	// Use this for initialization
	void Start () {
        positionTpSortie = teleporterSortie.transform.position;
        positionTpSortie.y += 1;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(passageTir)
        {
            if (other.tag == "Projectile")
            {
                other.transform.position = positionTpSortie;
            }
        }

        if (passageJoueur)
        {
            if (other.tag == "Player")
                other.transform.position = positionTpSortie;
        }
    }
}
