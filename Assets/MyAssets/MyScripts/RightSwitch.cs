using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RightSwitch : MonoBehaviour
{    
    private AudioSource audioSource;
    [SerializeField] GameObject topDoor;
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

        if (other.gameObject.CompareTag("PiercingArrow") && damaged == false)
        {
            AudioSource.PlayClipAtPoint(damagedSound, transform.position);
            pointLight.color = Color.green;
            LeanTween.moveLocalY(topDoor, 7f, 2f);
            damaged = true;
        }
    }
}
