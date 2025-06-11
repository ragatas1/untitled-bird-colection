using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace en.OogaBooga
{
    public class BulletScript : MonoBehaviour
    {
        public Rigidbody2D steinenSinRigidBody;
        public float kasteFart;
        public SpriteRenderer steinSprite;
        void Awake()
        {
            gameObject.layer = 7;
            steinSprite.color = new Color(1, 0, 0, 1);
            steinenSinRigidBody.AddForce(transform.up * kasteFart);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer != 3)
            {
                gameObject.layer = 8;
                steinSprite.color = new Color(0, 0, 0, 1);
            }
            else
            {
                if (gameObject.layer == 8)
                {
                    Destroy(gameObject);
                }
            }
        }

    }
}
