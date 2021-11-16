using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class Enemy : MonoBehaviour
{
    public Transform[] patrolpoints;
    [SerializeField] int speed;
    [SerializeField] int enemyHealth = 3;
    [SerializeField] AudioClip explosionSound;

    private int patrolpointIndex;
    private float distance;
    [SerializeField] float verticalMovement = 1f;
    [SerializeField] MeshCollider visionCone;
    [SerializeField] bool attackModeActive = false;

    [SerializeField] AudioMixerSnapshot Snap1;
    [SerializeField] AudioMixerSnapshot Snap3;    
    public GameObject swordBeam;
    public NavMeshAgent agent;
    public GameObject player;
    public GameObject currentTarget;
    public GameObject explosionPrefab;

    
    

    private void Start()
    {
        patrolpointIndex = 0;
        transform.LookAt(patrolpoints[patrolpointIndex].position);
        LeanTween.moveLocalY(gameObject, verticalMovement, 2f).setEaseInOutSine().setLoopPingPong();
        LeanTween.rotateAroundLocal(swordBeam, Vector3.left, 360f, 3f).setEaseOutExpo().setLoopClamp();
    }

    private void Update()
    {
        if(attackModeActive == false)
        {
            distance = Vector3.Distance(transform.position, patrolpoints[patrolpointIndex].position);
            if (distance < 2f)
            {
                IncreaseIndex();
            }
            Patrol();
        }
        if(attackModeActive == true)
        {
            Snap3.TransitionTo(.8f);
            AttackMode(currentTarget);
        }
    }

    void Patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void IncreaseIndex()
    {
        patrolpointIndex++;
        if (patrolpointIndex >= patrolpoints.Length)
        {
            patrolpointIndex = 0;
        }
        transform.LookAt(patrolpoints[patrolpointIndex].position);
    }


    public void AttackMode(GameObject target)
    {
        currentTarget = target;
        attackModeActive = true;
        agent.SetDestination(target.transform.position);
        swordBeam.SetActive(true);
        transform.LookAt(target.transform);
    }

    public void EnemyTakeDamage(int damage)
    {
        enemyHealth = enemyHealth - damage;
        if(enemyHealth <= 0)
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Snap1.TransitionTo(4);
            Destroy(this.gameObject);
        }
    }
}
