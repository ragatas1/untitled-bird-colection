using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public GameObject Planet;
    public GameObject pil;
    [HideInInspector] public GameObject spiller;
    [HideInInspector] public SpillerScript sp;
    [HideInInspector] public Transform t;
    int hvilkenVei;
    // Start is called before the first frame update
    void Start()
    {
        spiller = GameObject.FindGameObjectWithTag("Spiller");
        sp = spiller.GetComponent<SpillerScript>();
        t = spiller.GetComponent <Transform>();
    }

    public void SpawnPlanet()
    {
        hvilkenVei = Random.Range(0, 4);
        if ( hvilkenVei == 0)
        {
            Instantiate(Planet, new Vector3(Random.Range(t.position.x + 1000, t.position.x - 1000),t.position.y+1000,-3),transform.rotation);
        }
        else if ( hvilkenVei == 1)
        {
            Instantiate(Planet, new Vector3(Random.Range(t.position.x + 1000, t.position.x - 1000), t.position.y - 1000, -3), transform.rotation);
        }
        else if( hvilkenVei == 2)
        {
            Instantiate(Planet, new Vector3(t.position.x + 1000,Random.Range( t.position.y + 1000,t.position.y - 1000), -3), transform.rotation);

        }
        else if (hvilkenVei == 3)
        {
            Instantiate(Planet, new Vector3(t.position.x - 1000, Random.Range(t.position.y + 1000, t.position.y - 1000), -3), transform.rotation);
        }
        pil.SetActive(true);
    }
}
