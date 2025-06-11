using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace to.ball
{
    public class VisScoreBoardScript : MonoBehaviour
    {
        public TextMeshProUGUI forstePlass;
        public TextMeshProUGUI andrePlass;
        public TextMeshProUGUI tredjePlass;
        public TextMeshProUGUI fjerdePlass;
        public TextMeshProUGUI femtePlass;
        private void Awake()
        {
            if (PlayerPrefs.GetFloat("5Score") == 0)
            {
                ResetScore();
            }
            else
            {
                visCore();
            }
        }
        public void visCore()
        {
            forstePlass.text = PlayerPrefs.GetFloat("1Score").ToString();
            andrePlass.text = PlayerPrefs.GetFloat("2Score").ToString();
            tredjePlass.text = PlayerPrefs.GetFloat("3Score").ToString();
            fjerdePlass.text = PlayerPrefs.GetFloat("4Score").ToString();
            femtePlass.text = PlayerPrefs.GetFloat("5Score").ToString();
        }
        void ResetScore()
        {
            PlayerPrefs.SetFloat("1Score", 999);
            PlayerPrefs.SetFloat("2Score", 999);
            PlayerPrefs.SetFloat("3Score", 999);
            PlayerPrefs.SetFloat("4Score", 999);
            PlayerPrefs.SetFloat("5Score", 999);
            visCore();
        }
    }
}
