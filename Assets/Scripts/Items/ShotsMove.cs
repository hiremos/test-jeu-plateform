using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class ShotsMove : MonoBehaviour
    {
        private Vector2 m_speed = new Vector2(15, 15);
        
        public GameObject m_target;

        public Vector2 m_direction;

        private Vector2 m_movement;

        public double rotation = 0f;

        public bool isTracking = false;

        private void Start()
        {
            
           
        }


        private void Update()
        {
            if (isTracking && m_target != null)
            {
                updateDirection();
            }

            var rad = Math.Atan2(m_direction.y, m_direction.x); // In radians
            var angle = rad * (180 / Math.PI);

            float currentAngle = gameObject.GetComponent<Transform>().rotation.eulerAngles.z;

            if ((float)angle - currentAngle != 0)
            {
                gameObject.GetComponent<Rigidbody2D>().GetComponent<Transform>().Rotate(0, 0, (float)angle - currentAngle);
            }

            // 2 - Calcul du mouvement
            m_movement = new Vector2(
                m_speed.x * m_direction.x,
                m_speed.y * m_direction.y);
        }

        private void FixedUpdate()
        {
            // Application du mouvement
            GetComponent<Rigidbody2D>().velocity = m_movement;
        }

        private void updateDirection()
        {
            Transform shot = GetComponent<Rigidbody2D>().GetComponent<Transform>();

            Vector2 posPlayer = new Vector2(m_target.GetComponent<Transform>().position.x, m_target.GetComponent<Transform>().position.y);
            Vector2 posSource = new Vector2(shot.position.x, shot.position.y);

            //theta *= 180 / pi // rads to degs

            m_direction.x = posPlayer.x - posSource.x;
            m_direction.y = posPlayer.y - posSource.y;
            double angle = System.Math.Atan2(m_direction.y, m_direction.x);
            m_direction.x = (float)System.Math.Cos(angle);
            m_direction.y = (float)System.Math.Sin(angle);
        }

        public Vector2 GetM_speed()
        {
            return m_speed;
        }

        public void SetM_speed(Vector2 newM_speed)
        {
            m_speed = newM_speed;
        }
    }
}