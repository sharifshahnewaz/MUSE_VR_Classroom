using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class choiceRecorder : MonoBehaviour
{
    // loads in the gameObject CRP and the  changeClassroomScript to access the classroomcounter/choices
    public GameObject classRoomPrompt;
    private changeClassroom cs;
    private int counter;

    private StringBuilder sb = new StringBuilder();
    private double elapsedTime = 0.0f;

    private System.Timers.Timer aTimer = new System.Timers.Timer();
    

    // Start is called before the first frame update
    void Start()
    {
        aTimer.Interval = 1000;
        aTimer.Enabled = true;

        classRoomPrompt = GameObject.Find("[CameraRig]");
         cs = classRoomPrompt.GetComponent<changeClassroom>();

        sb.Append("System Time,Elapsed Time,Event\n");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(Input.GetKeyDown("space"))
        {
            sb.Append(System.DateTime.Now.Ticks.ToString()+","+ aTimer.Elapsed + ", Made Selection " + cs.classRoomCounter + "\n");
        }

        elapsedTime += (0.02f);
    }



    void OnApplicationQuit()
    {
        System.IO.File.AppendAllText(

            @"C:\Users\tametaj1\Desktop\Logs\" + System.DateTime.Now.Ticks.ToString() + "trialChoices.csv",
            sb.ToString()

            );
    }
}
