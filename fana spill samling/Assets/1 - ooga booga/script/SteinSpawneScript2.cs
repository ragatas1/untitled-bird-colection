using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace en.OogaBooga
{
    public class SteinSpawneScript2 : MonoBehaviour
    {
        public movement2 spilleren;
        public GameObject stein;
        public BulletScript steinScript;
        void Update()
        {
            if (spilleren.harStein == true)
            {
                if (Input.GetButtonDown("Fire2"))
                {
                    lagStein();
                    spilleren.harStein = false;
                }
            }
        }
        void lagStein()
        {
            Instantiate(stein, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        }
    }
}
