using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class EnemyWeaponManager : MonoBehaviour {
    
    
    public int lockPlayer = 0;
    // Comportement des tirs
    // 0 : Direction fixe / 0 haut / -1 droite / -2 bas / -3 gauche
    // 1 : Direction sniper
    // 2 : Tete chercheuse

    private Transform m_player;
    
    private Vector2 m_direction;

    public Transform shotPrefab;

    public float shootingRate = 0.05f;

    public int shotDamages = 1;

    private float shootCooldown;

    // Use this for initialization
    void Start ()
    {
        shootCooldown = 0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
        if (shootCooldown <= 0f)
        {
            shootCooldown = shootingRate;
            if (lockPlayer <= 0)
            {

                if (lockPlayer == 0)
                {
                    Attack(new Vector2(0, 1));
                }
                if (lockPlayer == -1)
                {
                    Attack(new Vector2(1, 0));
                }
                if (lockPlayer == -2)
                {
                    Attack(new Vector2(0, -1));
                }
                if (lockPlayer == -3)
                {
                    Attack(new Vector2(-1, 0));
                }
            }
            else if (lockPlayer == 1)
            {
                tirVersJoueur(false);

            }
            else if (lockPlayer == 2)
            {
                tirVersJoueur(true);
            }
            else if(lockPlayer == 3)
            {
                poisonTir(true);
            }
        }
    }
    
    public void tirVersJoueur(bool lockJoueur)
    {
        m_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        Vector2 posPlayer = new Vector2(m_player.position.x, m_player.position.y);
        Vector2 posSource = new Vector2(transform.position.x, transform.position.y);

        //recupère la distance entre le joueur et l'objet
        float distanceJoueur = Vector2.Distance(posPlayer, posSource);
        

        m_direction.x = posPlayer.x - posSource.x;
        m_direction.y = posPlayer.y - posSource.y;

        double angle = System.Math.Atan2(m_direction.y, m_direction.x);
        m_direction.x = (float)System.Math.Cos(angle);
        m_direction.y = (float)System.Math.Sin(angle);
        
        if (distanceJoueur <= 15)
        {
            if (lockJoueur)
                Attack(m_direction, GameObject.FindGameObjectWithTag("Player"));
            else
                Attack(m_direction);
        }
    }

    public void Attack(Vector2 dir)
    {
        // Création d'un objet copie du prefab
        var shotTransform = Instantiate(shotPrefab) as Transform;

        // Position
        shotTransform.position = transform.position;

        // On saisit la m_direction pour le mouvement
        ShotsManager parameters = shotTransform.gameObject.GetComponent<ShotsManager>();
        if (parameters != null)
        {
            //Debug.Log(dir);
            parameters.m_direction = dir;
        }
    }

    public void Attack(Vector2 dirShot, GameObject target)
    {
        // Création d'un objet copie du prefab
        var shotTransform = Instantiate(shotPrefab) as Transform;

        // Position
        shotTransform.position = transform.position;

        // Propriétés du script
        ShotsManager parameters = shotTransform.gameObject.GetComponent<ShotsManager>();
        parameters.setDamage(shotDamages);

        parameters.m_target = target;
        parameters.isTracking = true;
        if (parameters != null)
        {
            parameters.m_direction = dirShot;
        }
    }

    public void poisonTir(bool toRight)
    {
        // Création d'un objet copie du prefab
        var shotTransform = Instantiate(shotPrefab) as Transform;

        // Position
        shotTransform.position = transform.position;

        
    }
}
