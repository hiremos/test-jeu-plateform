using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class Environment : MonoBehaviour {

    private bool JoueurEnter = false;
    private float JoueurSpeed;
    private float JoueurJump;

    public float ProjectileSlow = 2;
    private Vector2 ProjectileSpeed;

    public float SpeedLose = 2;
    public float JumpBonus = 100;
    public float damageDot = 10;

    private GameObject m_player;

    // Use this for initialization
    void Start () {

        m_player = GameObject.FindGameObjectWithTag("Player");

    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.tag == "Lava" && JoueurEnter == true)
        {
            drainLife();
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            chgtPhysicsJoueur(true, other);
            JoueurEnter = true;
        }   

        if(other.tag == "Projectile")
        {
            ProjectileSpeed = other.GetComponent<ShotsMove>().GetM_speed();
            other.GetComponent<ShotsMove>().SetM_speed(new Vector2(ProjectileSpeed.x / 2, ProjectileSpeed.y / 2));
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            chgtPhysicsJoueur(false, other);
            JoueurEnter = false;
        }

        if (other.tag == "Projectile")
        {
            ProjectileSpeed = other.GetComponent<ShotsMove>().GetM_speed();
            other.GetComponent<ShotsMove>().SetM_speed(new Vector2(ProjectileSpeed.x * 2, ProjectileSpeed.y * 2));
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
        Debug.Log("Lave");
        m_player.GetComponent<HealthBar>().setDamages(damageDot);

    }
}
