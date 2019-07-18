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

    public  GameObject[] studentSeats; // the positions of the seats
    public GameObject[] studentPrefabs; // the prefabs of each of the student models
    public GameObject[] classMates; // the actual student objects created
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
        classMates = new GameObject[studentSeats.Length];
    }
    private void Update()
    {
       print(UnityEngine.Random.Range(0, 2));
    }

    public void ObliterateStudents()
    {
        foreach (GameObject student in classMates)
            Destroy(student);
        
    }
    // Update is called once per frame

        // indexes of student population have been created. now return a number to designate the appropriate student type
    private int getStudFromIndex(int index)
    {
        int studentId = 0;
        switch(index)
        {
            case 0: // aa
                studentId = UnityEngine.Random.Range(0, 8);
                break;
            case 1: // wa
                studentId = UnityEngine.Random.Range(4, 8);
                break;
            case 2: // wm
                studentId = UnityEngine.Random.Range(4, 6);
                break;
            case 3: // am
                studentId = UnityEngine.Random.Range(2, 6);
                break;
            case 4: // bm
                studentId = UnityEngine.Random.Range(2, 4);
                break;
            case 5: // ba
                studentId = UnityEngine.Random.Range(0, 4);
                break;
            case 6: // bf
                studentId = UnityEngine.Random.Range(0, 3);
                break;
            case 7: // af
                studentId = UnityEngine.Random.Range(6, 10);
                if (studentId > 7)
                    studentId = studentId - 8;
                break;
            case 8: // wf
                studentId = UnityEngine.Random.Range(6, 8);
                break;
            case 9: // nobody
                studentId = 8;
                break;
        }
        return studentId;
    }




    public void FillStudents(int classroom, int popIndex)
    {

        for (int i = 0; i < studentSeats.Length; i++)
        {

            classMates[i] = (GameObject)Instantiate(
                studentPrefabs[getStudFromIndex(popIndex)],
                studentSeats[i].transform.position,
                studentSeats[i].transform.rotation);


            switch (classroom)
            {
                case 1:
                  classMates[i].transform.Rotate(0f, 180f, 0f);
                  classMates[i].transform.Translate(0f, 0.125f, -2.125f);
                break;

                case 2:
                  classMates[i].transform.Translate(0f, -0.375f, 0.125f, Space.Self);
                break;
            }
        }   
    }
}
