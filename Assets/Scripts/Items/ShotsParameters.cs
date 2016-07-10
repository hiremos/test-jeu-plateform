using UnityEngine;
using System;

/// <summary>
/// Comportement des tirs
/// </summary>
public class ShotsParameters : MonoBehaviour
{
    public string[] transparentTags;

    /// <summary>
    /// Points de dégâts infligés
    /// </summary>
    public int damage = 1;

    /// <summary>
    /// Projectile ami ou ennemi ?
    /// </summary>
    public bool isEnemyShot = false;

    void Start()
    {
        // 2 - Destruction programmée
        Destroy(gameObject, 10); // 20sec
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(isEnemyShot == true && other.tag == "Player")
        {
            HealthBar HealthPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthBar>();

            HealthPlayer.setDamages(damage);

            Destroy(gameObject);
        }

        if (null==Array.Find(transparentTags, s => s.Equals(other.tag)))
        {
            EnemyHealth hitable = other.GetComponent<EnemyHealth>();
            if (hitable != null)
            {
                hitable.takeDamage(gameObject.GetComponent<Collider2D>());
            }
            Destroy(gameObject);
        }
    }
}