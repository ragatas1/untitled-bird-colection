using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace en.OogaBooga
{
    public class LogikkScript : MonoBehaviour
    {
        [SerializeField] GameObject tekstObjekt;
        [SerializeField] TextMeshProUGUI score1Text;
        [SerializeField] TextMeshProUGUI score2Text;
        [SerializeField] TextMeshProUGUI timer;
        public AudioSource BonkSoundEffect;
        public int spiller1Score;
        public int spiller2Score;
        public int hvemLeder = 0;
        public float spiller1Tid;
        public float spiller2Tid;
        public int hvemHarStein = 0;
        public float tidPaAKaste;
        public int hvorMyeForAVinne;

        public static LogikkScript Instance;
        void Awake()
        {
            if (Instance != null)
                Destroy(gameObject);
            else
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
                BonkSoundEffect.time = 0.25f;
            }

        }
        void utAvSpill()
        {
            Destroy(gameObject);
        }
        public void leggTilScore1()
        {
            BonkSoundEffect.Play();

            spiller1Score = spiller1Score + 1;
            score1Text.text = spiller1Score.ToString();
            Debug.Log("2dø");
            hvemLeder = 1;
            nyScene();
        }
        public void leggTilScore2()
        {
            BonkSoundEffect.Play();
            spiller2Score = spiller2Score + 1;
            score2Text.text = spiller2Score.ToString();
            Debug.Log("1dø");
            hvemLeder = 2;
            nyScene();
        }
        private void Update()
        {
            if (Input.GetButtonDown("pause"))
            {
                utAvSpill();
            }
            if (hvemHarStein == 1)
            {
                spiller1Tid = Mathf.Round(spiller1Tid * 1f) * 1f;
                timer.text = spiller1Tid.ToString();
            }
            if (hvemHarStein == 2)
            {
                spiller2Tid = Mathf.Round(spiller2Tid * 1f) * 1f;
                timer.text = spiller2Tid.ToString();
            }

            if (Input.GetButton("reset"))
            {
                SceneManager.LoadScene("1 - startscene");
            }
        }
        public void nyScene()
        {

            if (spiller1Score < spiller2Score)
            {
                hvemLeder = 2;
            }
            else if (spiller1Score > spiller2Score)
            {
                hvemLeder = 1;
            }
            if (spiller1Score >= hvorMyeForAVinne)
            {
                spiller1Score = 0;
                spiller2Score = 0;
                SceneManager.LoadScene("1 - Mordi Vant");

            }
            else if (spiller2Score >= hvorMyeForAVinne)
            {
                spiller1Score = 0;
                spiller2Score = 0;
                SceneManager.LoadScene("1 - Fardi Vant");
            }
            else
            {
                StartCoroutine(LastScene());
            }
            IEnumerator LastScene()
            {
                SceneManager.LoadScene("1 - BaneForsok");

                yield return new WaitUntil(() => SceneManager.GetActiveScene() == SceneManager.GetSceneByName("1 - BaneForsok"));

                Debug.Log("finner");
                tekstObjekt = GameObject.FindGameObjectWithTag("1");
                score1Text = tekstObjekt.GetComponent<TextMeshProUGUI>();
                tekstObjekt = GameObject.FindGameObjectWithTag("2");
                score2Text = tekstObjekt.GetComponent<TextMeshProUGUI>();
                tekstObjekt = GameObject.FindGameObjectWithTag("3");
                timer = tekstObjekt.GetComponent<TextMeshProUGUI>();
                Debug.Log("fant");

                score2Text.text = spiller2Score.ToString();
                score1Text.text = spiller1Score.ToString();
            }
        }
    }
}
