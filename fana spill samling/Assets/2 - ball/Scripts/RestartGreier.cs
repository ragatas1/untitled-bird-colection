using generelt;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace to.ball
{
    public class RestartGreier : MonoBehaviour
    {
        public GameObject musikkSpiller;
        public MusicPlayer musikk;
        public static RestartGreier Instance;
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
        void utAvSpill()
        {
            Destroy(musikkSpiller);
            Destroy(gameObject);
        }
        
        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Jump") && SceneManager.GetActiveScene() == SceneManager.GetSceneByName("2 - scoreboard"))
            {
                musikk.spillAvMusikk();
                SceneManager.LoadScene("2 - sonic");
            }
            if (Input.GetButtonDown("reset")) 
            {
                musikk.stop();
                SceneManager.LoadScene("2 - scoreboard");
            }
            if (Input.GetButtonDown("pause"))
            {
                utAvSpill();
            }
        }
    }
}
