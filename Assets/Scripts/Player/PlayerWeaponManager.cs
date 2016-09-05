using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerWeaponManager : MonoBehaviour
{
    //--------------------------------
    // 1 - Designer variables
    //--------------------------------

    /// <summary>
    /// Prefab du projectile
    /// </summary>
    public Transform shotPrefab;

    /// <summary>
    /// Temps de rechargement entre deux tirs
    /// </summary>
    public float shootingRate = 0.05f;

    public int shotDamages = 1;
        
    //--------------------------------
    // 2 - Rechargement
    //--------------------------------

    private float shootCooldown;

    void Start()
    {
        shootCooldown = 0f;
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }
        
    public void Attack(Vector2 dir)
    {
        if (shootCooldown <= 0f)
        {
            shootCooldown = shootingRate;

            // Création d'un objet copie du prefab
            var shotTransform = Instantiate(shotPrefab) as Transform;

            // Position
            shotTransform.position = transform.position;

            // On saisit la m_direction pour le mouvement
            ShotsManager parameters = shotTransform.gameObject.GetComponent<ShotsManager>();
            if (parameters != null)
            {
                //Debug.Log(dir);
                parameters.m_direction = dir;
            }
        }
    }

    public void Attack(Vector2 dirShot,GameObject target)
    {
        if (shootCooldown <= 0f)
        {
            shootCooldown = shootingRate;

            // Création d'un objet copie du prefab
            var shotTransform = Instantiate(shotPrefab) as Transform;

            // Position
            shotTransform.position = transform.position;

            // Propriétés du script
            ShotsManager parameters = shotTransform.gameObject.GetComponent<ShotsManager>();
            parameters.setDamage(2);

            parameters.m_target = target;
            parameters.isTracking = true;
            if (parameters != null)
            {
                parameters.m_direction = dirShot;
            }
               
        }
    }
}