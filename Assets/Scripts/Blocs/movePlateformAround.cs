using UnityEngine;
using System.Collections;

public class movePlateformAround : MonoBehaviour {

    public Vector2 distance = new Vector2(1, 1);
    public float speed = 1;
    public GameObject plateform1;
    public GameObject plateform2;
    public bool goRight = true;
    public double x = 0;
    private Vector2 m_movement;

    // Use this for initialization
    void Start () {
        plateform1.transform.position = new Vector2(gameObject.transform.position.x + distance.x, gameObject.transform.position.y);
        plateform2.transform.position = new Vector2(gameObject.transform.position.x - distance.x, gameObject.transform.position.y);

    }

    // Update is called once per frame
    void Update()
    {

        double test = interpolation_cos(0, 1, x);
        Debug.Log(plateform1.transform.position);

        //plateform1.transform.position = new Vector2((float)test + gameObject.transform.position.x, (float)test - 1 + gameObject.transform.position.y);
        m_movement = new Vector2(
            speed * (gameObject.transform.position.x + (float)test),
            speed * (gameObject.transform.position.y - 1 + (float)test));
    }


        private void FixedUpdate()
    {
        // Application du mouvement
        plateform1.GetComponent<Rigidbody2D>().velocity = m_movement;
    }

    public double interpolation_lineaire(double a, double b, double x)
    {
        return a * (1 - x) + b * x;
    }


    public double interpolation_cos(double a, double b, double x)
    {
        double k = (1 - System.Math.Cos(x * System.Math.PI)) / 2;
        return interpolation_lineaire(a, b, k);
    }

}
