using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeacherController : MonoBehaviour
{
    bool walkBackAllowed =false;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
            if (time > 7)
            {
                if (walkBackAllowed == false)
                {
                    anim.SetBool("isWalkingRight", true);
                    yield return new WaitForSeconds(0.1F);
                    walkBackAllowed = true;
                    anim.SetBool("isWalkingRight", false);
                }
                else {
                    anim.SetBool("isWalkingLeft", true);
                    yield return new WaitForSeconds(0.1F);
                    walkBackAllowed = false;
                    anim.SetBool("isWalkingLeft", false);
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
