using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace to.ball
{
    public class MusicPlayer : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void spillAvMusikk()
        {
            AudioManager.Play("Music");
        }
        public void stop()
        {
            AudioManager.Stop("Music");
        }
    }
}
