using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class viveInput : MonoBehaviour
{
    // to discern either part of the vive actions
    public SteamVR_Action_Single squeezeAction;
    public SteamVR_Action_Vector2 touchPadAction;

    // used to calculate acceleration of touchpad for swipe
    public float lastPos, touchAccel;
    public bool isSwipe;
    public bool swipedLeft, swipedRight;
    // similar in function 
    public float squeezie;
    public int timesSqueezed;
    public bool squeezed;

    public GameObject cameraRig;
    private changeClassroom editor;
    
    private void Start()
    {
        timesSqueezed = 0;
        isSwipe = false;
        lastPos = 0.0f;
        editor = cameraRig.GetComponent<changeClassroom>();
    }
    

    void Update()
    {
        isSwipe = false;
        swipedRight = false;
        swipedLeft = false;
        touchAccel = touchPadAction.GetAxis(SteamVR_Input_Sources.Any)[0] - lastPos;

        // moves the step process by one
        if (squeezeAction.GetAxis(SteamVR_Input_Sources.Any) == 1 && squeezie != 1)
        {
            editor.changeText();
            editor.stepUpdate();
            squeezed = true;
            timesSqueezed++;
        }
        else
            squeezed = false;

        // cycles between the specific states of each prompt
        if(touchPadAction.GetAxis(SteamVR_Input_Sources.Any)[0]!=0
            && touchPadAction.GetAxis(SteamVR_Input_Sources.Any)[1] != 0)
        if (touchAccel> 0.5 || touchAccel<-0.5)
        {
            isSwipe = true;
            if (touchAccel > 0.5)
                editor.chooseOption(true);
            if (touchAccel < -0.5)
                editor.chooseOption(false);
        }
        lastPos = touchPadAction.GetAxis(SteamVR_Input_Sources.Any)[0];
        squeezie = squeezeAction.GetAxis(SteamVR_Input_Sources.Any);

        // backup for in case we can't use the vives
        if (Input.GetKeyDown("space")) // The actual selection process.
        {
            editor.stepUpdate();
        }

        }


}
