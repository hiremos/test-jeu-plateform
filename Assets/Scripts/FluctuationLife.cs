using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FluctuationLife : MonoBehaviour {

    private Vector2 speed = new Vector2(2, 2);

    private Vector2 direction = new Vector2(0,1);

    private Vector2 movement;

    // Use this for initialization
    void Start () {
        Destroy(gameObject, 1); // 3sec
    }
	
	// Update is called once per frame
	void Update () {
        // 2 - Calcul du mouvement

        movement = new Vector2(
            speed.x * direction.x,
            speed.y * direction.y);
    }

    private void FixedUpdate()
    {
        // Application du mouvement
        gameObject.GetComponent<Rigidbody2D>().velocity = movement;
    }

}
