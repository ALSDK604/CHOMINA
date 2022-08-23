using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed;

    CharacterController myController;

    float gravity = -30;        //-9.8
    float jumpPower = 10;

    private void Start()
    {
        myController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        
        float h = ARAVRInput.GetAxis("Horizontal");
        float v = ARAVRInput.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir = Camera.main.transform.TransformDirection(dir);

        dir.y += gravity * Time.deltaTime;

        if (myController.isGrounded) dir.y = 0;

        if (ARAVRInput.GetDown(ARAVRInput.Button.Two)) dir.y = jumpPower;

        myController.Move(dir * speed * Time.deltaTime);
    }
}
