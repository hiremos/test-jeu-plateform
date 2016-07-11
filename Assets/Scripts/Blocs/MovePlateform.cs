using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class MovePlateform : MonoBehaviour {

    public Vector2 direction;
    public int vitesse;
    public int distanceAParcourir;
    private Vector2 m_movement;

    private Vector2 posInitial;
    private Vector2 posMax;
    //private Vector2 posMin;

    private Rigidbody2D m_player; // Si null : le joueur n'est pas sur la platerforme.

    private bool retour = false;

	// Use this for initialization
	void Start () {
        posInitial = gameObject.transform.position;

        if(direction.x != 0)
        {
            posMax = new Vector2(gameObject.transform.position.x + distanceAParcourir, 0);
            //posMin = new Vector2(gameObject.transform.position.x - distanceAParcourir, 0);
        } else
        {
            posMax = new Vector2(0, 0);
        }
        
        if(direction.y != 0)
        {
            posMax.y = gameObject.transform.position.y + distanceAParcourir;
            //posMin= new Vector2(gameObject.transform.position.y - distanceAParcourir, 0);
        }
        

    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.x >= posMax.x && gameObject.transform.position.y >= posMax.y)
        {
            retour = true;
        }
        if (gameObject.transform.position.x < posInitial.x || gameObject.transform.position.y < posInitial.y)
        {
            retour = false;
        }

        m_movement = new Vector2(
            vitesse * direction.x,
            vitesse * direction.y);

        if (retour) 
        {
            m_movement = -m_movement;
        }
    }

    private void FixedUpdate()
    {
        // Application du mouvement Debug.Log(m_player);
        GetComponent<Rigidbody2D>().velocity = m_movement;
        

    }

    void OnCollisionStay2D(Collision2D other)
    {

        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = transform;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log(other);
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
