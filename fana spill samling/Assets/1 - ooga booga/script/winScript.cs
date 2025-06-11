using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace en.OogaBooga
{
    public class winScript : MonoBehaviour
    {
        public float tid;
        bool ja;
        public GameObject hjelp;
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(ting());
            ja = false;
            hjelp.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (ja)
            {
                if (Input.GetButtonDown("Jump1") || Input.GetButtonDown("Jump2"))
                {
                    SceneManager.LoadScene("startscene");
                }
            }
        }
        IEnumerator ting()
        {
            yield return new WaitForSeconds(tid);
            ja = true;
            hjelp.SetActive(true);
        }
    }
}
