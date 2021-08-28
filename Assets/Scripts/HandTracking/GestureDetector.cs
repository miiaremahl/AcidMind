using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//refrence used: Valem- Hand Tracking Gesture Detection - Unity Oculus Quest Tutorial: https://www.youtube.com/watch?v=lBzwUKQ3tbw : used for hand poses

//stores gesture
[System.Serializable]
public struct Gesture
{
    //name of the gesture
    public string name;

    //positions of fingers
    public List<Vector3> fingerData;

    //which hand
    public string hand;

}

public class GestureDetector : MonoBehaviour
{

    //which hand
    public string HandName;

    //treshold value
    public float treshold = 0.1f;

    //skeleton
    public OVRSkeleton skeleton;

    //finger bones
    private List<OVRBone> fingerBones;

    //list of possible gestures
    public List<Gesture> gestures;

    //the gesture recognized last
    private Gesture latestGesture;

    //are the finger bones loaded
    bool fingersLoaded = false;

    //hand shader changer
    public HandShaderChanger handShaderChanger;


    void Start()
    { 
        latestGesture = new Gesture();
        if (skeleton)
        {
            fingerBones = new List<OVRBone>(skeleton.Bones);
        }
    }

    void Update()
    {
        //reload fingers -> the first load doesn't happen early enough so second is nesessary
        if (!fingersLoaded && fingerBones.Count < 1 && skeleton.Bones.Count > 0)
        {
            fingerBones = new List<OVRBone>(skeleton.Bones);
        }

        //comment in when makiing new gestures
       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            Save();
        }*/

        //take the recognition data
        Gesture currentGesture = Recognize();

        //check if the gesture was recognized
        bool recognizedGesture = !currentGesture.Equals(new Gesture());

        //&& !currentGesture.Equals(latestGesture)
        //new gesture recognized
        if (recognizedGesture)
        {
            if (!currentGesture.Equals(latestGesture))
            {
                latestGesture = currentGesture;
                handShaderChanger.RecognizeGesture(currentGesture);
            }
        }

        //else if (!currentGesture.Equals(latestGesture))
        //{
        //    handShaderChanger.SetDefaultGesture(currentGesture, HandName);
        //}

    }


    //making new gestures
    void Save()
    {
        Gesture g = new Gesture();
        g.name = "new gesture";
        List<Vector3> data= new List<Vector3>();

        foreach (var bone in fingerBones)
        {
            //finger position relative to the root
            data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
        }

        //add finger data to gesture and the gesture to gestures list
        g.fingerData = data;
        gestures.Add(g);
    }


    //recognizing gestures
    Gesture Recognize()
    {
        Gesture currentGesture = new Gesture();
        float currentMin = Mathf.Infinity;

        //going through each gesture
        foreach (Gesture gesture in gestures)
        {
            float sumDistance = 0;
            bool isDiscarded = false;

            //go through each bone
            for (int i = 0; i < fingerBones.Count; i++)
            {
                //current pose
                Vector3 currentData = skeleton.transform.InverseTransformPoint(fingerBones[i].Transform.position);

                //distance to gesture pose
                float distance = Vector3.Distance(currentData, gesture.fingerData[i]);

                //check if the bone is too far away from the gesture
                if (distance > treshold)
                {
                    isDiscarded = true;
                    break;
                }
                sumDistance += distance;
            }

            //check if this gesture is the closes to one we are making
            if (!isDiscarded && sumDistance < currentMin)
            {
                currentGesture = gesture;
                currentMin = sumDistance;
            }
        }
        return currentGesture;
    }
}
