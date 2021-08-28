using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    //which hand is it
    public string HandName;

    //transform that we are tracking for shader
    public Transform Hand;

    void Update()
    {
        if (HandName.Equals("left"))
        {
            //updating hand position in shader
            Shader.SetGlobalVector("_HandPositionL", Hand.position);
        }
        else
        {
            //updating hand position in shader
            Shader.SetGlobalVector("_HandPositionR", Hand.position);
        }
    }

}
