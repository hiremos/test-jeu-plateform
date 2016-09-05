using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class Environment : MonoBehaviour {

    private int deltaTime = 0;
    private bool JoueurEnter = false;
    private float JoueurSpeed;
    private float JoueurJump;

    public float ProjectileSlow = 2;
    private Vector2 ProjectileSpeed;

    public float SpeedLose = 2;
    public float JumpBonus = 100;
    public float damageDot = 10;

    public GameObject airBar;

    private GameObject m_player;

    // Use this for initialization
    void Start () {

        m_player = GameObject.FindGameObjectWithTag("Player");

        airBar.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.tag == "Lava" && JoueurEnter == true)
        {
            
            if (deltaTime == 60)
            {
                drainLife();

                m_player.GetComponent<AirBar>().loseOxygen();

                deltaTime = 0;

            }
            deltaTime += 1;
        }

        if (gameObject.tag == "Water" && JoueurEnter == true)
        {
            if(deltaTime == 60)
            {
                m_player.GetComponent<AirBar>().loseOxygen();

                deltaTime = 0;
            }
            deltaTime += 1;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            airBar.SetActive(true);
            chgtPhysicsJoueur(true, other);
            JoueurEnter = true;
        }   

        if(other.tag == "Projectile")
        {
            other.GetComponent<ShotsManager>().SetM_speed(other.GetComponent<ShotsManager>().GetM_speed() / 2);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            airBar.SetActive(false);
            chgtPhysicsJoueur(false, other);
            JoueurEnter = false;
            m_player.GetComponent<AirBar>().resetAir();
        }

        if (other.tag == "Projectile")
        {
            other.GetComponent<ShotsManager>().SetM_speed(other.GetComponent<ShotsManager>().GetM_speed() * 2);
        }

    }

    public void chgtPhysicsJoueur(bool enter, Collider2D other)
    {
        if (enter)
        {
            JoueurSpeed = other.GetComponent<PlatformerCharacter2D>().GetMaxSpeed();
            JoueurJump = other.GetComponent<PlatformerCharacter2D>().GetJumpForce();

            other.GetComponent<PlatformerCharacter2D>().SetJumpForce(JoueurJump + JumpBonus);
            other.GetComponent<PlatformerCharacter2D>().SetMaxSpeed(JoueurSpeed / SpeedLose);
        } else
        {
            JoueurSpeed = other.GetComponent<PlatformerCharacter2D>().GetMaxSpeed();
            JoueurJump = other.GetComponent<PlatformerCharacter2D>().GetJumpForce();

            other.GetComponent<PlatformerCharacter2D>().SetJumpForce(JoueurJump - JumpBonus);
            other.GetComponent<PlatformerCharacter2D>().SetMaxSpeed(JoueurSpeed * SpeedLose);
        }
    }

    public void drainLife()
    {
        m_player.GetComponent<HealthBar>().setDamages(damageDot,false);
    }
}
