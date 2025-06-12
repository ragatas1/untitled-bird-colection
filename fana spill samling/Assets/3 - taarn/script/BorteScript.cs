using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tre.trn
{
    public class BorteScript : MonoBehaviour
    {
        public float startStorelse;
        public float storelse;
        public float skalering;
        public GameObject logikkSjef;
        public LogikkScript logikkScript;
        // Start is called before the first frame update
        void Start()
        {
            logikkSjef = GameObject.FindGameObjectWithTag("Logikk");
            logikkScript = logikkSjef.GetComponent<LogikkScript>();
            storelse = startStorelse - logikkScript.vanskelighet * skalering;
            transform.localScale = new Vector3(storelse, 0.57f, 1);
            if (transform.localScale.x < 0)
            {
                Destroy(gameObject);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}