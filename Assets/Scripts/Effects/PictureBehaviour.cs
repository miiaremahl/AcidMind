using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureBehaviour : MonoBehaviour
{
    //particle systems in scene
    public ParticleSystem[] particleSystems;

    //ADD: vfx on scene

    //add: traces in scene

    //is scene "frozen"
    private bool sceneFrozen=false;

    public void FreezeScene()
    {
        //freeze every particle system
        foreach (ParticleSystem particleSystem in particleSystems)
        {
            particleSystem.Pause(true);
        }
    }


    //reacting to hand together
    public void ChangeSceneFreezing()
    {
        if (sceneFrozen)
        {
            UnFreeze();
        }
        else
        {
            FreezeScene();
        }
    }


    public void UnFreeze()
    {
        //unfreeze every particle system
        foreach (ParticleSystem particleSystem in particleSystems)
        {
            particleSystem.Play(true);
        }
    }
}
