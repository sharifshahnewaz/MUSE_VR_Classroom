using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentFiller : MonoBehaviour
{

    // 1 : identify the classroom that the user has chosen by using the variable in classroomChanger.
    // should we use one tag across both classrooms or classroom specific tags? let's go with the latter.
    // 2 : identify the suitable chairs that the populator can fill by using tags on the prefabs.
    // 3 : create several indexes for the kinds of student populations that can be used to fill in the classroom.
    // 4 : instantialize objects in a specific animation at the desires spots. transform based on what model is currently being used (black male model needs to be lowered more than female black model).
    // 5 : ???.
    // 6 : profit.

    public  GameObject[] studentSeats;
    public GameObject[] students;
    // Start is called before the first frame update
    void Start()
    {
    }

 public void GetDesks(int classroom)
    { // step 1. pass in the tag needed to get the students
        string targetTag;
        switch(classroom)
        {
            case 1:
                targetTag = "MediumStud";
                break;
            case 2:
                targetTag = "LectureStud";
                break;
            default:
                targetTag = "MediumStud";
                break;
        }

        studentSeats = GameObject.FindGameObjectsWithTag(targetTag);

    }
    private void Update()
    {
    }
    // Update is called once per frame
    public void FillStudents(int classroom)
    {
        switch(classroom)
        {
            case 1:

                for (int i = 0; i < studentSeats.Length; i++)
                {
                   
                    GameObject go = (GameObject)Instantiate(
                        students[UnityEngine.Random.Range(0, 8)],
                        studentSeats[i].transform.position,
                        studentSeats[i].transform.rotation);
                        go.transform.Rotate(0f,180f,0f);
                        go.transform.Translate(0f, 0.125f, -0.375f);
                }
                break;
            case 2:


                for (int i = 0; i < studentSeats.Length; i++)
                {
                    GameObject go = (GameObject)Instantiate(
                         students[UnityEngine.Random.Range(0, 8)],
                        studentSeats[i].transform.position,
                        studentSeats[i].transform.rotation);
                    go.transform.Translate(0f, -0.4f,0.125f, Space.Self);
                }
                break;
        }
    }
}
