using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using Valve.VR;

public class changeClassroom : MonoBehaviour
{
    public GameObject camera;
    public int classRoomCounter;
    public bool Begun = false;
    public bool studentsInstantiated = false;
    public int
        classRoomSelector, // the "step" of the selection process
        colorSelector, // the id associated with the color chosen
        teacherSelector, // the id associated with the instructor chosen
        seatSelector, // the seat that had been taken
        studSelector; // the student group that's being used

    public Material material1, material2, material3;

    public GameObject[] cameraPositions; // for step 1
    public GameObject[] mediumChairs; // chair positions for step 3
    public GameObject[] lectureChairs;

    public TextMesh promptText; // prompt text object
    public Image LArrow; //Left Arrow UI object
    public Image RArrow; //Right Arrow UI object

    public bool customizable; //Whether the classroom parameters are customizable

    public Color color1, color2, color3, color4, color5; // different colors to change the materials

    private GameObject gameController;

    private choiceRecorder recorder;
    private viveInput vrInput;

    public GameObject teacher;

    public GameObject[] teacherPositions; // changes depending on the classRoomSelector


    private StudentFiller populator;
    private teacherChanger instructor;


    // Start is called before the first frame update

    void Start()
    {

        // load in the scripts from the gamecontroller for choice recording and vive input


        gameController = GameObject.Find("GameController");
        recorder = gameController.GetComponent<choiceRecorder>();
        vrInput = gameController.GetComponent<viveInput>();

        populator = gameController.GetComponent<StudentFiller>();
        instructor = gameController.GetComponent<teacherChanger>();

        promptText = GameObject.Find("PrompText").GetComponent<TextMesh>();
        Begun = false;
        studentsInstantiated = false;

        seatSelector = 1;

        classRoomCounter = 0; // what

        mediumChairs = GameObject.FindGameObjectsWithTag("MediumDesk");
        lectureChairs = GameObject.FindGameObjectsWithTag("LectureDesk");
        cameraPositions = GameObject.FindGameObjectsWithTag("previewPos");

        classRoomSelector = 1;

        camera.transform.position = cameraPositions[classRoomSelector - 1].transform.position;
        camera.transform.rotation = cameraPositions[classRoomSelector - 1].transform.rotation;
        promptText.text = "Press any button to begin.";

    }
    // Update is called once per frame
    public void changeText()
    {
        if (!customizable)
        {
            promptText.text = "";
            return;
        }
        switch (classRoomCounter + 1)
        {
            case (1):
                promptText.text = "Use The Touchpad To Select\n" +
         "A Classroom That You Like!\n" +
         "Press the Trigger when you\n" +
         "are finished.\n" +
         "There Are 2 Classrooms To Choose From.";
                break;
            case (2):
                promptText.text = "Use The Touchpad To Select\n" +
         "A Color That You Like!\n" +
         "Press the Trigger when you\n" +
         "are finished.\n" +
         "There Are 6 Colors To Choose From.";
                break;
            case (3):
                promptText.text = "Use The Touchpad To Select\n" +
         "Which Teacher You Like!\n" +
         "Press the Trigger when you\n" +
         "are finished.\n" +
         "There Are 4 Teachers To Choose From.";
                break;
            case (4):
                promptText.text = "Use The Touchpad To Select\n" +
                    "What Classmates You Want!\n" +
                    "Press the Trigger when you\n" +
                    "are finished.\n" +
                    "There Are 10 Different Student Combinations To Choose From.";

                break;
            case (5):
                promptText.text = "Use The Touchpad To Select\n" +
        "A Seat That You Like!\n" +
        "Press the Trigger when you\n" +
        "are finished.";
                break;
            case (6):
                promptText.text = "Lesson will begin in 20 seconds.\n" +
                    "Feel free to look around.";
                break;
            default:

                promptText.text = "";
                break;
        }
    }

