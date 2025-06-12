using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tre.trn
{
    public class GroundCheckScript : MonoBehaviour
    {
        public bool grounded;
        private void OnTriggerStay2D(Collider2D collision)
        {
            grounded = true;
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            grounded = false;
        }
    }
}