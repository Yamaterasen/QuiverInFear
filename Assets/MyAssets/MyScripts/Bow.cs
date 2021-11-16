using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bow : MonoBehaviour
{
    public float charge;
    public float chargeMax;
    public float chargeRate;
    public Rigidbody arrowObj;

    public Camera cam;
    public Rigidbody arrowPrefab;
    public Rigidbody DetectionArrowPrefab;
    public Rigidbody PiercingArrowPrefab;
    public Rigidbody DecoyArrowPrefab;
    public Transform arrowSpawn;
    public float shootForce = 20f;

    public GameObject outerReticle;
    private Vector3 originalReticleScale;


    private void Start()
    {
        arrowObj = arrowPrefab;
        originalReticleScale = outerReticle.transform.localScale;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && charge < chargeMax)
        {
            LeanTween.scale(outerReticle, new Vector3(0, 0, 0), 2f);
            charge += Time.deltaTime * chargeRate;
        }

        if (Input.GetMouseButtonUp(0))
        {
            LeanTween.cancel(outerReticle);
            LeanTween.scale(outerReticle, originalReticleScale, .1f);
            Rigidbody arrow = Instantiate(arrowObj, arrowSpawn.position, Quaternion.identity) as Rigidbody;
            arrow.AddForce(cam.transform.forward * charge, ForceMode.Impulse);
            charge = 0;
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            arrowObj = arrowPrefab;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            arrowObj = DetectionArrowPrefab;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            arrowObj = PiercingArrowPrefab;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            arrowObj = DecoyArrowPrefab;
        }
    }
}