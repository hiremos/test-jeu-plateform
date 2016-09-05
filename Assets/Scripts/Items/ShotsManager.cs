using UnityEngine;
using System;

/// <summary>
/// Comportement des tirs
/// </summary>
public class ShotsManager : MonoBehaviour
{
    public string[] transparentTags;
    
    public int damage;

    public float m_speed = 1;

    public GameObject m_target;

    public Vector2 m_direction;

    public double rotation = 0f;

    public bool isTracking = false;

    private Vector2 m_movement;


    void Start()
    {
        // 2 - Destruction programmée
        Destroy(gameObject, 10); // 20sec
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag!="Teleporter")
        {
            if (other.GetComponent<HealthBar>() != null)
            {
                other.GetComponent<HealthBar>().setDamages(damage, false);
            }
            if(other.GetComponent<EnemyManager>() != null)
            {
                other.GetComponent<EnemyManager>().takeDamage(damage);
            }
            Destroy(gameObject);
        }
    }

    public void setDamage(int domm)
    {
        damage = domm;
    }
    
    //-------------------------------------------------------------------------------------------
        
    private void Update()
    {
        if (isTracking && m_target != null)
        {
            updateDirection();
        }

        var rad = Math.Atan2(m_direction.y, m_direction.x); // In radians
        var angle = rad * (180 / Math.PI);

        float currentAngle = gameObject.GetComponent<Transform>().rotation.eulerAngles.z;

        if ((float)angle - currentAngle != 0)
        {
            gameObject.GetComponent<Rigidbody2D>().GetComponent<Transform>().Rotate(0, 0, (float)angle - currentAngle);
        }

        // 2 - Calcul du mouvement
        m_movement = m_direction * m_speed;
    }

    private void FixedUpdate()
    {
        // Application du mouvement
        GetComponent<Rigidbody2D>().velocity = m_movement;
    }

    private void updateDirection()
    {
        Vector2 posPlayer = new Vector2(m_target.transform.position.x, m_target.transform.position.y);
        Vector2 posSource = new Vector2(transform.position.x, transform.position.y);

        //theta *= 180 / pi // rads to degs

        m_direction.x = posPlayer.x - posSource.x;
        m_direction.y = posPlayer.y - posSource.y;
        double angle = System.Math.Atan2(m_direction.y, m_direction.x);
        m_direction.x = (float)System.Math.Cos(angle);
        m_direction.y = (float)System.Math.Sin(angle);
    }

    public float GetM_speed()
    {
        return m_speed;
    }

    public void SetM_speed(float newM_speed)
    {
        m_speed = newM_speed;
    }
}