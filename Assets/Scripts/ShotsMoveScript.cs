using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class ShotsMoveScript : MonoBehaviour
    {

        // 1 - Designer variables
        
        private Vector2 speed = new Vector2(15, 15);
        
        private PlatformerCharacter2D m_Character;

        public Vector2 direction;

        private Vector2 movement;

        private void Start()
        {
            float rotation = 0f;
            if(direction.y == 0)
            {
                rotation = 0f;
            }
            else if(direction.y != 0 && Math.Abs(direction.x) == 0)
            {
                rotation = direction.y*90f;
            }
            else if (direction.y != 0 && Math.Abs(direction.x) == 1)
            {
                rotation = direction.y * 45f;
            }

            if(direction.x<0)
            {
                rotation = -rotation;
            }
            

            GetComponent<Rigidbody2D>().GetComponent<Transform>().Rotate(new Vector3(0, 0, rotation));
            
            if (direction.x < 0)
            {
                GetComponent<Rigidbody2D>().GetComponent<SpriteRenderer>().flipX = true;
            }
           
        }


        private void Update()
        {
            // 2 - Calcul du mouvement
            movement = new Vector2(
                speed.x * direction.x,
                speed.y * direction.y);

        }

        private void FixedUpdate()
        {
            // Application du mouvement
            GetComponent<Rigidbody2D>().velocity = movement;
        }
    }
}