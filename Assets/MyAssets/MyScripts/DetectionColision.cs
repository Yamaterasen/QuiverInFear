using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionColision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            if (other.gameObject.GetComponent<Outline>() == null)
            {
                var outline = other.gameObject.AddComponent<Outline>();

                outline.OutlineMode = Outline.Mode.OutlineHidden;
                outline.OutlineColor = Color.red;
                outline.OutlineWidth = 5f;
            }
            else
            {
                return;
            }
        }

        if (other.tag == "StationaryEnemy")
        {
            if(other.gameObject.GetComponent<Outline>() == null)
            {
                var outline = other.gameObject.AddComponent<Outline>();

                outline.OutlineMode = Outline.Mode.OutlineHidden;
                outline.OutlineColor = Color.red;
                outline.OutlineWidth = 5f;
            }
            else
            {
                return;
            }
        }

        if (other.tag == "Powerline")
        {
            if (other.gameObject.GetComponent<Outline>() != null)
            {
                var outline = other.gameObject.GetComponent<Outline>();
                outline.OutlineColor = Color.cyan;
                outline.OutlineWidth = 5f;
                
            }
            else
            {
                return;
            }
        }
    }
}
