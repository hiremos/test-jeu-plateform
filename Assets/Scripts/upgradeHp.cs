using UnityEngine;
using System.Collections;

public class upgradeHp : MonoBehaviour
{

    private GameObject m_Player;
    public GameObject healthBar;
    public GameObject upgradeHpSprite;

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
            m_Player = GameObject.FindGameObjectWithTag("Player");
            m_Player.GetComponent<HealthBar>().upgradeTotalHp();
            Destroy(upgradeHpSprite);

        }
    }
}
