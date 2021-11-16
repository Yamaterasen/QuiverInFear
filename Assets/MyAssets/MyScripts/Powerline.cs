using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerline : MonoBehaviour
{
    private Outline outline;
    [SerializeField] bool outlineActive = false;

    private void Start()
    {
        outline = GetComponent<Outline>();
    }

    private void Update()
    {
        if(outline)
        {
            outline.OutlineWidth -= .5f * Time.deltaTime;
            if(outline.OutlineWidth <= 0)
            {
                outlineActive = false;
                outline.OutlineWidth = 0;
            }    
        }
    }
}
