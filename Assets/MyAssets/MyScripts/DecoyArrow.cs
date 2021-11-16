using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoyArrow : MonoBehaviour
{
    Rigidbody rb;
    private float lifeTime = 2f;
    private float timer;
    private bool hitDetected = false;
    public GameObject decoyObj;
    private bool decoySummoned;
    public ParticleSystem hitParticle;
    private AudioSource audioSource;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(rb.velocity);
        decoySummoned = false;
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
            audioSource.pitch = (Random.Range(0.8f, 1.2f));
            audioSource.Play();
            hitParticle.Play();
            StickSummon();
            Destroy(gameObject, 11f);
        }
    }

    private void StickSummon()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;

        if(decoySummoned == false)
        {
            GameObject decoy = Instantiate(decoyObj, transform.position, Quaternion.Euler(0, Random.Range(0f, 360f), 0));
            Destroy(decoy, 10f);
            decoySummoned = true;
        }
    }
}
