using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandShaderChanger : MonoBehaviour
{
    //lastest gestures recorded
    private Gesture rHandLatestGesture;
    private Gesture lHandLatestGesture;

    //OVR skeletons for hands
    public OVRSkeleton OVRHandLeft;
    public OVRSkeleton OVRHandRight;

    //renderers for the hands
    public SkinnedMeshRenderer RendererHandLeft;
    public SkinnedMeshRenderer RendererHandRight;

    //picture behaviour (for freezing time)
    public PictureBehaviour pictureBehaviour;

    //First hand shader
    public GameObject GlowHand1;
    public GameObject GlowHand2;

    //materials
    public Material GlowMaterial; // 1 gesture material
    public Material TrailMaterial1; // 2 gesture material
    public Material TrailMaterial2; // 2 gesture material
    public Material AudioHandMaterial; // 3 gesture material
    public Material NeonMaterial; //4 gesture material

    //called when user takes hand away from gesture
    public void SetDefaultGesture(Gesture newGest, string HandName)
    {
        if (HandName.Equals("left"))
        {
            lHandLatestGesture = newGest;
        }
        else
        {
            rHandLatestGesture = newGest;
        }
    }

    //handling recognized gestures
    public void RecognizeGesture(Gesture gesture)
    {

        //handle left hand gestures
        if (gesture.hand.Equals("left"))
        {
            HandleLeftHandGesture(gesture);
        }

        //handle right hand gestures
        else if(gesture.hand.Equals("right"))
        {
            HandleRightHandGesture(gesture);
        }

    }


    //left hand gestures
    public void HandleLeftHandGesture(Gesture gesture)
    {
        lHandLatestGesture = gesture;
        if (rHandLatestGesture.name != null)
        {
            if (rHandLatestGesture.name.Equals("Fist-test-right"))
            {
                CheckLeftHandGestures(gesture);
            }
        }

           
    }

    //check left hand gesture when knowing right hand has right gesture
    public void CheckLeftHandGestures(Gesture gesture)
    {

        switch (gesture.name)
        {
            case "LHand-Fist":
                ChangeSceneFreezing();
                break;
            case "LHand-ThumbsUp":
                ActivateShader1();
                break;
            case "LHand-5":
                break;
            case "LHand-4":
                ActivateShader4();
                break;
            case "LHand-3":
                ActivateShader3();
                break;
            case "LHand-2":
                ActivateShader2();
                break;
            case "LHand-1-ThumbsUp":
                ActivateShader1();
                break;
            default:
                break;
        }
    }


    //right hand gestures
    public void HandleRightHandGesture(Gesture gesture)
    {
        rHandLatestGesture = gesture;
        if (gesture.name != null)
        {
            if (gesture.name.Equals("Fist-test-right"))
            {
                CheckLeftHandGestures(lHandLatestGesture);
            }
        }
    }

    //activate original shader
    private void ActivateShader1()
    {
        //change material
        RendererHandLeft.sharedMaterial = GlowMaterial;
        RendererHandRight.sharedMaterial = GlowMaterial;

        //deactivate other shader hands
        DeActivateShader2();

        GlowHand1.SetActive(true);
        GlowHand2.SetActive(true);
    }

    //activate tracing shader
    private void ActivateShader2()
    {
        RendererHandLeft.sharedMaterial = TrailMaterial1;
        RendererHandRight.sharedMaterial = TrailMaterial2;

        //deactivate other shader hands
        DeActivateShader1();

        OVRHandLeft.SetTrailsActive();
        OVRHandRight.SetTrailsActive();
    }

    //activate audio shader
    private void ActivateShader3()
    {
        RendererHandLeft.sharedMaterial = AudioHandMaterial;
        RendererHandRight.sharedMaterial = AudioHandMaterial;

        //deactivate other shader hands
        DeActivateShader1();
        DeActivateShader2();
    }

    private void ActivateShader4()
    {
        RendererHandLeft.sharedMaterial = NeonMaterial;
        RendererHandRight.sharedMaterial = NeonMaterial;
        DeActivateShader1();
        DeActivateShader2();
    }

    //freeze/unfreeze particle systems
    private void ChangeSceneFreezing()
    {
       // pictureBehaviour.ChangeSceneFreezing();
    }

    //deactivate original shader
    private void DeActivateShader1()
    {
        GlowHand1.SetActive(false);
        GlowHand2.SetActive(false);
    }

    //deactivate tracing shader
    private void DeActivateShader2()
    {
        OVRHandLeft.DeactivateTrails();
        OVRHandRight.DeactivateTrails();
    }

}
