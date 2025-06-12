using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tre.trn
{
    public class LevelSpawneScript : MonoBehaviour
    {
        private float vei;
        private float hoyde;
        public int spawneRange;
        private GameObject spawnet;
        public GameObject template;
        public GameObject sag;
        public GameObject fiende;
        public GameObject borte;
        public int hvorMangeSpawne;
        [HideInInspector] public float spawneGreier;
        // Start is called before the first frame update
        void Start()
        {
            hoyde = 0;
            vei = 1;
            spawn();
            spawn();
            spawn();
            spawn();
            spawneGreier = 0;
        }

        // Update is called once per frame
        public void spawn()
        {
            spawneRange = Random.Range(1, hvorMangeSpawne + 1);
            if (spawneRange == 1)
            {
                spawnet = template;
            }
            else if (spawneRange == 2)
            {
                spawnet = sag;
            }
            else if (spawneRange == 3)
            {
                spawnet = fiende;
            }
            else if (spawneRange == 4)
            {
                spawnet = borte;
            }
            else
            {
                Debug.Log("ops");
            }
            GameObject newObject = Instantiate(spawnet, new Vector3(0, hoyde, 0), transform.rotation);
            newObject.transform.localScale = new Vector3(vei, 1, 1);
            vei = vei * -1;
            hoyde = hoyde + 16;
            spawneGreier = spawneGreier + 1;
        }
    }
}