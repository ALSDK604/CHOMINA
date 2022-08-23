using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Zombie : MonoBehaviour
{
    Transform target;
    NavMeshAgent zombieNavMesh;
    Animator zombieAnim;
    AudioSource zombieAudio;
    Vector3 zombieOriginPOS;

    [SerializeField] AudioClip ScreamSound;
    [SerializeField] AudioClip attackSound;

    private int PlayAnimOneTime = 0;
    private int count = 0;

    public float zombieDamage;
    public float zombieHealth;

    ZombieSpawner zombieSpawner;

    void Start()
    {
        //  bloodCanvas = Camera.main.transform.Find("Canvas").gameObject;
        zombieOriginPOS = this.gameObject.transform.position;

        target = GameObject.Find("OVRPlayerController").transform;

        Debug.Log(target.position);

        zombieNavMesh = GetComponent<NavMeshAgent>();
        zombieAnim = GetComponent<Animator>();

        zombieSpawner = GameObject.Find("ZompieSpawner").GetComponent<ZombieSpawner>();
        zombieAudio = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (!HoldBreath.lostTarget)
        {
            PlayAnimOneTime = 0;
            zombieNavMesh.enabled = true;
            zombieNavMesh.SetDestination(target.position);

            if (Vector3.Distance(this.transform.position, target.transform.position) <= 15)
            {
                zombieAnim.SetBool("Run", true);
            }

            else
            {
                zombieAnim.SetBool("Run", false);
            }

            if (Vector3.Distance(this.transform.position, target.transform.position) <= 2.2f)
            {
                zombieAnim.SetTrigger("Attack");
                zombieAudio.PlayOneShot(attackSound);
                //StartCoroutine(OpenBloodCanvas());
            }
        }

        else if (HoldBreath.lostTarget && PlayAnimOneTime ==0)
        {
            zombieAudio.PlayOneShot(ScreamSound);
            zombieNavMesh.enabled = false;
            zombieAnim.SetTrigger("LostTarget");
            PlayAnimOneTime += 1;
        }

        else if (HoldBreath.lostTarget && PlayAnimOneTime == 1)
        {
            zombieAnim.SetTrigger("Walk");
            zombieAnim.SetBool("Run", false);
        }

        if (zombieHealth <= 0 && count ==0)
        {
            Die();
            zombieSpawner.zombieIsDead = true;
            count++;
        }
    }

    public void SetUp(ZombieData zombieData)
    {
        zombieDamage = zombieData.damage;

        zombieHealth = zombieData.health;
    }


    public void Die()
    {
        zombieAnim.SetTrigger("Die");
        Destroy(this.gameObject, 1f);
    }
}
