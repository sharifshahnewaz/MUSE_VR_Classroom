using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherScript : MonoBehaviour
{

    Animator anim;

    bool running;

    public Transform pointA;
    public Transform pointB;

    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        running = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            running = true;
            StartCoroutine("teacherAnimations");
            StartCoroutine("walkRight");

        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            running = false;
        }

        if (Input.GetKey(KeyCode.G))
        {
            anim.SetBool("PaceTest", true);
            transform.position = Vector3.MoveTowards(transform.position, 
                pointA.position, speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.F))
        {
            anim.SetBool("PaceTest2", true);
            transform.position = Vector3.MoveTowards(transform.position,
                pointB.position, speed * Time.deltaTime);
        }
    }

    void walk()
    {
        if (gameObject.transform.position.z == pointA.position.z)
        {
            anim.SetBool("PaceTest", true);
            transform.position = Vector3.MoveTowards(transform.position,
                pointA.position, speed * Time.deltaTime);
            return;
        }

        if (gameObject.transform.position.z == pointB.position.z)
        {
            anim.SetBool("PaceTest2", true);
            transform.position = Vector3.MoveTowards(transform.position,
                pointB.position, speed * Time.deltaTime);
            return;
        }
    }

    IEnumerator teacherAnimations()
    {
        while (running == true)
        {
            int numSeconds = Random.Range(10, 20);

            anim.SetBool("Point", true);

            yield return new WaitForSeconds(1);

            anim.SetBool("Point", false);

            yield return new WaitForSeconds(numSeconds);
        }
    }


    IEnumerator walkRight()
    {
        while (running == true)
        {
            Debug.Log(running);
            int numSeconds = Random.Range(10, 20);

            anim.SetBool("PaceTest2", true);

            yield return new WaitForSeconds(1);

            anim.SetBool("PaceTest2", false);

            yield return new WaitForSeconds(numSeconds);
        }
    }

}
