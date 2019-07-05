
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class choiceRecorder : MonoBehaviour
{
    // loads in the gameObject CRP and the  changeClassroomScript to access the classroomcounter/choices
    public GameObject classRoomPrompt;
    private changeClassroom cs;

    private StringBuilder sb = new StringBuilder();
    private double elapsedTime = 0.0f;

    private long startTime;
    // Start is called before the first frame update
    void Start()
    {

        classRoomPrompt = GameObject.Find("[CameraRig]");
        cs = classRoomPrompt.GetComponent<changeClassroom>();

        sb.Append("System Time,Elapsed Time,Customization,Event\n");
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
     
    }
    public void timerStart()
    {
        startTime = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
    }
    public void choseRecord(int step, int value)
    {

        long currentTime = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
        sb.Append(System.DateTime.Now.ToString() + "," + (currentTime - startTime)+",");
        switch (step)
        {

            case 1:
                sb.Append(  value + ", Chose Classroom\n");
                break;
            case 2:
                sb.Append(value + ", Chose Color\n");
                break;
            case 3:
                sb.Append(value + ", Chose Seating\n");
                break;
            default:
                sb.Append("\n");
                break;
        }

    }

    public void switchRecord(int step, int value)
    {
        long currentTime = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;

        sb.Append(System.DateTime.Now.ToString() + "," + (currentTime - startTime) + ",");
        switch (step)
        {

            case 1:
                sb.Append(value + ", Switched Classroom\n");
                break;
            case 2:
                sb.Append(value + ", Switched Color\n");
                break;
            case 3:
                sb.Append(value + ", Switched Seating\n");
                break;
            default:
                sb.Append("\n");
                break;
        }
    }

    void OnApplicationQuit()
    {
        System.IO.File.AppendAllText("Data/trialChoices-"+ System.DateTime.Now.Ticks + ".csv",
            sb.ToString()

            );
    }
}