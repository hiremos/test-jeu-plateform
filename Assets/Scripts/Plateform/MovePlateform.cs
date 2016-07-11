using UnityEngine;
using System.Collections;

public class MovePlateform : MonoBehaviour {

    public Vector2 direction;
    public int vitesse;
    public int distanceAParcourir;
    private Vector2 m_movement;

    private Vector2 posInitial;
    private Vector2 posMax;
    //private Vector2 posMin;

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

        Debug.Log(posMax);
        Debug.Log(posInitial);

    }
	
	// Update is called once per frame
	void Update () {

        if (retour) 
        {
            m_movement = new Vector2(
                -vitesse * direction.x,
                -vitesse * direction.y);
        } else
        {
            m_movement = new Vector2(
                vitesse * direction.x,
                vitesse * direction.y);
        }
        
    }

    private void FixedUpdate()
    {
        // Application du mouvement
        if (gameObject.transform.position.x >= posMax.x && gameObject.transform.position.y >= posMax.y)
        {
            Debug.Log("gameobject pos y :"+ gameObject.transform.position.y);
            Debug.Log("posmax y :" + posMax.y);
            retour = true;
        }  

        
        if (gameObject.transform.position.x < posInitial.x || gameObject.transform.position.y < posInitial.y)
        {
            Debug.Log("gameobject pos y :" + gameObject.transform.position.y);
            Debug.Log("posinitial y :" + posInitial.y);
            retour = false;
        }
        GetComponent<Rigidbody2D>().velocity = m_movement;
    }
}
