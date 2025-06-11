using en.OogaBooga;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace generelt
{
    public class LOGIKK : MonoBehaviour
    {
        [SerializeField] string startScene;

        public static LOGIKK Instance;
        void Awake()
        {
            if (Instance != null)
                Destroy(gameObject);
            else
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
        }
        private void Update()
        {
            if (Input.GetButtonDown("pause"))
            {
                SceneManager.LoadScene(startScene);
            }
        }
    }
}

