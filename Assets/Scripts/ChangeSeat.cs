using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSeat : MonoBehaviour
{
    public GameObject seat1, seat2, seat3;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void Update() // currently uses keypad values to change the seating of the active person.
    {
        if (Input.GetKeyDown("[7]"))
        {
            print("changing to base position");
            this.transform.position = seat1.transform.position;
        }
        if (Input.GetKeyDown("[8]"))
        {
            print("changing to 1st position");
            this.transform.position = seat2.transform.position;
        }
        if (Input.GetKeyDown("[9]"))
        {
            print("changing to 2nd position");

            this.transform.position = seat3.transform.position;
        }
    }
}
