using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeTeacher : MonoBehaviour
{
    public GameObject wf, bf, bm, wm;
    public int teacherCounter;

    // Start is called before the first frame update
    void Start()
    {
        teacherCounter = 1;

        wf.transform.gameObject.SetActive(true);
        bf.transform.gameObject.SetActive(false);
        bm.transform.gameObject.SetActive(false);
        wm.transform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            teacherCounter++;
            if (teacherCounter > 4)
                teacherCounter = 1;

            if (teacherCounter == 1)
            {
                wf.transform.gameObject.SetActive(true);
                bf.transform.gameObject.SetActive(false);
                bm.transform.gameObject.SetActive(false);
                wm.transform.gameObject.SetActive(false);
            }
            if (teacherCounter == 2)
            {
                wf.transform.gameObject.SetActive(false);
                bf.transform.gameObject.SetActive(true);
                bm.transform.gameObject.SetActive(false);
                wm.transform.gameObject.SetActive(false);
            }
            if (teacherCounter == 3)
            {
                wf.transform.gameObject.SetActive(false);
                bf.transform.gameObject.SetActive(false);
                bm.transform.gameObject.SetActive(true);
                wm.transform.gameObject.SetActive(false);
            }
            if (teacherCounter == 4)
            {
                wf.transform.gameObject.SetActive(false);
                bf.transform.gameObject.SetActive(false);
                bm.transform.gameObject.SetActive(false);
                wm.transform.gameObject.SetActive(true);
            }
        }

    }
}