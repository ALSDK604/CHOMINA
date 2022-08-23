using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRaycast : MonoBehaviour
{
    [SerializeField] Transform pointDot;

    //싱글턴

    public static UIRaycast instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(this.gameObject);
        }
    }

    void Update()
    {
        Ray ray = new Ray(ARAVRInput.RHandPosition, ARAVRInput.RHandDirection);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("VRUI"))
            {
                pointDot.gameObject.SetActive(true);
                pointDot.position = hit.point;
            }

            else
            {
                pointDot.gameObject.SetActive(false);
            }

            if (pointDot.gameObject.activeSelf)
            {

                Debug.Log(hit.collider.gameObject.name);
                if (ARAVRInput.GetDown(ARAVRInput.Button.IndexTrigger , ARAVRInput.Controller.RTouch))
                {
                    // 버튼 스크립트를 가져온다
                    Button btn = hit.collider.gameObject.GetComponent<Button>();
                    // 만약 btn이 null이 아니라면
                    if (btn != null)
                    {
                        btn.onClick.Invoke();
                    }
                }
            }
        }
        else
        {
            pointDot.gameObject.SetActive(false);
        }
    }
}
