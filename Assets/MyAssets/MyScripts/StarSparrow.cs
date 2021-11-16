using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSparrow : MonoBehaviour
{
    [SerializeField] float Xposition = 200f;
    [SerializeField] float Zposition = 200f;
    [SerializeField] float time = 10f;
    void Start()
    {
        LeanTween.moveLocalX(gameObject, Xposition, time).setLoopClamp();
        LeanTween.moveLocalZ(gameObject, Zposition, time).setLoopClamp();
    }
}
