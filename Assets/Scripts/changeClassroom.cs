using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class changeClassroom : MonoBehaviour
{
    public GameObject camera;
    public int classRoomCounter;
    public int 
        classRoomSelector, // the "step" of the selection process
        colorSelector, // the id associated with the color chosen
        seatSelector, // the seat that had been taken
        studSelector; // the student group that's being used

    public Material material1, material2, material3;

    public GameObject[] cameraPositions; // for step 1
    public GameObject[] mediumChairs; // chair positions for step 3
    public GameObject[] lectureChairs; 

    public TextMesh promptText; // prompt text object
    public Color color1, color2, color3, color4, color5;

    private GameObject gameController;
    private choiceRecorder recorder;
    private viveInput vrInput;

    public GameObject teacher;

    public GameObject[] teacherPositions; // changes depending on the classRoomSelector


    private StudentFiller populator;
    // Start is called before the first frame update
    void Start()
    {
        // load in the scripts from the gamecontroller for choice recording and vive input
        gameController = GameObject.Find("GameController");
        recorder = gameController.GetComponent<choiceRecorder>();
        vrInput = gameController.GetComponent<viveInput>();

        populator = gameController.GetComponent<StudentFiller>();

        promptText = GameObject.Find("PrompText").GetComponent<TextMesh>();

      
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
        switch(classRoomCounter+1)
        {
            case (1):
                promptText.text = "Use The Touchpad To Select\n" +
         "A Classroom That You Like!\n" +
         "Press the Trigger when you\n" +
         "are finished.";
                break;
            case (2):
                promptText.text = "Use The Touchpad To Select\n" +
         "A Color That You Like!\n" +
         "Press the Trigger when you\n" +
         "are finished.";
                break;
            case (3):
                promptText.text = "Use The Touchpad To Select\n" +
        "A Seat That You Like!\n" +
        "Press the Trigger when you\n" +
        "are finished.";
                break;
            case (4):
                promptText.text = "Use The Touchpad To Select\n" +
                    "What Classmates You Want!\n" +
                    "Press the Trigger when you\n" +
                    "are finished.";
                break;
            case (5):
                promptText.text = "Press the Trigger\n" +
                    "to begin the lesson.";
                break;
            default:

                promptText.text = "";
                break;
        }
    }

   public void stepUpdate()
    {
       // The actual selection process.
        
            if (classRoomCounter == 0)
                recorder.timerStart();
        if (classRoomCounter == 1)
            {
                populator.GetDesks(classRoomSelector);
              populator.FillStudents(classRoomSelector);
                recorder.choseRecord(classRoomCounter, classRoomSelector);
            }
            if (classRoomCounter == 2)
                recorder.choseRecord(classRoomCounter, colorSelector);
            if (classRoomCounter == 3)
                recorder.choseRecord(classRoomCounter, seatSelector);
            
            classRoomCounter++;
        
    }


    public void chooseOption(bool swipedRight)
    {

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
                break;

            case 2: // Changing the Materials of the Classroom Walls
                
                    if (Input.GetKeyDown("right")||swipedRight)
                        colorSelector++;
                    if (Input.GetKeyDown("left")||!swipedRight)
                        colorSelector--;
                    if (colorSelector < 0)
                        colorSelector = 0;
                    if (colorSelector > 5)
                        colorSelector = 5;
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

            case 3: // Changing the seating location
                
                    if (Input.GetKeyDown("right")||swipedRight)
                        seatSelector++;
                    else if (Input.GetKeyDown("left")||!swipedRight)
                        seatSelector--;
                    if (classRoomSelector == 1)
                    {
                        if (seatSelector < 0)
                            seatSelector = 0;
                        if (seatSelector >= mediumChairs.Length)
                            seatSelector = mediumChairs.Length-1;
                    }
                    if (classRoomSelector == 2)
                    {
                        if (seatSelector < 0)
                            seatSelector = 0;
                        if (seatSelector >= lectureChairs.Length)
                            seatSelector = lectureChairs.Length-1;
                    }

                    switch (classRoomSelector)
                    {
                        case 1: // seat positions if chosen the first classroom

                            camera.transform.position = mediumChairs[seatSelector].transform.position;
                            camera.transform.rotation = mediumChairs[seatSelector].transform.rotation;
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

            case 4: // Changing the types of students

                // how many indexes of students should there be?
                // 1. 

                if (Input.GetKeyDown("right") || swipedRight)
                    studSelector++;
                else if (Input.GetKeyDown("left") || !swipedRight)
                    studSelector--;

                if (studSelector < 0)
                    studSelector = 0;
                else if (studSelector > 6)
                    studSelector = 6;

                switch (classRoomSelector)
                {
                    case 1: // seat positions if chosen the first classroom

                        camera.transform.position = mediumChairs[seatSelector].transform.position;
                        camera.transform.rotation = mediumChairs[seatSelector].transform.rotation;
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
                recorder.switchRecord(classRoomCounter, seatSelector);

    }
}

