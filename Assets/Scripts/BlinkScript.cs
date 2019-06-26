using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkScript : MonoBehaviour
{
    public GameObject Cr1, Cr2, Cr3;
    public  Material m_Material;
    public int classRoomCounter;
    // Start is called before the first frame update
    void Start()
    {
        classRoomCounter = 1;

        Cr1.transform.gameObject.SetActive(true);
        Cr2.transform.gameObject.SetActive(false);
        Cr3.transform.gameObject.SetActive(false);
    }
    
        // Update is called once per frame
        void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            classRoomCounter++;
            if (classRoomCounter > 3)
                classRoomCounter = 1;

            if (classRoomCounter == 1)
            {
                Cr1.transform.gameObject.SetActive(true);
                Cr2.transform.gameObject.SetActive(false);
                Cr3.transform.gameObject.SetActive(false);
            }
            if (classRoomCounter == 2)
            {
                Cr1.transform.gameObject.SetActive(false);
                Cr2.transform.gameObject.SetActive(true);
                Cr3.transform.gameObject.SetActive(false);
            }
            if (classRoomCounter == 3)
            {
                Cr1.transform.gameObject.SetActive(false);
                Cr2.transform.gameObject.SetActive(false);
                Cr3.transform.gameObject.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            m_Material.color = Color.red;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            m_Material.color = Color.blue;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            m_Material.color = Color.black;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            m_Material.color = Color.white;
        }
    }
}
