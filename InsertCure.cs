using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertCure : MonoBehaviour
{
    public bool ReadyCure = false;
    public float radius = 0.2f;
    public LayerMask cureHolderLayer;

    private UIManager UIManager;
    private Vector3 PlayerTr;
    [SerializeField] GameObject cures;
    [SerializeField] ParticleSystem SmokeEffect;
    private Animator curesAnimator;


    void Start()
    {
        SmokeEffect.Pause();
        curesAnimator = cures.GetComponent<Animator>();
        PlayerTr = GameObject.Find("OVRPlayerController").GetComponent<Transform>().position;
        UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    void Update()
    {
        if (!ReadyCure)
        {
            Collider[] hits = Physics.OverlapSphere(PlayerTr, radius, cureHolderLayer);

            if (hits != null && UIManager.isClicked)
            {
                cures.SetActive(true);
                curesAnimator.SetTrigger("InsertCure");
                SmokeEffect.Play();
            }
        }
    }
}
