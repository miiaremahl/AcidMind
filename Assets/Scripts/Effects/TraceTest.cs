using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//OLD CODE FOR TRACING PARTICLES
public class TraceTest : MonoBehaviour
{
    public ParticleSystem[] particleSystems;

    Vector3 currentPos;
    Vector3 lastPos;

    float elapsedTime;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 1f)
        {
            elapsedTime = elapsedTime % 1f;
            CheckMovement();
        }
    }

    void CheckMovement()
    {
        currentPos = transform.position;
        if (currentPos != lastPos)
        {
            PlaySystems();
        }
        else
        {
            PauseSystems();
        }
        lastPos = currentPos;
    }

    void PlaySystems()
    {
        if (!particleSystems[0].isPlaying)
        {
            foreach (ParticleSystem system in particleSystems) 
            {
                system.Play();
            }
        }

    }

    void PauseSystems()
    {
        if (particleSystems[0].isPlaying)
        {
            Debug.Log(particleSystems.Length);
            foreach (ParticleSystem system in particleSystems)
            {
                system.Stop();
            }
        }
    }

}
