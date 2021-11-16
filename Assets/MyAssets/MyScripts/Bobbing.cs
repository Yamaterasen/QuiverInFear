using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bobbing : MonoBehaviour
{
    [SerializeField] float verticalmovement;
    void Start()
    {
        LeanTween.moveLocalY(gameObject, verticalmovement, 2f).setEaseInOutSine().setLoopPingPong();
    }
}
