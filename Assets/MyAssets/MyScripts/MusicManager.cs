using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    public AudioMixerSnapshot Snap1;
    private void Start()
    {
        Snap1.TransitionTo(0);
    }
}
