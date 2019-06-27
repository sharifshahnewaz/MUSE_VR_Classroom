using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeClassroom : MonoBehaviour
{
    public GameObject camera, position1, position2;
    public int classRoomCounter;
    public int classRoomSelector,
        colorSelector,
        seatSelector;
    public Material material1, material2, material3;
    public GameObject mPosition1, mPosition2, mPosition3, mPosition4, mPosition5;
    public GameObject lPosition1, lPosition2, lPosition3, lPosition4, lPosition5;

    public GameObject[] mPositions, lPositions;
    // Start is called before the first frame update
    void Start()
    {
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
                    }
                    if (classRoomSelector == 2)
                    {
                        camera.transform.position = position2.transform.position;
                        camera.transform.rotation = position1.transform.rotation;
                    }
                }
            break;

            case 2: // Changing the Materials of the Classroom Walls
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
                            material1.color = Color.green;
                            material2.color = Color.green;
                            material3.color = Color.green;
                            break;
                    }
                }
            break;

            case 3: // Changing the seating location
                if (Input.GetKeyDown("right") || Input.GetKeyDown("left"))
                {
                    if (Input.GetKeyDown("right"))
                        seatSelector++;
                    if (Input.GetKeyDown("left"))
                        seatSelector--;
                    if (seatSelector < 0)
                        seatSelector = 0;
                    if (seatSelector > 4)
                        seatSelector = 4;
                    switch (classRoomSelector) 
                    {
                        case 1: // seat positions if chosen the first classroom
                            
                                camera.transform.position = mPositions[seatSelector].transform.position;
                                camera.transform.rotation = mPositions[seatSelector].transform.rotation;
                            break;
                        case 2: // seat positions if chosen the second classroom

                            camera.transform.position = lPositions[seatSelector].transform.position;
                            camera.transform.rotation = lPositions[seatSelector].transform.rotation;
                            camera.transform.rotation = lPositions[seatSelector].transform.rotation;
                            camera.transform.Rotate(0,-90f,0);
                            break;
                    }
                }
                break;
        }
    }
}

