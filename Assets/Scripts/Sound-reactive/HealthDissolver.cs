﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDissolver : MonoBehaviour
{

    [SerializeField]
    public Material dissolveMat = null;

    [SerializeField]
    private bool useSamplesFromAudio = false;

    [SerializeField]
    private SpectrumManager spectrumManager = null;

    [SerializeField]
    private float sampleMultipler = 100.0f;

    public float health;
    public float maxHealth;


    // Start is called before the first frame update
    void Start()
    {
        dissolveMat.SetFloat("_Health", health / maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

        float value = spectrumManager.Samples[0] * sampleMultipler;

        dissolveMat.SetFloat("_Health", value);

        if (dissolveMat != null)
        {
            if (useSamplesFromAudio)
            {
                Debug.Log("Material around and checkbox on");
            }
        }


        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health -= 5;
            dissolveMat.SetFloat("_Health", health / maxHealth);

        }
        */

    }
}
