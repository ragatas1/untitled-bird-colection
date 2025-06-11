using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraScript : MonoBehaviour
{
    public Transform spiller;
    public GameObject stjerne;
    public Rigidbody2D spRb;
    public float stjernetetthet;
    public float kameraTopPoint;
    public float kameraRightPoint;
    public float x;
    public float y;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (spiller.position.x,spiller.position.y,-10);
        if (spiller.position.y > y+stjernetetthet)
        {
            spawnNord();
        }
        if (spiller.position.y < y-stjernetetthet)
        {
            spawnSor();
        }
        if(spiller.position.x > x + stjernetetthet)
        {
            spawnOst();
        }
        if(spiller.position.x < x-stjernetetthet)
        {
            spawnVest();
        }
    }
    void spawnNord()
    {
        Instantiate(stjerne, new Vector3(Random.Range(transform.position.x-kameraRightPoint, transform.position.x+kameraRightPoint), transform.position.y+kameraTopPoint, 0), transform.rotation);
        y = spiller.position.y;
    }
    void spawnSor()
    {
        Instantiate(stjerne, new Vector3(Random.Range(transform.position.x - kameraRightPoint, transform.position.x + kameraRightPoint), transform.position.y - kameraTopPoint, 0), transform.rotation);
        y = spiller.position.y;
    }
    void spawnVest()
    {
        Instantiate(stjerne, new Vector3(transform.position.x - kameraRightPoint, Random.Range(transform.position.y - kameraTopPoint, transform.position.y + kameraTopPoint), 0), transform.rotation);
        x = spiller.position.x;
    }
    void spawnOst()
    {
        Instantiate(stjerne, new Vector3(transform.position.x + kameraRightPoint, Random.Range(transform.position.y - kameraTopPoint, transform.position.y + kameraTopPoint), 0), transform.rotation);
        x = spiller.position.x;
    }
}
