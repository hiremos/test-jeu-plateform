using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class EnemyFireScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        WeaponScript weapon = GetComponent<WeaponScript>();
        weapon.Attack(true, new Vector2(0, -1));
    }


}
