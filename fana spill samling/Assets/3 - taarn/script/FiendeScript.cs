using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tre.trn
{
    public class FiendeScript : MonoBehaviour
    {
        public GameObject logikkSjef;
        public LogikkScript logikkScript;
        public GameObject spiller;
        public Transform spTransform;
        private float chargeTimer;
        public float chargeTime;
        public float stoppSkalering;
        private float stopTime;
        public float maxChargeTime;
        public float skalering;
        public float chargeSpeed;
        public float deadZone;
        // Start is called before the first frame update
        void Start()
        {
            spiller = GameObject.FindGameObjectWithTag("Spiller");
            spTransform = spiller.GetComponent<Transform>();
            logikkSjef = GameObject.FindGameObjectWithTag("Logikk");
            logikkScript = logikkSjef.GetComponent<LogikkScript>();
            chargeTime = maxChargeTime - logikkScript.vanskelighet * skalering;
            stopTime = chargeTime * stoppSkalering;
            if (chargeTime < 0)
            {
                chargeSpeed = chargeSpeed - chargeTime;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (logikkScript.pause == false)
            {
                if (spTransform.position.y > transform.position.y - 1)
                    if (chargeTimer > chargeTime)
                    {
                        if (spTransform.position.x > transform.position.x + deadZone)
                        {
                            transform.position = new Vector2(transform.position.x + chargeSpeed * Time.deltaTime, transform.position.y);
                        }
                        else if (spTransform.position.x < transform.position.x - deadZone)
                        {
                            transform.position = new Vector2(transform.position.x - chargeSpeed * Time.deltaTime, transform.position.y);
                        }
                        else
                        {
                            chargeTimer = 0;
                        }
                        StartCoroutine(StopCharge());
                    }
                    else
                    {
                        chargeTimer = chargeTimer + 1 * Time.deltaTime;
                    }
            }
        }
        IEnumerator StopCharge()
        {
            if (logikkScript.pause == false)
            {
                yield return new WaitForSeconds(stopTime);
                chargeTimer = 0;
            }
        }
    }
}