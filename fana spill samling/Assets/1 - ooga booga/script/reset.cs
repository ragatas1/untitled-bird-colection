using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace en.OogaBooga
{
    public class reset : MonoBehaviour
    {
        GameObject logikk;
        LogikkScript logS;
        // Start is called before the first frame update
        void Start()
        {
            logikk = GameObject.FindGameObjectWithTag("Logikk");
            logS = logikk.GetComponent<LogikkScript>();
            //logS.res();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
