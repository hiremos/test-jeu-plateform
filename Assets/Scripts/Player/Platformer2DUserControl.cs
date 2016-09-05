using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private GameObject m_pnj;
        private int directionx = 0;
        private int directiony = 0;
        public bool canMove;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }

        private void Update()
        {
            //Si le joueur ne doit pas interagir, on bloque toutes lecture d'input.
            if(!canMove)
            {
                m_Character.Move(0, false, false);
                return;
            }
            
            //Lecture input pour jump(ESPACE)
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }

            //Lecture inputs pour tirs (Fleches directionelles)
            if (Input.GetKey(KeyCode.UpArrow))
            {
                directiony = 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                directiony = -1;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                directionx = 1;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                directionx = -1;
            }

            //Lecture input pour s'accroupir (CTRL Gauche)
            bool crouch = Input.GetKey(KeyCode.LeftControl);

            //Lecture input pour marcher (Lecture de la direction sur l'axe horizontal(Q ou D)
            float h = CrossPlatformInputManager.GetAxis("Horizontal");

            // On envoie tous les parametres lus precedement au script de controle du personnage.
            m_Character.Move(h, crouch, m_Jump);

            if((directionx != 0 || directiony != 0))
            {
                m_Character.Fire(directionx, directiony);
            }

            // On reset les variables pour lire l'input suivante.
            directionx = 0;
            directiony = 0;
            m_Jump = false;
        }
    }
}
