using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpillerScript : MonoBehaviour
{
    public PlanetSpawner planet;
    public Transform staminaBar;
    public Rigidbody2D rb;
    public float snuFart;
    public float fart;
    float horizontal;
    float xStop;
    float yStop;
    public float hoppFrekvens;
    float hoppTimer;
    public float stoppFart;
    Animator animator;
    bool spillerMusikk = false;
    public float hvorLengeVente;
    [SerializeField] int musikkLengde;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        hoppTimer = hoppFrekvens;
    }

    // Update is called once per frame
    void Update()
    {
        rb.angularVelocity = 0;

        horizontal = Input.GetAxisRaw("Horizontal");
        transform.Rotate(0,0,-horizontal*snuFart*Time.deltaTime);
        if (Input.GetButton("l2"))
        {
            if (rb.velocity.x > 0)
            {
                xStop = xStop - (xStop / stoppFart)*Time.deltaTime;
            }
            else if (rb.velocity.x < 0)
            {
                xStop = xStop - (xStop / stoppFart)*Time.deltaTime;
            }
            if (rb.velocity.y > 0)
            {
                yStop = yStop - (yStop / stoppFart) * Time.deltaTime;
            }
            else if (rb.velocity.y < 0)
            {
                yStop = yStop - (yStop / stoppFart) * Time.deltaTime;
            }
            rb.velocity = new Vector2 (xStop,yStop);
            animator.SetBool("stopp", true);
        }
        else
        {
            xStop = rb.velocity.x;
            yStop = rb.velocity.y;
            animator.SetBool("stopp", false);
        }
        if (hoppFrekvens <= hoppTimer)
        {
            if (Input.GetButtonDown("r2"))
            {
                rb.AddForce(transform.up * fart);
                hoppTimer = 0;
                animator.SetTrigger("hoppAnimasjon");
                AudioManager.Play("hopp");
                if (spillerMusikk == false)
                {
                    spillerMusikk = true;
                    StartCoroutine(spillMusikk());
                }
            }
        } 
        else
        {
            hoppTimer = hoppTimer + 1*Time.deltaTime;
        }
        staminaBar.localScale = new Vector3 (hoppTimer/hoppFrekvens, 1, 1);
        
    }
    IEnumerator spillMusikk()
    {
        yield return new WaitForSeconds (hvorLengeVente);
        AudioManager.Play("musikk");
        yield return new WaitForSeconds (musikkLengde);
        planet.SpawnPlanet();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("ja");
        if (collision.gameObject.layer == 10)
        {
            SceneManager.LoadScene("4 - vinn");
            AudioManager.Stop("musikk");
        }
    }
}
