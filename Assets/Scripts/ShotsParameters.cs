﻿using UnityEngine;

/// <summary>
/// Comportement des tirs
/// </summary>
public class ShotsParameters : MonoBehaviour
{
    // 1 - Designer variables

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
        if (other.tag != "Player")
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