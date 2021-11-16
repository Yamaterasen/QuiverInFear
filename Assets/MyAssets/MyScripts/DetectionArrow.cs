using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionArrow : MonoBehaviour
{
    Rigidbody rb;
    private float lifeTime = 2f;
    private float timer;
    private bool hitDetected = false;
    public GameObject detectionCollider;
    public ParticleSystem hitParticle;
    public GameObject sonarParticle;
    private AudioSource audioSource;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(rb.velocity);
        detectionCollider.SetActive(false);
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
        if (collision.collider.tag != "Arrow")
        {
            hitDetected = true;
            GameObject sonarVFX = Instantiate(sonarParticle, transform.position, Quaternion.identity);
            audioSource.pitch = (Random.Range(0.8f, 1.2f));
            audioSource.Play();
            hitParticle.Play();
            Stick();
        }
    }

    private void Stick()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        detectionCollider.SetActive(true);
        Destroy(this.gameObject, 10f);
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, 4);
    }
}
