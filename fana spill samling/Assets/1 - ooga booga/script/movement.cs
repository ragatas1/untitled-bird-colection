using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace en.OogaBooga
{
    public class movement : MonoBehaviour
    {
        private float horizontal;
        public float speed = 8f;
        public float jumpingPower = 16f;
        private bool isFacingRight = true;
        public int player2Score;
        public bool harStein;
        public GameObject holdeStein;
        public LogikkScript logikk;
        public GameObject LogikkSjef;
        public float spiller1Timer;

        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private AudioSource jumpSoundEffect;
        [SerializeField] private AudioSource FireSoundEffect;
        [SerializeField] private AudioSource PlukkoppSoundEffect;
        private void Start()
        {
            LogikkSjef = GameObject.FindGameObjectWithTag("Logikk");
            logikk = LogikkSjef.GetComponent<LogikkScript>();
            spiller1Timer = logikk.tidPaAKaste;
            jumpSoundEffect = GetComponent<AudioSource>();

            if (logikk.hvemLeder == 2)
            {
                harStein = true;
            }
            else
            {
                harStein = false;
            }
        }
        void Update()
        {
            horizontal = Input.GetAxisRaw("Horizontal");

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                jumpSoundEffect.Play();

                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }


            if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
            flip();
            if (harStein == true)
            {
                holdeStein.SetActive(true);
                spiller1Timer = spiller1Timer - 1 * Time.deltaTime;
                logikk.hvemHarStein = 1;
                if (Input.GetButton("Fire"))
                {
                    FireSoundEffect.Play();
                }

            }
            else
            {
                holdeStein.SetActive(false);
                spiller1Timer = logikk.tidPaAKaste;
            }
            if (spiller1Timer < 0)
            {
                Dode();
            }
            logikk.spiller1Tid = spiller1Timer;
        }
        private void FixedUpdate()
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        private bool IsGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }
        private void flip()
        {
            if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
            {

                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 7)
            {
                Dode();
            }
            if (collision.gameObject.layer == 8)
            {
                harStein = true;
                PlukkoppSoundEffect.time = 0.215f;
                PlukkoppSoundEffect.Play();
            }
        }
        private void Dode()
        {
            logikk.leggTilScore2();
        }

    }
}