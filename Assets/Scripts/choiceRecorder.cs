using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choiceRecorder : MonoBehaviour
{
    // loads in the gameObject CRP and the  changeClassroomScript to access the classroomcounter/choices
    public GameObject classRoomPrompt;
    private changeClassroom cs;
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        GameObject classRoomPrompt = GameObject.Find("[CameraRig]");
        changeClassroom cs = classRoomPrompt.GetComponent<changeClassroom>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        counter = cs.classRoomCounter;
        if (counter==4)
        {
        }

        string[] choices = { "First line", "Second line", "Third line" };
        System.IO.File.WriteAllLines(@"C:\Users\tametaj1\Desktop\Logs\trialChoices.txt", choices);
    }
}
