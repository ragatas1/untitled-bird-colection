using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace en.OogaBooga
{
    public class StartStartScript : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            SceneManager.LoadScene("startscene");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
