using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeClassroom : MonoBehaviour
{
    public GameObject camera;
    public int selectionStep;
    public int 
        classRoomSelector, // the "step" of the selection process
        colorSelector, // the id associated with the color chosen
        seatSelector; // the seat that had been taken

    public Material material1, material2, material3;
    public GameObject[] cameraPositions; // for step 1
    public GameObject[] mediumChairs; // chair positions for step 3
    public GameObject[] lectureChairs;
    public TextMesh promptText; // prompt text object
    public Color color1, color2, color3, color4, color5;

    private GameObject gameController;
    private choiceRecorder recorder;

    // Start is called before the first frame update
    void Start()
    {

        gameController = GameObject.Find("GameController");
        recorder = gameController.GetComponent<choiceRecorder>();
        promptText = GameObject.Find("PrompText").GetComponent<TextMesh>();

      
        seatSelector = 1;

        selectionStep = 0;

        mediumChairs = GameObject.FindGameObjectsWithTag("MediumDesk");
        lectureChairs = GameObject.FindGameObjectsWithTag("LectureDesk");
        cameraPositions = GameObject.FindGameObjectsWithTag("previewPos");

        classRoomSelector = 1;

        promptText.text = "Press any button to begin.";
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown("space")) // The actual selection process.
        {
            if (selectionStep == 1)
                recorder.choseRecord(selectionStep, classRoomSelector);
            if (selectionStep == 2)
                recorder.choseRecord(selectionStep, colorSelector);
            if (selectionStep == 3)
                recorder.choseRecord(selectionStep, seatSelector);

            if (selectionStep >= 4)
            {
                promptText.text = "";
            }
            
            selectionStep=selectionStep++;
        }


        switch (selectionStep)
        {
            case 1: // Selecting the Classroom by Changing the Camera Position

                promptText.text = "Use The Arrow Keys To Select\n" +
          "A Classroom That You Like!\n" +
          "Press the Space Bar when you\n" +
          "are finished.";
                if (Input.GetKeyDown("right") || Input.GetKeyDown("left"))
                {
                    classRoomSelector++;
                    if (classRoomSelector > cameraPositions.Length)
                        classRoomSelector = 1;
                
                    camera.transform.position = cameraPositions[classRoomSelector-1].transform.position;
                    camera.transform.rotation = cameraPositions[classRoomSelector-1].transform.rotation;
                }
            break;

            case 2: // Changing the Materials of the Classroom Walls
                promptText.text = "Use The Arrow Keys To Select\n" +
          "A Color That You Like!\n" +
          "Press the Space Bar when you\n" +
          "are finished.";
                if (Input.GetKeyDown("right") || Input.GetKeyDown("left"))
                {
                    if (Input.GetKeyDown("right"))
                        colorSelector++;
                    if (Input.GetKeyDown("left"))
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
                }
            break;

            case 3: // Changing the seating location
                promptText.text = "Use The Arrow Keys To Select\n" +
         "A Seat That You Like!\n" +
         "Press the Space Bar when you\n" +
         "are finished.";
                if (Input.GetKeyDown("right") || Input.GetKeyDown("left"))
                {
                    if (Input.GetKeyDown("right"))
                        seatSelector++;
                    if (Input.GetKeyDown("left"))
                        seatSelector--;
                    if(classRoomSelector==1)
                    {
                        if (seatSelector < 0)
                            seatSelector = 0;
                        if (seatSelector > mediumChairs.Length)
                            seatSelector = mediumChairs.Length;
                    }
                    if (classRoomSelector == 2)
                    {
                        if (seatSelector < 0)
                            seatSelector = 0;
                        if (seatSelector > lectureChairs.Length)
                            seatSelector = lectureChairs.Length;
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
                }
                break;
        }

    }
}

