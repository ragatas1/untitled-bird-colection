using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stjernescript : MonoBehaviour
{
    public GameObject kamera;
    public Transform kameraTransform;
    public KameraScript kameraScript;
    // Start is called before the first frame update
    void Start()
    {
        kamera = GameObject.FindGameObjectWithTag("MainCamera");
        kameraTransform = kamera.transform;
        kameraScript = kamera.GetComponent<KameraScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (  transform.position.x < kameraTransform.position.x-kameraScript.kameraRightPoint 
            ||transform.position.x > kameraTransform.position.x+kameraScript.kameraRightPoint
            ||transform.position.y < kameraTransform.position.y-kameraScript.kameraTopPoint
            ||transform.position.y > kameraTransform.position.y + kameraScript.kameraTopPoint)
        {
            Destroy(gameObject);
        }
    }
}
