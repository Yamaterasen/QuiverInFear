using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class StationaryEnemy : MonoBehaviour
{
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public Rigidbody bullet;
    public Transform bulletSpawnLeft;
    public Transform bulletSpawnRight;
    public bool AttackModeActive;
    public GameObject currentTarget;
    [SerializeField] float bulletSpeed = 500f;
    [SerializeField] int rotateSmoothing = 5;
    [SerializeField] int enemyHealth = 2;
    [SerializeField] AudioClip explosionSound;
    public GameObject explosionPrefab;
    [SerializeField] AudioMixerSnapshot Snap1;
    [SerializeField] AudioMixerSnapshot Snap3;

    private void Start()
    {
        LeanTween.rotateAround(gameObject, Vector3.up, 360, 5f).setLoopClamp();
    }
    private void Update()
    {
        if(AttackModeActive==true)
        {
            Snap3.TransitionTo(1);
            var lookPos = currentTarget.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotateSmoothing);
            AttackMode(currentTarget);
        }
    }

    public void AttackMode(GameObject target)
    {
        AttackModeActive = true;
        LeanTween.cancel(gameObject);
        currentTarget = target;
        if (fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    private void Patrol()
    {
        LeanTween.rotateAround(gameObject, Vector3.up, 360, 5f).setLoopClamp();
    }

    void Shoot()
    {
        Rigidbody bulletPrefab = Instantiate(bullet, bulletSpawnLeft.position, Quaternion.identity) as Rigidbody;
        bulletPrefab.AddForce(bulletSpawnLeft.transform.forward * bulletSpeed, ForceMode.Impulse);
        Rigidbody bulletPrefab2 = Instantiate(bullet, bulletSpawnRight.position, Quaternion.identity) as Rigidbody;
        bulletPrefab2.AddForce(bulletSpawnRight.transform.forward * bulletSpeed, ForceMode.Impulse);
    }

    public void EnemyTakeDamage(int damage)
    {
        enemyHealth = enemyHealth - damage;
        if (enemyHealth <= 0)
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Snap1.TransitionTo(4);
            Destroy(this.gameObject);
        }
    }
}
