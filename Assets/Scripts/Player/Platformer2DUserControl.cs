using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private GameObject m_pnj;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }
    }
}


/*
           GameObject gravity;

           gravity = GameObject.FindGameObjectWithTag("gravitynope");

           if (gravity != null)
           {
               Vector3 p = new Vector2(gravity.transform.position.x, gravity.transform.position.y);
               Vector3 size = new Vector2(gravity.transform.GetChild(0).gameObject.GetComponent<Collider2D>().bounds.size.x, gravity.transform.GetChild(0).gameObject.GetComponent<Collider2D>().bounds.size.y);


               if (m_Character.GetComponent<Rigidbody2D>().transform.position.x > p.x && m_Character.GetComponent<Rigidbody2D>().transform.position.x < p.x + size.x)
               {
                   //Debug.Log("up");
                   Physics2D.gravity = new Vector3(0f, -100f, 0f);
               }
               else
               {
                   //Debug.Log("dwn");
                   Physics2D.gravity = new Vector3(0f, -8f, 0f);
               }
           }*/