    public void StartWithDefaults()
    {
        recorder.timerStart();
        recorder.choseRecord(1, classRoomSelector);
        recorder.choseRecord(2, colorSelector);
        populator.GetDesks(classRoomSelector);
        recorder.choseRecord(3, 3);
        populator.FillStudents(classRoomSelector, studSelector);
        camera.transform.position = mediumChairs[2].transform.position;
        camera.transform.rotation = mediumChairs[2].transform.rotation;
        camera.transform.Rotate(0, 90f, 0);
        camera.transform.Translate(0, 0.5f, 0);
        recorder.choseRecord(4, studSelector);
        recorder.choseRecord(5, 2);
        instructor.changeTeacher(3, 1);
        teacher = instructor.teacher;
        teacher.GetComponent<TeacherController>().startAnimation();
        //Remove arrows
        LArrow.enabled = false;
        RArrow.enabled = false;

        studentsInstantiated = true;
        StartCoroutine(WaitBeforeStart());
        //recorder.choseRecord(6);
    }

    public void stepUpdate()
    {
        // recording the selection process

        if (!customizable && !studentsInstantiated) { 
            classRoomCounter = 6;
            StartWithDefaults();
        }

        if (classRoomCounter == 0)
                recorder.timerStart();

            if (classRoomCounter == 1)
                recorder.choseRecord(classRoomCounter, classRoomSelector);

        if (classRoomCounter == 2)
        {
            recorder.choseRecord(classRoomCounter, colorSelector);
        }

        if (classRoomCounter == 3)
        {
            populator.GetDesks(classRoomSelector);
            recorder.choseRecord(classRoomCounter, teacherSelector);
            populator.FillStudents(classRoomSelector, studSelector);
        }

        if (classRoomCounter == 4)
        {
            camera.transform.position = mediumChairs[1].transform.position;
            camera.transform.rotation = mediumChairs[1].transform.rotation;
            camera.transform.Rotate(0, 90f, 0);
            camera.transform.Translate(0, 0.5f, 0);
            recorder.choseRecord(classRoomCounter, studSelector);
        }
        if (classRoomCounter == 5)
        {
            recorder.choseRecord(classRoomCounter, seatSelector);
            //Remove arrows
            LArrow.enabled = false;
            RArrow.enabled = false;
            StartCoroutine(WaitBeforeStart());
        }
        //if (classRoomCounter == 6)
        //{

          //  teacher = instructor.teacher;
          //  teacher.GetComponent<TeacherController>().startAnimation();
            

          //  recorder.choseRecord(classRoomCounter);
        //}

        classRoomCounter++;
        
    }

    private IEnumerator WaitBeforeStart()
    {
        promptText.text = "Lesson will begin in 20 seconds.\n" +
                    "Feel free to look around.";
        yield return new WaitForSeconds(20.0f);
        teacher = instructor.teacher;
        teacher.GetComponent<TeacherController>().startAnimation();

        promptText.text = "";
        Begun = true;


        recorder.choseRecord(classRoomCounter);
    }

