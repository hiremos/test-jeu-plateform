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
            if(!canMove)
            {
                m_Character.Move(0, false, false);
                return;
            }
            // Read the inputs.
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }

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

            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");

            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            if((directionx != 0 || directiony != 0))
            {
                m_Character.Fire(directionx, directiony);
            }

            directionx = 0;
            directiony = 0;
            m_Jump = false;
        }
    }
}
