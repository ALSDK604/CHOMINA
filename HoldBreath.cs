using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldBreath : MonoBehaviour
{
    private float timer;
    private float breathTime = 30f;
    private float resetTimer;
    private float resetTime = 30f;
    public static bool lostTarget = false;
    private bool canHoldBreath = true;

    Zombie zombie;
    [SerializeField] GameObject SliderCanvas;
    [SerializeField] Slider circleSlider;


    void Update()
    {
        if (ARAVRInput.Get(ARAVRInput.Button.HandTrigger, ARAVRInput.Controller.LTouch) && canHoldBreath)
        {
            Debug.Log("숨을 참겠습니다");
            SliderCanvas.SetActive(true);
            timer += Time.deltaTime;
            circleSlider.value = timer;

            if (timer <= breathTime)
            {
                lostTarget = true;
                Debug.Log(timer);
            }

            else if (timer > breathTime)
            {

                lostTarget = false;
                canHoldBreath = false;
                SliderCanvas.SetActive(false);
                //timer = 0;
                circleSlider.value = 0f;
            }
        }

        if (!canHoldBreath)
        {
            resetTimer += Time.deltaTime;

            if (resetTimer >= resetTime)
            {
                canHoldBreath = true;
                resetTimer = 0;
                timer = 0;
            }
        }

        if (ARAVRInput.GetUp(ARAVRInput.Button.HandTrigger, ARAVRInput.Controller.LTouch))
        {
            SliderCanvas.SetActive(false);
            timer = 0;
            circleSlider.value = 0f;
            canHoldBreath = false;
            lostTarget = false;
        }

        if (ARAVRInput.Get(ARAVRInput.Button.HandTrigger, ARAVRInput.Controller.LTouch) && !canHoldBreath)
        {
            Debug.Log("숨을 참을 수 없습니다");
        }
    }
}
