using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClapCheck : MonoBehaviour
{
    //picture behaviour ref
    public PictureBehaviour pictureBehaviour;

    //Are the hands together
    private bool HandsTogether;

    //How long to wait (seconds) till we freeze the scene
    public int TimeTillFreeze = 5;

    private void OnTriggerEnter(Collider other)
    {
        //Hands put together
        if (other.gameObject.CompareTag("LClap"))
        {
            HandsTogether = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //Hands are not together anymore
        if (other.gameObject.CompareTag("LClap"))
        {
            HandsTogether = false;
        }
    }

    //"freezes the scene" aka particles etc are paused or "unfreezes" them
    private void RectToHandGesture()
    {
      //  pictureBehaviour.ReactToHandsTogether();
    }


    //timer for freezing
    private IEnumerator FreezingTime()
    {
        int timePassed = 0;
        while (HandsTogether && timePassed < TimeTillFreeze)
        {
            //wait for 1 sec for next check
            yield return new WaitForSeconds(1.0f);
            timePassed ++;
        }

        if(timePassed >= TimeTillFreeze)
        {
            //user hold hands together enough time -> freeze/unfreeze the scene

            //ADD: explosive thing and sound
            RectToHandGesture();
        }
    }

}
