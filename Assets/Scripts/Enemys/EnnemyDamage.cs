using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class EnnemyDamage : MonoBehaviour {

    private GameObject m_Player;
    public GameObject healthBar;
    
    public float damage;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        //BUMPS a opti :)
        if (other.tag == "Player" && !other.GetComponent<PlatformerCharacter2D>().isGrounded())
        {
            other.GetComponent<PlatformerCharacter2D>().jump(200f);
            Destroy(gameObject);
        }
        else if (other.tag == "Player")
        {
            m_Player = GameObject.FindGameObjectWithTag("Player");
            m_Player.GetComponent<HealthBar>().setDamages(damage,true);
        }
    }

}
