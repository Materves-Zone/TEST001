using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MaterialFlash();
    }

    /// <summary>
    /// Flash
    /// </summary>
    public bool IsFlash;
    public float FlashTime;
    public float FlashIntensity;
    public Color _Color;
    public int PillarID = -1;
    private float EmissionIntensity;
    private int PrivatePillarID;

    public void MaterialFlash()
    {
        if (IsFlash)
        {
            EmissionIntensity = Mathf.Lerp(EmissionIntensity, FlashIntensity, FlashTime);
            this.GetComponentInChildren<Renderer>().material.SetColor("_EmissionColor", _Color * EmissionIntensity);

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
