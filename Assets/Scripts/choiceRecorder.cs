
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class choiceRecorder : MonoBehaviour
{
    // loads in the gameObject CRP and the  changeClassroomScript to access the classroomcounter/choices
    public GameObject classRoomPrompt;
    public GameObject cameraObject;
    private changeClassroom cs;

    private StringBuilder sb = new StringBuilder();
    private StringBuilder rotData = new StringBuilder();
    private double elapsedTime = 0.0f;

    private long startTime;

    private IEnumerator headRotation;

    private double percentFocused;
    private int focusTicks;

    // Start is called before the first frame update
    void Start()
    {

        classRoomPrompt = GameObject.Find("[CameraRig]");
        cameraObject = GameObject.Find("Camera");
        cs = classRoomPrompt.GetComponent<changeClassroom>();

        sb.Append("System Time,Elapsed Time,Customization,Event\n");
        rotData.Append("System Time,Elapsed Time, x,y,z\n");
     

    }

    private IEnumerator getHeadRotation(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            long currentTime = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;

            rotData.Append(System.DateTime.Now.ToString() + "," + (currentTime - startTime) + ",");
            rotData.Append(cameraObject.transform.rotation.eulerAngles.x + ", " + cameraObject.transform.rotation.eulerAngles.y + ", " + cameraObject.transform.rotation.eulerAngles.z + "\n");
        }
    }

    // Update is called once per frame

    public void timerStart()
    {
        startTime = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
        headRotation = getHeadRotation(1.0f);
        StartCoroutine(headRotation);
    }

    public void choseRecord(int step)
    {
        long currentTime = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
        sb.Append(System.DateTime.Now.ToString() + "," + (currentTime - startTime) + ", Began Lesson\n");
    }

    public void choseRecord(int step, int value)
    {

        long currentTime = System.DateTime.Now.Ticks / System.TimeSpan.TicksPerMillisecond;
        sb.Append(System.DateTime.Now.ToString() + "," + (currentTime - startTime)+",");
        switch (step)
        {

            case 1:
                sb.Append(  value + ", SELECTED CLASSROOM\n");
                break;
            case 2:
                sb.Append(value + ", SELECTED COLOR\n");
                break;
            case 3:
                sb.Append(value + ", SELECTED TEACHER\n");
                break;
            case 4:
                sb.Append(value + ", SELECTED CLASSMATES\n");
                break;
            case 5:
                sb.Append(value + ", SELECTED SEAT\n");
                break;
            case 6:
                sb.Append(value + ", BEGAN LESSON\n");
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
                sb.Append(value + ", Changed Classroom\n");
                break;
            case 2:
                sb.Append(value + ", Changed Color\n");
                break;
            case 3:
                sb.Append(value + ", Changed Teacher\n");
                break;
            case 4:
                sb.Append(value + ", Changed Classmates\n");
                break;
            case 5:
                sb.Append(value + ", Changed Seating\n");
                break;
            default:
                sb.Append("\n");
                break;
        }
    }

    void OnApplicationQuit()
    {
        var currentTime = System.DateTime.Now.Ticks;
        System.IO.File.AppendAllText("Data/trialChoices-"+ currentTime + ".csv",
            sb.ToString()

            );
        System.IO.File.AppendAllText("Data/headRotationData-" + currentTime + ".csv",
            rotData.ToString()
            );
    }

}