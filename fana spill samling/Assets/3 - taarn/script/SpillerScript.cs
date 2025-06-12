using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace tre.trn
{
    public class SpillerScript : MonoBehaviour
    {
        public GroundCheckScript groundCheck;
        public Rigidbody2D rb;
        public float hoppeKraft;
        public float gaFart;
        private float horizontal;
        public float kameraLofteTid;
        public float kameraHoyde;
        public float tyngdekraft;
        [HideInInspector] public GameObject kamera;
        [HideInInspector] public Transform kameraPosisjon;
        private GameObject logikkSjef;
        private LogikkScript logikkScript;
        public bool uDodelig;
        public Animator animator;
        public float exitTime;
        public bool vant;
        public BoxCollider2D colider;
        // Start is called before the first frame update
        void Start()
        {
            kamera = GameObject.FindGameObjectWithTag("MainCamera");
            kameraPosisjon = kamera.GetComponent<Transform>();
            logikkSjef = GameObject.FindGameObjectWithTag("Logikk");
            logikkScript = logikkSjef.GetComponent<LogikkScript>();
            animator = GetComponent<Animator>();
            vant = false;
           // transform.position = logikkScript.spillerPosisjon;
        }

        // Update is called once per frame
        void Update()
        {
            if (vant == true)
            {
                StartCoroutine(vinn());
                transform.position = new Vector3(transform.position.x, transform.position.y - 1 * Time.deltaTime, transform.position.z);
            }
            if (logikkScript.pause == false)
            {
                horizontal = Input.GetAxisRaw("Horizontal");
                rb.velocity = new Vector2(horizontal * gaFart, rb.velocity.y);
                if (horizontal != 0)
                {
                    animator.SetBool("lop", true);
                }
                else
                {
                    animator.SetBool("lop", false);
                }
                if (groundCheck.grounded == true)
                {
                    animator.SetBool("hopp", false);
                    if (Input.GetButtonDown("Jump"))
                    {
                        rb.AddForce(transform.up * hoppeKraft * rb.gravityScale);
                    }
                    if (kameraPosisjon.position.y < transform.position.y + kameraHoyde)
                    {
                        kameraPosisjon.position = new Vector3(0, kameraPosisjon.position.y + kameraLofteTid * Time.deltaTime, -10);
                    }
                }
                else
                {
                    animator.SetBool("hopp", true);
                }


                rb.gravityScale = tyngdekraft;
                if (horizontal < 0)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else if (horizontal > 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
            else
            {
                rb.gravityScale = 0;
                rb.velocity = Vector3.zero;
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (logikkScript.pause == false)
            {
                if (collision.gameObject.layer == 6)
                {
                    if (uDodelig == false)
                    {
                        Do();
                    }
                }
            }
        }

        void Do()
        {
            SceneManager.LoadScene("3 - Bane");
        }
        IEnumerator vinn()
        {
            tyngdekraft = 0;
            Destroy(colider);
            animator.SetBool("vinn", true);
            yield return new WaitForSeconds(exitTime);
            SceneManager.LoadScene("vinn");
        }
    }
}