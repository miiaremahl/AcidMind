using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Refrence: After Image VFX For 3D Games https://www.youtube.com/watch?v=1HRuo581PqQ


public class AImage : MonoBehaviour
{
    //what we are copying w after images
    public Animator copyAnimator;
    public GameObject copyTarget;

    //this objects renderer/animator
    public Animator animator;
    public Renderer Myrenderer;


    //is image activated
    public bool active;

    //after image values
    public float timer; //how long been showed
    public float showTime = 45; //how long wil be shown
    public float intensity; //how much shown
    public float pow;


    void Update()
    {
        if (timer > 0) {
            timer--;
            active = true;
            intensity = (timer / showTime) * 10 * pow;
            UpdateRenderer();
        }
        else {
            active = false; 
            intensity = 0;
        }
    }

    //update renderer values of this image
    void UpdateRenderer()
    {
        Myrenderer.material.SetFloat("_Intensity", intensity);
        Myrenderer.material.SetFloat("_MKGlowPower", intensity);
    }

    //active after image
    public void ActivateImage()
    {
        active = true;

        //take values from the object we are following w images
        transform.position = copyTarget.transform.position;
        transform.localScale = copyTarget.transform.lossyScale;
        transform.rotation = copyTarget.transform.rotation;

        /*if (animator.runtimeAnimatorController != null && copyAnimator.runtimeAnimatorController != null)
        {
            //get correct animator values
            animator.Play(copyAnimator.GetCurrentAnimatorStateInfo(0).shortNameHash, 0, copyAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime);

            //copy animator parameters
            foreach (AnimatorControllerParameter param in copyAnimator.parameters)
            {
                if (param.type == AnimatorControllerParameterType.Float)
                {
                    animator.SetFloat(param.name, copyAnimator.GetFloat(param.name));
                }

                if (param.type == AnimatorControllerParameterType.Int)
                {
                    animator.SetInteger(param.name, copyAnimator.GetInteger(param.name));
                }
            }
        }
        */

        //set speed and timer to show image
        //animator.speed = 0;
        timer = showTime + 1;
        Update();
    }




}
