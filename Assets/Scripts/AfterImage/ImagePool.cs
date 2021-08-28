using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Refrence: After Image VFX For 3D Games https://www.youtube.com/watch?v=1HRuo581PqQ
public class ImagePool : MonoBehaviour
{
    //list of after images
    public List<AImage> AImages;
    public List<GameObject> AImageObjects;

    //how many after imgaes we want
    public int ImageAmount;

    //after image prefab
    public GameObject Prefab;
    public GameObject Prefab2;

    //object we are following w images
    public GameObject CopyTarget;     
    public Animator CopyAnimator;

    //spawn timer/time 
    public int Spawntimer = 0;
    public int TimeBetween = 10;

    //is imagepool active
    private bool Active =false;


    //returns if pool is active
    public bool IsActive()
    {
        return Active;
    }

    //empty the image pool
    public void EmptyPool()
    {
        for (int i = 0; i < ImageAmount; i++)
        {
            if (AImageObjects[i])
            {
               Destroy(AImageObjects[i]);
            }
        }
        AImages.Clear();
        AImageObjects.Clear();
        Active = false;
    }
    void Start()
    {
      //ActivatePool();
    }
    public void ActivatePool()
    {
        Active = true;
        AImages = new List<AImage>(ImageAmount+1);

        for (int i = 0; i < ImageAmount; i++)
        {
            GameObject newImage;
            //instansiate image and add to list
            if (i % 2 ==0)
            {
                newImage = Instantiate(Prefab);
            }
            else
            {
                newImage = Instantiate(Prefab2);
            }
            AImages.Add(newImage.GetComponent<AImage>());
            AImageObjects.Add(newImage);

            //set target object and animator
            newImage.GetComponent<AImage>().copyTarget = CopyTarget;     
            newImage.GetComponent<AImage>().copyAnimator = CopyAnimator;     
        }
    }


    void Update()
    {
        if (Active)
        {
            Spawntimer++;
            if (Spawntimer > TimeBetween)
            {
                Spawntimer = 0;
                AddImage();
            }
        }
    }

    void AddImage()
    {
        //find image to activate
        for (int i = 0; i < ImageAmount; i++)
        {
            if (!AImages[i].active) {
                AImages[i].ActivateImage();
                break;
            }
        }
    }

}
