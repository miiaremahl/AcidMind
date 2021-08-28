using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderAnimationHand : MonoBehaviour
{

    [SerializeField]
    public Material dissolveMat = null;

    [SerializeField]
    private bool useSamplesFromAudio = false;

    [SerializeField]
    private SpectrumManager spectrumManager = null;

    [SerializeField]
    private float sampleMultipler = 100.0f;


    [SerializeField]
    public string ShaderAttribute01;

    // Start is called before the first frame update
    void Start()
    {
        //Set start of scene
        dissolveMat.SetFloat(ShaderAttribute01, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (spectrumManager && (spectrumManager.Samples.Length > 0))
        {
            float value = spectrumManager.Samples[0] * sampleMultipler;

            dissolveMat.SetFloat(ShaderAttribute01, value);
            if (dissolveMat != null)
            {
                if (useSamplesFromAudio)
                {
                    Debug.Log("Material around and checkbox on");
                }
            }
        }
    }
}

