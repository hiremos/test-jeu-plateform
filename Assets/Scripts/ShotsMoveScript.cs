﻿using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class ShotsMoveScript : MonoBehaviour
    {
        private Vector2 m_speed = new Vector2(15, 15);
        
        public GameObject m_target;

        public Vector2 m_direction;

        private Vector2 m_movement;

        public bool isTracking = false;

        private void Start()
        {
            
           
        }


        private void Update()
        {
            float rotation = 0f;
            if (m_direction.y == 0)
            {
                rotation = 0f;
            }
            else if (m_direction.y != 0 && m_direction.x == 0)
            {
                rotation = m_direction.y * 90f;
            }
            else if (m_direction.y != 0 && Math.Abs(m_direction.x) == 1)
            {
                rotation = m_direction.y * 45f;
            }

            if (m_direction.x == 0 && m_direction.y == -1)
            {
                rotation = -rotation;
            }

            if (m_direction.x == 1 && m_direction.y == -1)
            {
                rotation = -rotation;
            }

            if (m_direction.x == -1 && m_direction.y == 1)
            {
                rotation = -rotation;

            }

            GetComponent<Rigidbody2D>().GetComponent<Transform>().Rotate(new Vector3(0, 0, rotation));

            if (m_direction.x < 0)
            {
                GetComponent<Rigidbody2D>().GetComponent<SpriteRenderer>().flipX = true;
            }

            if (isTracking && m_target != null)
            {
                updateDirection();
                Debug.Log("up");
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
    }
}