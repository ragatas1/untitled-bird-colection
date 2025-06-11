using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace to.ball
{
    public class WallCheckScript : MonoBehaviour
    {
        public bool iVegg;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            iVegg = true;
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            iVegg = false;
        }

    }
}