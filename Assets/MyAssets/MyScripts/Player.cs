using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Audio;

public class Player : MonoBehaviour
{
    [SerializeField] int playerHealth = 20;
    [SerializeField] Slider playerHealthSlider;
    [SerializeField] int healthMax;
    [SerializeField] AudioClip DamagedSound;
    [SerializeField] bool currentlyPause = false;
    [SerializeField] GameObject DeathScreen;
    [SerializeField] GameObject GameplayScreen;
    [SerializeField] GameObject VictoryScreen;
    [SerializeField] GameObject PauseScreen;
    [SerializeField] AudioMixerSnapshot Snap2;
    [SerializeField] GameObject Enemies;
    private AudioSource audioSource;
    private Vignette vignette;
    public PostProcessVolume postProcessVolume;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && DeathScreen.activeSelf == false && VictoryScreen.activeSelf == false && PauseScreen.activeSelf == false)
        {
            PauseScreen.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && DeathScreen.activeSelf == false && VictoryScreen.activeSelf == false && PauseScreen.activeSelf == true)
        {
            PauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        postProcessVolume.profile.TryGetSettings<Vignette>(out vignette);
        playerHealthSlider.maxValue = healthMax;
        playerHealthSlider.value = playerHealth;
        playerHealth = healthMax;
        Time.timeScale = 1f;
        
    }
    public void TakeDamage(int playerDamage)
    {
        playerHealth = playerHealth - playerDamage;
        audioSource.pitch = (Random.Range(0.8f, 1.2f));
        audioSource.PlayOneShot(DamagedSound);
        vignette.intensity.value = .55f;
        vignette.color.value = Color.red;
        StartCoroutine(FadeVignetteBack(0f, 1.0f));
        StartCoroutine(FadetoBlack(.232f, 1.0f));
        playerHealthSlider.value = playerHealth;

        //Death Screen
        if(playerHealth <= 0)
        {
            DeathScreen.SetActive(true);
            GameplayScreen.SetActive(false);
            Enemies.SetActive(false);
            Snap2.TransitionTo(1f);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            
        }
    }

    public void VignetteFadeBack()
    {
        LeanTween.value(vignette.intensity.value, .232f, 1f).setEaseInOutSine();
        LeanTween.value(vignette.color.value.r, 0, 1f).setEaseInOutSine();
    }

    IEnumerator FadeVignetteBack(float aValue, float aTime)
    {
        float alpha = vignette.color.value.r;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(Mathf.Lerp(alpha, aValue, t), 0, 0, 1);
            vignette.color.value = newColor;
            yield return null;
        }
    }

    IEnumerator FadetoBlack(float bValue, float aTime)
    {
        float beta = vignette.intensity.value;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            float originalvignetteintensity = Mathf.Lerp(beta, bValue, t);
            vignette.intensity.value = originalvignetteintensity;
            yield return null;
        }
    }
}
