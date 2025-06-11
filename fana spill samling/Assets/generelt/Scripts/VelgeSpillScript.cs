using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace generelt
{
    public class VelgeSpillScript : MonoBehaviour
    {
        [SerializeField] string scene;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        private void OnMouseDown()
        {
            SceneManager.LoadScene(scene);
        }
    }
}

