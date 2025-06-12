using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tre.trn
{
    public class DrepeScript : MonoBehaviour
    {
        public GameObject kamera;
        public Transform kTransform;
        // Start is called before the first frame update
        void Start()
        {
            kamera = GameObject.FindGameObjectWithTag("MainCamera");
            kTransform = kamera.GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {
            if (kTransform.position.y > transform.position.y + 40)
            {
                Destroy(gameObject);
            }
        }
    }
}