using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    [SerializeField] Transform crossHair;
    [SerializeField] SpriteRenderer crossHair_Color;
    private Vector3 originPos;
    private Color originColor;


    void Start()
    {
        originPos = crossHair.position;
        originColor = crossHair_Color.color;
    }


    void Update()
    {
        if (Gun.gunIsGrabbed == true)
        {
            Ray ray = new Ray(ARAVRInput.RHandPosition, ARAVRInput.RHandDirection);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 8f))
            {
                if (hit.collider.gameObject.tag == "Zombie")
                {
                    crossHair.position = hit.point + new Vector3(0.2f, 0f, 0f);
                    crossHair_Color.color = new Color(1f, 0f, 0f);
                }

                else
                {
                    crossHair.position = originPos;
                    crossHair_Color.color = originColor;
                }
            }
        }
    }
}

