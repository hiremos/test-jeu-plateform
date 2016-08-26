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
        if(other.tag!="Teleporter")
        {
            if(other.tag == "Player")
            {
                other.GetComponent<HealthBar>().setDamages(damage, false);
            }
            Destroy(gameObject);
        }
    }
}