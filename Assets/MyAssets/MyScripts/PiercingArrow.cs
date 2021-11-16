using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingArrow : MonoBehaviour
{
    Rigidbody rb;
    private float lifeTime = 2f;
    private float timer;
    private bool hitDetected = false;
    public ParticleSystem hitParticle;
    private AudioSource audioSource;
    [SerializeField] AudioClip metalHit;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(rb.velocity);
        audioSource = GetComponent<AudioSource>();

    }

    private void Update()
    {
        if (!hitDetected)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "PiercingArrow")
        {
            hitDetected = true;
            audioSource.pitch = (Random.Range(0.8f, 1.2f));
            audioSource.Play();
            hitParticle.Play();
            Stick();
        }

        if (collision.collider.CompareTag("Enemy"))
        {
            hitDetected = true;
            audioSource.PlayOneShot(metalHit);
            hitParticle.Play();
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.EnemyTakeDamage(1);
            Destroy(this.gameObject, .5f);
        }

        if (collision.collider.CompareTag("StationaryEnemy"))
        {
            hitDetected = true;
            audioSource.PlayOneShot(metalHit);
            hitParticle.Play();
            StationaryEnemy stationaryenemy = collision.gameObject.GetComponent<StationaryEnemy>();
            stationaryenemy.EnemyTakeDamage(1);
            Destroy(this.gameObject, .5f);
        }
    }

    private void Stick()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        Destroy(this.gameObject, 5f);
    }
}
