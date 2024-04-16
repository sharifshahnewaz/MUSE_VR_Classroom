using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TeacherController : MonoBehaviour
{
    bool walkBackAllowed =false;
    Animator anim;
    public GameObject startPos;
    public bool smallRoom = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        startPos = GameObject.Find("TeachPosM");
        anim.SetBool("SmallRoom", smallRoom);
    }

    public void startAnimation()
    {
        StartCoroutine("walk");
    }
   
    IEnumerator walk()
    {
        while (true)
        {
            int time = Random.Range(5, 10);
            if (time > 7 && smallRoom)
            {
                if (walkBackAllowed == false)
                {
                    anim.SetBool("isWalkingRight", true);
                    yield return new WaitForSeconds(0.1f);
                    walkBackAllowed = true;
                    anim.SetBool("isWalkingRight", false);
                    yield return new WaitForSeconds(2.5F);
                    transform.rotation = startPos.transform.rotation;
                    yield return new WaitForSeconds(2.0F);
                    transform.position = startPos.transform.position;
                    transform.rotation = startPos.transform.rotation;
                    continue;
                }
                else {
                    anim.SetBool("isWalkingLeft", true);
                    yield return new WaitForSeconds(0.1F);
                    walkBackAllowed = false;
                    anim.SetBool("isWalkingLeft", false);
                    continue;
                }
            }
            else
            {
                anim.SetBool("Point", true);
                yield return new WaitForSeconds(1);
                anim.SetBool("Point", false);
            }
            yield return new WaitForSeconds(time);
        }
    }
}
