using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class WaveSound : MonoBehaviour
{

    [SerializeField]
    public VisualEffect visualEffect;

    // public Material dissolveMat = null;

    [SerializeField]
    private bool useSamplesFromAudio = false;

    [SerializeField]
    private SpectrumManager spectrumManager = null;

    [SerializeField]
    private float sampleMultipler = 1000f;

    [SerializeField]
    public string VFXAttribute01;

    // Start is called before the first frame update
    void Start()
    {
        visualEffect.SetFloat(VFXAttribute01, 0.2f);
        //Set start of scene
       // dissolveMat.SetFloat(ShaderAttribute01, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        float value = spectrumManager.Samples[0] * sampleMultipler;
      
        // dissolveMat.SetFloat(ShaderAttribute01, value);
        visualEffect.SetFloat(VFXAttribute01, value);

        /*
        if (dissolveMat != null)
        {
            if (useSamplesFromAudio)
            {
                Debug.Log("Material around and checkbox on");
            }
        }
        */

        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health -= 5;
            dissolveMat.SetFloat("_Health", health / maxHealth);

        }
        */
    }
}