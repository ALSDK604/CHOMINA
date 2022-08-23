using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private SimpleShoot simpleShoot;
    private OVRGrabbable OVRGrabbable;
    private AudioSource audioSource;

    public static bool gunIsGrabbed = false;

    [SerializeField] AudioClip GunShoot;
    [SerializeField] AudioClip GunReload;

    private void Start()
    {
        simpleShoot = GetComponent<SimpleShoot>();
        OVRGrabbable = GetComponent<OVRGrabbable>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (OVRGrabbable.isGrabbed)
        {
            gunIsGrabbed = true;
        }

        if (OVRGrabbable.isGrabbed && ARAVRInput.GetDown(ARAVRInput.Button.IndexTrigger, ARAVRInput.Controller.RTouch))
        {
            ARAVRInput.PlayVibration(ARAVRInput.Controller.RTouch);
            simpleShoot.Fire();
            audioSource.PlayOneShot(GunShoot);
        }
    }
}
