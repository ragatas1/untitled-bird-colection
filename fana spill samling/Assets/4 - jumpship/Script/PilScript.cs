using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilScript : MonoBehaviour
{
    public GameObject planeten;
    public Transform planet;
    [HideInInspector] public GameObject spiller;
    [HideInInspector] public SpillerScript sp;
    [HideInInspector] public Transform t;
    // Start is called before the first frame update
    void Start()
    {
        spiller = GameObject.FindGameObjectWithTag("Spiller");
        sp = spiller.GetComponent<SpillerScript>();
        t = spiller.GetComponent<Transform>();
        planeten = GameObject.FindGameObjectWithTag("planet");
        planet = planeten.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        var dir = planet.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.position = t.position;
    }
}
