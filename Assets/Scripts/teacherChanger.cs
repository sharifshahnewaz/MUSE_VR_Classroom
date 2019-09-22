using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teacherChanger : MonoBehaviour
{

    public GameObject[] teacherPrefabs; // the prefabs of each of the teacher models
    public GameObject teacher; // the actual teacher spawned
    public GameObject[] teacherPositions;
    
    // Start is called before the first frame update
    void Start()
    {

        teacher = (GameObject)Instantiate(
            teacherPrefabs[0],
            teacherPositions[0].transform.position,
            teacherPositions[0].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeTeacher(int index, int location)
    {
        Destroy(teacher);

        teacher = (GameObject)Instantiate(
            teacherPrefabs[index],
            teacherPositions[location-1].transform.position,
            teacherPositions[location-1].transform.rotation);
    }
}
