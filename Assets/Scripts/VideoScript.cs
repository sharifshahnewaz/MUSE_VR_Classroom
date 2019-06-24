using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoScript : MonoBehaviour
{

    UnityEngine.Video.VideoPlayer vp;


    // Start is called before the first frame update
    void Start()
    {
        vp = GetComponent<UnityEngine.Video.VideoPlayer>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            vp.Play();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            vp.Pause();
            //vp.Stop();
        }
    }
}
