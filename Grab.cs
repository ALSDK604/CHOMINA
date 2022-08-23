using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    bool isGrabbing = false;
    GameObject grabObject;
    public LayerMask grabLayer;
    public float grabRange;

    void Start()
    {

    }


    void Update()
    {
        if (isGrabbing == false)
        {
            GrabObject();
        }
    }

    public void GrabObject()
    {
        if (ARAVRInput.GetDown(ARAVRInput.Button.HandTrigger, ARAVRInput.Controller.RTouch))
        {
            Debug.Log("잡았습니다");
            Collider[] hitObjects = Physics.OverlapSphere(ARAVRInput.RHandPosition, grabRange, grabLayer);

            int closest = 0;

            for (int i = 1; i < hitObjects.Length; i++)
            {
                Vector3 closestPos = hitObjects[closest].transform.position;
                float closestDistance = Vector3.Distance(closestPos, ARAVRInput.RHandPosition);

                Vector3 nextPos = hitObjects[i].transform.position;
                float nextDistance = Vector3.Distance(nextPos, ARAVRInput.RHandPosition);

                if (nextDistance < closestDistance)
                {
                    closest = i;
                }
            }

            if (hitObjects.Length > 0)
            {
                isGrabbing = true;
                grabObject = hitObjects[closest].gameObject;
                grabObject.transform.parent = ARAVRInput.RHand;

                if (grabObject.tag == "Ax")
                {
                    grabObject.transform.localPosition = new Vector3(0f, 0.019f, 0.048f);
                    grabObject.transform.localRotation = Quaternion.Euler(79f, 270f, 70f);
                    grabObject.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
                }
            }
        }

    }
}
