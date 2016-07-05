using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class PlayerFireInput : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

            GameObject joueur;

            joueur = GameObject.FindGameObjectWithTag("Player");

            bool m_FacingRight = joueur.GetComponent<PlatformerCharacter2D>().isFacingRight();
            // 5 - Tir
            float shootx = 0;
            float shooty = 0;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                shooty = 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                shooty = -1;
            }
            if (Input.GetKey(KeyCode.RightArrow) && m_FacingRight == true)
            {
                shootx = 1;
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && m_FacingRight == false)
            {
                shootx = -1;
            }

            if (shootx != 0 || shooty != 0)
            {
                WeaponScript weapon = GetComponent<WeaponScript>();
                if (weapon != null)
                {
                    // false : le joueur n'est pas un ennemi
                    weapon.Attack(false,new Vector2(shootx,shooty));
                }
            }
        }
    }
}