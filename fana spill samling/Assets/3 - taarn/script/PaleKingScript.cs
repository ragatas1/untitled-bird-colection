using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tre.trn
{
    public class PaleKingScript : MonoBehaviour
    {
        public float lokasjon;
        public float storelse;
        private float startLokasjon;
        private float sluttLokasjon;
        public float fart;
        public float snurreFart;
        public bool vei;
        public float fartSkalering;
        public GameObject logikkSjef;
        public LogikkScript logikkScript;
        // Start is called before the first frame update
        void Start()
        {
            logikkSjef = GameObject.FindGameObjectWithTag("Logikk");
            logikkScript = logikkSjef.GetComponent<LogikkScript>();
            if (transform.lossyScale.x > 0)
            {
                vei = false;
            }
            else
            {
                vei = true;
            }
            transform.position = new Vector3(lokasjon, transform.position.y, transform.position.z);
            fart = logikkScript.vanskelighet * fartSkalering + 5;
        }

        // Update is called once per frame
        void Update()
        {
            if (logikkScript.pause == false)
            {
                startLokasjon = lokasjon + storelse / 2;
                sluttLokasjon = lokasjon - storelse / 2;
                if (vei == true)
                {
                    if (transform.position.x < startLokasjon)
                    {
                        transform.position = new Vector3(transform.position.x + fart * Time.deltaTime, transform.position.y, transform.position.z);
                        if (transform.lossyScale.x > 0)
                        {
                            transform.Rotate(0, 0, -snurreFart * Time.deltaTime);
                        }
                        else
                        {
                            transform.Rotate(0, 0, snurreFart * Time.deltaTime);
                        }
                    }
                    else
                    {
                        vei = false;
                    }
                }
                else if (vei == false)
                {
                    if (transform.position.x > sluttLokasjon)
                    {
                        transform.position = new Vector3(transform.position.x - fart * Time.deltaTime, transform.position.y, transform.position.z);
                        if (transform.lossyScale.x > 0)
                        {
                            transform.Rotate(0, 0, snurreFart * Time.deltaTime);
                        }
                        else
                        {
                            transform.Rotate(0, 0, -snurreFart * Time.deltaTime);
                        }
                    }
                    else
                    {
                        vei = true;
                    }

                }
            }
        }
    }
}