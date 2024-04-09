using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoScript : MonoBehaviour
{

    UnityEngine.Video.VideoPlayer vp;
    public float counter;
    public int key;
    public GameObject teacher;
    public bool playing;
    // Start is called before the first frame update
    void Start()
    {


        vp = GetComponent<UnityEngine.Video.VideoPlayer>();
    }

    void changeVideo(int inputVal)
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject classRoomPrompt = GameObject.Find("[CameraRig]");
        changeClassroom cs = classRoomPrompt.GetComponent<changeClassroom>();
         counter = cs.classRoomCounter;
        if (cs.Begun)
        {
            vp.Play();
            teacher = GameObject.FindGameObjectWithTag("teacher");
            if(!teacher.GetComponent<AudioSource>().isPlaying)
            teacher.GetComponent<AudioSource>().Play(0);
        }
        if (Input.GetKeyDown(KeyCode.P) && counter >6)
        {
            vp.Pause();
            if (teacher.GetComponent<AudioSource>().isPlaying)
                teacher.GetComponent<AudioSource>().Pause();
            //vp.Stop();
        }
    }
}
