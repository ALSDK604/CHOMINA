using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private ParticleSystem zombieParticleSystem;
    private Animator zombieAnim;
    private AudioSource zombieAudioSource;
    private Zombie zombie;

    [SerializeField] AudioClip DamageSound;

    void Start()
    {
        zombie = this.GetComponent<Zombie>();
        zombieParticleSystem = GetComponentInChildren<ParticleSystem>();
        zombieAnim = GetComponent<Animator>();
        zombieAudioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        StopCoroutine(ShowEffect());

        if (collision.gameObject.tag == "Bullet")
        {
            zombieAnim.SetTrigger("Hit");
            zombieAudioSource.PlayOneShot(DamageSound);
            zombie.zombieHealth--;
            StartCoroutine(ShowEffect());
        }
    }

    IEnumerator ShowEffect()
    {
        zombieParticleSystem.Play();
        yield return new WaitForSeconds(0.5f);
        zombieParticleSystem.Stop();
    }
}
