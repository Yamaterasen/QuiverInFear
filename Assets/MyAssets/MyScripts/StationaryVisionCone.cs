using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryVisionCone : MonoBehaviour
{
    public StationaryEnemy EnemyParent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EnemyParent.AttackMode(other.gameObject);
        }

        if (other.gameObject.CompareTag("Decoy"))
        {
            EnemyParent.AttackMode(other.gameObject);
        }
    }
}
