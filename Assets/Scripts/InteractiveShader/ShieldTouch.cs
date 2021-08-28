using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Not in use anymore
public class ShieldTouch : MonoBehaviour
{
    public Material mat;

    private void OnCollisionEnter(Collision col)
    {
        mat.SetVector("_HitArea", col.contacts[0].point);
    }

}
