using UnityEngine;

public class poisonManager : MonoBehaviour {

    public Transform flaque;
    public float X = 300;
    public int damages = 1;

	// Use this for initialization
	void Start () {
        var speed = new Vector2(X, 500);
        Debug.Log(speed);
        gameObject.GetComponent<Rigidbody2D>().AddForce(speed);
    }
	
	// Update is called once per frame
	void Update () {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<HealthBar>() != null)
        {
            other.GetComponent<HealthBar>().setDamages(damages, false);
        }
        Debug.Log("op");
        Transform flaquep = Instantiate(flaque);
        flaquep.position = transform.position;
        Destroy(gameObject);
    }
}
