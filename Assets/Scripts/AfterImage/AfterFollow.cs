using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterFollow : MonoBehaviour
{
    //after image pool
    public ImagePool afterImagePool;

    //positions
    Vector3 currentPos;
    Vector3 lastPos;

    //time
    float elapsedTime;
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 0.5f)
        {
            elapsedTime = elapsedTime % 0.5f;
            CheckMovement();
        }
    }

    //checking if the object has moved
    void CheckMovement()
    {
        currentPos = transform.position;
        if (currentPos != lastPos)
        {
            if (!afterImagePool.IsActive())
            {
                ActivateAfterImage();
            }
        }
        else
        {
            if (afterImagePool.IsActive())
            {
                afterImagePool.EmptyPool();
            }
        }
        lastPos = currentPos;
    }

    //activating next after image
    void ActivateAfterImage()
    {
        afterImagePool.ActivatePool();
    }
}
