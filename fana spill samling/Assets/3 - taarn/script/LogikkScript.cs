using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tre.trn
{
    public class LogikkScript : MonoBehaviour
    {
        public float vanskelighetsSkalering;
        public float vanskelighet;
        public GameObject spiller;
        private Transform spTransform;
        public LevelSpawneScript levelSpawneScript;
        public GameObject pauseSjef;
        public bool pause;
        // Start is called before the first frame update
        void Start()
        {
            spTransform = spiller.GetComponent<Transform>();
            pause = false;
        }

        // Update is called once per frame
        void Update()
        {
            vanskelighet = spTransform.position.y * vanskelighetsSkalering;
            if ((spTransform.position.y - 14 * levelSpawneScript.spawneGreier) > 14)
            {
                levelSpawneScript.spawn();
            }
        }
    }
}