using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class WeaponScript : MonoBehaviour
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

        //--------------------------------
        // 3 - Tirer depuis un autre script
        //--------------------------------

        /// <summary>
        /// Création d'un projectile si possible
        /// </summary>
        public void Attack(bool isEnemy, Vector2 dir)
        {
            if (CanAttack)
            {
                shootCooldown = shootingRate;

                // Création d'un objet copie du prefab
                var shotTransform = Instantiate(shotPrefab) as Transform;

                // Position
                shotTransform.position = transform.position;

                // Propriétés du script
                ShotsParameters shot = shotTransform.gameObject.GetComponent<ShotsParameters>();
                if (shot != null)
                {
                    shot.isEnemyShot = isEnemy;
                }
                // On saisit la m_direction pour le mouvement
                ShotsMoveScript move = shotTransform.gameObject.GetComponent<ShotsMoveScript>();
                if (move != null)
                {
                    //Debug.Log(dir);
                    move.m_direction = dir;
                }
            }
        }

        public void Attack(bool isEnemy, Vector2 dirShot,GameObject target)
        {
            if (CanAttack)
            {
                shootCooldown = shootingRate;

                // Création d'un objet copie du prefab
                var shotTransform = Instantiate(shotPrefab) as Transform;

                // Position
                shotTransform.position = transform.position;

                // Propriétés du script
                ShotsParameters shot = shotTransform.gameObject.GetComponent<ShotsParameters>();
                if (shot != null)
                {
                    shot.isEnemyShot = isEnemy;
                }
                // On saisit la m_direction pour le mouvement
                ShotsMoveScript move = shotTransform.gameObject.GetComponent<ShotsMoveScript>();
                move.m_target = target;
                move.isTracking = true;
                if (move != null)
                {
                    //Debug.Log(dir);
                    move.m_direction = dirShot;
                }
            }
        }

        /// <summary>
        /// L'arme est chargée ?
        /// </summary>
        public bool CanAttack
        {
            get
            {
                return shootCooldown <= 0f;
            }
        }
    }
}