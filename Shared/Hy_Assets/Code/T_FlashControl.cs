using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_FlashControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MaterialFlashInit();
    }

    // Update is called once per frame
    void Update()
    {
        MaterialFlashUpdate();
    }

    /// <summary>
    /// Flash control
    /// </summary>
    public bool IsFlash;
    public float FlashTime;
    public float FlashIntensity;
    public Color _Color;
    public int PillarID;
    private float EmissionIntensity;
    private Renderer matrenderer;

    public void MaterialFlashInit()
    {
        matrenderer = this.GetComponentInChildren<Renderer>();
    }
    public void MaterialFlashUpdate()
    {
        if (IsFlash)
        {
            EmissionIntensity = Mathf.Lerp(EmissionIntensity, FlashIntensity, FlashTime);
            matrenderer.material.SetColor("_EmissionColor", _Color * EmissionIntensity);

            if (EmissionIntensity > FlashIntensity - 0.01f)
            {
                EmissionIntensity = 0;
            }
        }
        else
        {
            EmissionIntensity = 0;
            this.GetComponentInChildren<Renderer>().material.SetColor("_EmissionColor", _Color * EmissionIntensity);
        }
    }
}
