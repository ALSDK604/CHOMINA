using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject Canvas;
    public bool isClicked = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (ARAVRInput.GetDown(ARAVRInput.Button.Two, ARAVRInput.Controller.LTouch)) //�޼��� Y
        {
            Canvas.SetActive(true);
        }
        if (ARAVRInput.GetDown(ARAVRInput.Button.One, ARAVRInput.Controller.LTouch)) // �޼��� X
        {
            Debug.Log("one �������ϴ�");
        }
    }

  public void ClickInsert()
    {
        isClicked = true;
    }
}
