using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPointerControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PointInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int PillarsID;
    private DirectionalIndicator directionalIndicator;
    private Manager manager;

    private void PointInit()
    {
        directionalIndicator = this.GetComponent<DirectionalIndicator>();
        manager = GameObject.Find("Manager").GetComponent<Manager>();

        directionalIndicator.DirectionalTarget = manager.Pillars[0].transform;
    }

    public void PointUpdate()
    {
        Debug.Log("target change");
        directionalIndicator.DirectionalTarget = manager.Pillars[PillarsID].transform;
    }

}
