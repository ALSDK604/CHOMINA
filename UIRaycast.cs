using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRaycast : MonoBehaviour
{
    [SerializeField] Transform pointDot;

    //�̱���

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
                    // ��ư ��ũ��Ʈ�� �����´�
                    Button btn = hit.collider.gameObject.GetComponent<Button>();
                    // ���� btn�� null�� �ƴ϶��
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
