using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeClassroom : MonoBehaviour
{
    public GameObject camera, position1, position2;
    public int classRoomCounter = 1;
    public int classRoomSelector,
        colorSelector,
        seatSelector;
    public Material material1, material2, material3;
    public GameObject mPosition1, mPosition2, mPosition3, mPosition4, mPosition5;
    public GameObject lPosition1, lPosition2, lPosition3, lPosition4, lPosition5;

    public GameObject[] mPositions, lPositions;


    public TextMesh promptText; // prompt text object
    // Start is called before the first frame update
    void Start()
    {
        promptText = GameObject.Find("PrompText").GetComponent<TextMesh>();

        promptText.text = "Use The Arrow Keys To Select\n" +
            "A Classroom That You Like!\n" +
            "Press the Space Bar when you\n" +
            "are finished.";
        classRoomCounter = 1;
        seatSelector = 1;
    }

    // Update is called once per frame
    void Update()
    {

        GameObject[] mPositions = new GameObject[]{ mPosition1, mPosition2, mPosition3, mPosition4, mPosition5 };
        GameObject[] lPositions = new GameObject[]{ lPosition1, lPosition2, lPosition3, lPosition4, lPosition5 };
        if (Input.GetKeyDown("space")) // The actual selection process.
            classRoomCounter++;
        if (classRoomCounter > 3)
            promptText.text = "";
        
        switch (classRoomCounter)
        {
            case 1: // Selecting the Classroom by Changing the Camera Position
                if (Input.GetKeyDown("right") || Input.GetKeyDown("left"))
                {
                    classRoomSelector++;
                    if (classRoomSelector > 2)
                        classRoomSelector = 1;

                    if (classRoomSelector == 1)
                    {
                        camera.transform.position = position1.transform.position;
                        camera.transform.rotation = position1.transform.rotation;
                        camera.transform.Rotate(0, 90f, 0);
                    }
                    if (classRoomSelector == 2)
                    {
                        camera.transform.position = position2.transform.position;
                        camera.transform.rotation = position1.transform.rotation;
                    }
                }
            break;

            case 2: // Changing the Materials of the Classroom Walls
                promptText.text = "Use The Arrow Keys To Select\n" +
          "A Color That You Like!\n" +
          "Press the Space Bar when you\n" +
          "are finished.";
                if (Input.GetKeyDown("right") || Input.GetKeyDown("left"))
                {
                    Color color1 = new Color(255f, 255f, 255f);
                    Color color2 = new Color(255f, 255f, 255f);
                    Color color3 = new Color(255f, 255f, 255f);
                    Color color4 = new Color(255f, 255f, 255f);
                    Color color5 = new Color(255f, 255f, 255f);
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
                            material1.color = Color.white;
                            material2.color = Color.white;
                            material3.color = Color.white;
                            break;
                        case 2:
                            material1.color = Color.black;
                            material2.color = Color.black;
                            material3.color = Color.black;
                            break;
                        case 3:
                            material1.color = Color.red;
                            material2.color = Color.red;
                            material3.color = Color.red;
                            break;
                        case 4:
                            material1.color = Color.blue;
                            material2.color = Color.blue;
                            material3.color = Color.blue;
                            break;
                        case 5:
                            material1.color = Color.magenta;
                            material2.color = Color.magenta;
                            material3.color = Color.magenta;
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
                    if (seatSelector < 0) // selection between the five total choices for the classroom seating positions
                        seatSelector = 0;
                    if (seatSelector > 4)
                        seatSelector = 4;
                    switch (classRoomSelector) 
                    {
                        case 1: // seat positions if chosen the first classroom
                            
                                camera.transform.position = mPositions[seatSelector].transform.position;
                                camera.transform.rotation = mPositions[seatSelector].transform.rotation;
                            camera.transform.Rotate(0, 90f, 0);
                            break;
                        case 2: // seat positions if chosen the second classroom

                            camera.transform.position = lPositions[seatSelector].transform.position;
                            camera.transform.rotation = lPositions[seatSelector].transform.rotation;
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

