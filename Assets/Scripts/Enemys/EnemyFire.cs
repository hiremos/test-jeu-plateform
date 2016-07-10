using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class EnemyFire : MonoBehaviour {

    public int lockPlayer = 0;
    // 0 : Direction fixe
    // 1 : Direction sniper
    // 2 : Tete chercheuse

    private Transform m_player;
    private Transform m_source;
    private Vector2 m_direction;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        Weapon weapon = GetComponent<Weapon>();
        if (lockPlayer == 1)
        {
            tirVersJoueur(false, weapon);

        } else if(lockPlayer <= 0)
        {
            
            if (lockPlayer == -1)
            {
                weapon.Attack(true, new Vector2(0, 1));
            }
            else
            {
                weapon.Attack(true, new Vector2(0, -1));
            }
        }
        else if (lockPlayer == 2)
        {
            tirVersJoueur(true, weapon);
        }
        else
        {

        }
        
    }
    
    public void tirVersJoueur(bool lockJoueur, Weapon weapon)
    {
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        m_source = gameObject.GetComponent<Transform>();

        Vector2 posPlayer = new Vector2(m_player.position.x, m_player.position.y);
        Vector2 posSource = new Vector2(m_source.position.x, m_source.position.y);

        //recupère la distance entre le joueur et l'objet
        float distanceJoueur = Vector2.Distance(posPlayer, posSource);
        
        //theta *= 180 / pi // rads to degs

        m_direction.x = posPlayer.x - posSource.x;
        m_direction.y = posPlayer.y - posSource.y;
        //Debug.Log("BeforeAngle:" + m_direction);
        double angle = System.Math.Atan2(m_direction.y, m_direction.x);
        m_direction.x = (float)System.Math.Cos(angle);
        m_direction.y = (float)System.Math.Sin(angle);

        //Debug.Log("First Dir:" + m_direction);

        //Debug.Log(distanceJoueur);
        if (distanceJoueur <= 15)
        {
            if (lockJoueur)
                weapon.Attack(true, m_direction, GameObject.FindGameObjectWithTag("Player"));
            else
                weapon.Attack(true, m_direction);
        }
            
    }

}
