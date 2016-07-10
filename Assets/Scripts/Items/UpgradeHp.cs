using UnityEngine;
using System.Collections;

public class UpgradeHp : MonoBehaviour
{

    private GameObject m_Player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("collision");
            m_Player = GameObject.FindGameObjectWithTag("Player");
            m_Player.GetComponent<HealthBar>().upgradeTotalHp();
            Destroy(gameObject);
        }
    }
}
