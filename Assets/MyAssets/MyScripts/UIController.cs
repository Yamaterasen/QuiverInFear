using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject abilityHighlighter;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            LeanTween.moveLocalX(abilityHighlighter, 206.8337f, .1f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            LeanTween.moveLocalX(abilityHighlighter, 263.3257f, .1f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            LeanTween.moveLocalX(abilityHighlighter, 317.99542f, .1f);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            LeanTween.moveLocalX(abilityHighlighter, 378.13211f, .1f);
        }
    }
}
