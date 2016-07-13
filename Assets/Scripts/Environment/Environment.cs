using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class Environment : MonoBehaviour {

    private bool JoueurEnter = false;
    private float JoueurSpeed;
    private float JoueurJump;

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
            chgtPhysics(true, other);
            JoueurEnter = true;
        }   
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            chgtPhysics(false, other);
            JoueurEnter = false;
        }
            
    }

    public void chgtPhysics(bool enter, Collider2D other)
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