    public void chooseOption(bool swipedRight)
    {
        //if (!customizable)
           // classRoomCounter = 6;

        switch (classRoomCounter)
        {
            case 1: // Selecting the Classroom by Changing the Camera Position

                    classRoomSelector++;
                    if (classRoomSelector > cameraPositions.Length)
                        classRoomSelector = 1;

                    camera.transform.position = cameraPositions[classRoomSelector - 1].transform.position;
                    camera.transform.rotation = cameraPositions[classRoomSelector - 1].transform.rotation;

                    teacher.transform.position = teacherPositions[classRoomSelector - 1].transform.position;
                    teacher.transform.rotation = teacherPositions[classRoomSelector - 1].transform.rotation;

                instructor.changeTeacher(teacherSelector, classRoomSelector);
                break;

            case 2: // Changing the Materials of the Classroom Walls
                
                    if (Input.GetKeyDown("right")||swipedRight)
                        colorSelector++;
                    if (Input.GetKeyDown("left")||!swipedRight)
                        colorSelector--;
                    if (colorSelector < 0)
                        colorSelector = 5;
                    if (colorSelector > 5)
                        colorSelector = 0;
                    switch (colorSelector)
                    {
                        case 1:
                            material1.color = color1;
                            material2.color = color1;
                            material3.color = color1;
                            break;
                        case 2:
                            material1.color = color2;
                            material2.color = color2;
                            material3.color = color2;
                            break;
                        case 3:
                            material1.color = color3;
                            material2.color = color3;
                            material3.color = color3;
                            break;
                        case 4:
                            material1.color = color4;
                            material2.color = color4;
                            material3.color = color4;
                            break;
                        case 5:
                            material1.color = color5;
                            material2.color = color5;
                            material3.color = color5;
                            break;
                    }
                
                break;
            case 3: // changing the instructor

                if (Input.GetKeyDown("right") || swipedRight)
                    teacherSelector++;
                if (Input.GetKeyDown("left") || !swipedRight)
                    teacherSelector--;
                if (teacherSelector < 0)
                    teacherSelector = 3;
                if (teacherSelector > 3)
                    teacherSelector = 0;

                instructor.changeTeacher(teacherSelector,classRoomSelector);

                break;
            case 4: // Changing the types of students

                // how many indexes of students should there be?
                // 1. 

                if (Input.GetKeyDown("right") || swipedRight)
                    studSelector++;
                else if (Input.GetKeyDown("left") || !swipedRight)
                    studSelector--;



                if (studSelector < 0)
                    studSelector = 9;
                else if (studSelector > 9)
                    studSelector = 0;
                //else // doesn't cause it to update when it's against an upper or lower limit
                //{
                    populator.ObliterateStudents();
                    populator.FillStudents(classRoomSelector, studSelector);
                //}


                break;

            case 5: // Changing the seating location
                
                    if (Input.GetKeyDown("right")||swipedRight)
                        seatSelector++;
                    else if (Input.GetKeyDown("left")||!swipedRight)
                        seatSelector--;
                    if (classRoomSelector == 1)
                    {
                        if (seatSelector < 0)
                            seatSelector = mediumChairs.Length-1;
                        if (seatSelector >= mediumChairs.Length)
                            seatSelector = 0;
                    }
                    if (classRoomSelector == 2)
                    {
                        if (seatSelector < 0)
                            seatSelector = lectureChairs.Length-1;
                        if (seatSelector >= lectureChairs.Length)
                            seatSelector = 0;
                    }

                    switch (classRoomSelector)
                    {
                        case 1: // seat positions if chosen the first classroom

                            camera.transform.position = mediumChairs[seatSelector].transform.position;
                            camera.transform.rotation = mediumChairs[seatSelector].transform.rotation;
                        camera.transform.Translate(0, 0.75f, 0);
                        camera.transform.Rotate(0, 90f, 0); // undoes the rotation one by the earlier thing just in case
                            break;

                        case 2: // seat positions if chosen the second classroom

                            camera.transform.position = lectureChairs[seatSelector].transform.position;
                            camera.transform.rotation = lectureChairs[seatSelector].transform.rotation;
                            // second classroom objects are prefabbed so that they face 90 degrees to the right
                            camera.transform.Rotate(0, -90f, 0);
                            camera.transform.Translate(0, -1f, 0);
                            break;
                    }
                
                break;

           
        }


            if (classRoomCounter == 1)
                recorder.switchRecord(classRoomCounter, classRoomSelector);
        else if (classRoomCounter == 2)
            recorder.switchRecord(classRoomCounter, colorSelector);
        else if (classRoomCounter == 3)
            recorder.switchRecord(classRoomCounter, teacherSelector);
        else if (classRoomCounter == 4)
            recorder.switchRecord(classRoomCounter, studSelector);
        else if (classRoomCounter == 5)
            recorder.switchRecord(classRoomCounter, seatSelector);

    }
}

