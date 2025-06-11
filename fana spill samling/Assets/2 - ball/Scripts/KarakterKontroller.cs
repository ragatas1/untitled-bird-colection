using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace to.ball
{
    public class KarakterKontroller : MonoBehaviour
    {
        public float horizontal;
        private float kontrollerHorizontal;
        public Vector2 velocity;
        private Vector3 rotera;
        private float lagretHorizontal;
        public float speed;
        private float fart;
        public float topSpeed;
        public float deAkselerasjon;
        public float jumpingPower;
        private bool isFacingRight = true;
        public float luftKontroll;
        public float friction;
        public float lowerDeadZone;
        public float curentKameraPosisjon;
        public float lookUp;
        private float friksjon;
        public ScoreBoardScript score;
        public WallCheckScript wallCheck;

        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Transform groundCheck;
        [SerializeField] private LayerMask groundLayer;
        public GameObject spriten;
        public SpriteRenderer spriterender;
        public GameObject Kamera;
        public Transform kameraTransform;
        [SerializeField] private float tyngdekraft;
        [SerializeField] private float hoppeTyngdekraft;
        [SerializeField] private float bufferTid;
        [SerializeField] private float coyoteTime;
        [SerializeField] private float lookAhead;
        private float coyoteTimer;
        private bool falleTyngdkraft;
        private bool hoppe;
        public bool fullLuftKontroll;

        private void Start()
        {
            //denne finner kameraet
            Kamera = GameObject.FindGameObjectWithTag("Kamera");
            kameraTransform = Kamera.GetComponent<Transform>();
        }
        void Update()
        {
            if (velocity.x >= topSpeed || velocity.x <= -topSpeed)
            {
                spriterender.color = new(1, 1, 1, 1);
            }
            else
            {
                spriterender.color = new(0, 0, 0, 1);
            }
            if (velocity.x < 0)
            {
                rotera.z = velocity.x;
                spriten.transform.Rotate(rotera * Time.deltaTime * 10);
            }
            else if (velocity.x > 0)
            {
                rotera.z = -velocity.x;
                spriten.transform.Rotate(rotera * Time.deltaTime * 10);
            }
            spriten.transform.Rotate(rotera * Time.deltaTime * 10);
            //denne tar inn kontrollerinputet
            kontrollerHorizontal = Input.GetAxisRaw("Horizontal");

            //denne fikser luftkontroll
            if (fullLuftKontroll == false)
            {
                if (coyoteTimer > 0)
                {

                    horizontal = kontrollerHorizontal;
                    lagretHorizontal = kontrollerHorizontal;
                }
                else
                {
                    horizontal = ((kontrollerHorizontal * luftKontroll) + (lagretHorizontal / luftKontroll)) / 2;
                }
            }
            else
            {
                horizontal = kontrollerHorizontal;
            }

            //denne starter coroutinen til hoppebufring
            if (Input.GetButtonDown("Jump"))
            {
                StartCoroutine(Hoppe());
                AudioManager.Play("Jump");
            }

            //denne fikser coyote time
            if (IsGrounded())
            {
                coyoteTimer = coyoteTime;
            }
            else
            {
                coyoteTimer = coyoteTimer - 1 * Time.deltaTime;
            }

            //denne reseter velocityen n�r du treffer en vegg
            if (wallCheck.iVegg == true)
            {
                friksjon = 100000000000000;
            }
            else
            {
                friksjon = friction;
            }
            //denne hopper
            if (hoppe == true && coyoteTimer > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }

            //denne gj�r tyngedekraften annerledes n�r du pr�ver � hoppe
            if (rb.velocity.y > 0 && Input.GetButton("Jump"))
            {
                falleTyngdkraft = true;
            }
            else
            {
                falleTyngdkraft = false;
            }

            //denne endrer tyngedekraften
            if (falleTyngdkraft == true)
            {
                rb.gravityScale = hoppeTyngdekraft;
            }
            else
            {
                rb.gravityScale = tyngdekraft;
            }

            //denne fikser deadzone
            if (transform.position.y < lowerDeadZone)
            {
                Do();
            }
            curentKameraPosisjon = transform.position.y;

            //denne flytter p� kameraet
            kameraTransform.position = new Vector3(transform.position.x + lookAhead, curentKameraPosisjon, -10);

            //denne gj�r at du snur deg etter hvilken vei du g�r
            flip();

            //denne fikser bevegelse, med akselrasjon og deakselrasjon
            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                velocity.x = Mathf.MoveTowards(velocity.x, 0, friksjon * Time.deltaTime);
            }
            velocity.x += Input.GetAxisRaw("Horizontal") * fart * Time.deltaTime;
            velocity.x = Mathf.Clamp(velocity.x, -topSpeed, topSpeed);
            velocity.y = rb.velocity.y;
            rb.velocity = velocity;

            if ((velocity.x < 0 && horizontal < 0) || (velocity.x > 0 && horizontal > 0))
            {
                fart = speed;
            }
            else
            {
                fart = deAkselerasjon;
            }
        }

        //denne gj�r at du d�r n�r du kr�sjer i farelayer
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.layer == 7)
            {
                Do();
                AudioManager.Play("Die");
            }
        }
        //denne sjekker at du er p� bakken
        public bool IsGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }


        //denne flipper deg
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

        //dette er coroutinen for hoppebufring
        private IEnumerator Hoppe()
        {
            hoppe = true;
            yield return new WaitForSeconds(bufferTid);
            hoppe = false;
            coyoteTimer = 0;
        }

        //denne dreper deg
        private void Do()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}