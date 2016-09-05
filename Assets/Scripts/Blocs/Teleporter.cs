using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class Teleporter : MonoBehaviour {

    public GameObject teleporterSortie;
    private Vector2 positionTpSortie;
    public bool passageJoueur = true;
    public bool passageTir = false;
    public Vector2 DirectionSortie;

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
                if(!(DirectionSortie.x ==0 && DirectionSortie.y==0))
                {
                    other.GetComponent<ShotsManager>().m_direction = DirectionSortie;
                }
            }
        }

        if (passageJoueur)
        {
            if (other.tag == "Player")
                other.transform.position = positionTpSortie;
        }
    }
}
