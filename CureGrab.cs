using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CureGrab : MonoBehaviour
{
    [SerializeField] GameObject[] CureImage;
    [SerializeField] AudioClip grabSound;
    private AudioSource audioSource;
    private OVRGrabbable OVRGrabbable;
    public static int CureCount = 0;
    private bool putUIImage = true;
    

    InsertCure insertCure;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        OVRGrabbable = GetComponent<OVRGrabbable>();
        insertCure = GameObject.Find("GameManager").GetComponent<InsertCure>();
    }

    void Update()
    {
        if (!OVRGrabbable.isGrabbed && !putUIImage)
        {
            putUIImage = true;
        }

        if (OVRGrabbable.isGrabbed && putUIImage)
        {
            switch (CureCount)
            {
                case 0:
                    audioSource.PlayOneShot(grabSound);
                    CureImage[0].SetActive(true);
                    CureCount += 1;
                    Destroy(gameObject, 0.5f);
                    putUIImage = false;
                    return;

                case 1:
                    audioSource.PlayOneShot(grabSound);
                    CureImage[1].SetActive(true);
                    CureCount += 1;
                    Destroy(gameObject, 0.5f);
                    putUIImage = false;
                    return;
                
                case 2:
                    audioSource.PlayOneShot(grabSound);
                    CureImage[2].SetActive(true);
                    CureCount += 1;
                    Destroy(gameObject, 0.5f);
                    putUIImage = false;
                    return;

                case 3:
                    audioSource.PlayOneShot(grabSound);
                    CureImage[3].SetActive(true);
                    CureCount += 1;
                    Destroy(gameObject, 0.5f);
                    putUIImage = false;
                    return;
            }
        }
        if (CureCount ==4)
        {
            Debug.Log("잡았습니다");
            putUIImage = false;
            insertCure.ReadyCure = true;
            CureCount +=1;
        }
    }
}
