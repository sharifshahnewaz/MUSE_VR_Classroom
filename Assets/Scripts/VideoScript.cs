using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoScript : MonoBehaviour
{

    UnityEngine.Video.VideoPlayer vp;
     public float counter;
    // Start is called before the first frame update
    void Start()
    {
       
        vp = GetComponent<UnityEngine.Video.VideoPlayer>();
    }


    // Update is called once per frame
    void Update()
    {
        GameObject classRoomPrompt = GameObject.Find("[CameraRig]");
        changeClassroom cs = classRoomPrompt.GetComponent<changeClassroom>();
         counter = cs.classRoomCounter;
        if (Input.GetKeyDown(KeyCode.Space)&&counter>3)
        {
            vp.Play();
        }
        if (Input.GetKeyDown(KeyCode.P) && counter > 3)
        {
            vp.Pause();
            //vp.Stop();
        }
    }
}
