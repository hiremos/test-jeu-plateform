using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class EnemyFireScript : MonoBehaviour {

    public bool lockPlayer = false;
    private Transform m_player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        WeaponScript weapon = GetComponent<WeaponScript>();
        if (lockPlayer)
        {
            m_player = GameObject.FindGameObjectWithTag("Player").transform;

            double posx = System.Convert.ToDouble(m_player.position.x);
            double posy = System.Convert.ToDouble(m_player.position.y);

            Debug.Log(posx);
            Debug.Log(posy);

            weapon.Attack(true, new Vector2((float)System.Math.Cos(posx), (float)System.Math.Cos(posy)));
        } else
        {
            weapon.Attack(true, new Vector2(0, -1));
        }
        
    }


}
