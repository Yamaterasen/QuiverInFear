using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Victory : MonoBehaviour
{
    [SerializeField] GameObject victoryScreen;
    private AudioSource audioSource;
    [SerializeField] GameObject enemies;
    [SerializeField] AudioSource victoryMusic;
    [SerializeField] AudioMixerSnapshot Snap4;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        enemies.SetActive(false);
        audioSource.Play();
        victoryScreen.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        Snap4.TransitionTo(0f);
        victoryMusic.time = 48;
    }
}
