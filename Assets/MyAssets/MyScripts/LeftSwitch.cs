using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LeftSwitch : MonoBehaviour
{    
    private AudioSource audioSource;
    [SerializeField] GameObject bottomDoor;
    [SerializeField] bool damaged;
    [SerializeField] AudioClip damagedSound;
    [SerializeField] Light pointLight;
    private void Start()
    {
        damaged = false;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {

        if (damaged == false)
        {
            AudioSource.PlayClipAtPoint(damagedSound, transform.position);
            pointLight.color = Color.green;
            LeanTween.moveLocalY(bottomDoor, -4f, 2f);
            damaged = true;
        }
    }
}
