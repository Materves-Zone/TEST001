using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_UserCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UserCheckInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public T_FlashTesting t_FlashTesting;
    public int CheckID;

    private void UserCheckInit()
    {
        CheckID = 0;
    }
    private void UserCheckStart()
    {
        CheckID = 0;
    }
    private void UserCheckUpdate()
    {

    }
    private void UserCheckReset()
    {
        UserCheckInit();
    }
    private void OnTriggerEnter(Collider other)
    {
        // 1.flash nb pos part
        if(other.name == "InsideCircle" && t_FlashTesting.IsFlashTasting)
        {
            /*
             * 1.enter the start circle to trigger the nb part
             * 2.nb part start()
             */
            Debug.Log("start nb pos guide");
            t_FlashTesting.FlashPosNbUpdate(3, true);
            t_FlashTesting.FlashPosNbUpdate(4, true);
        }
        if(other.name == "FlashNbPos" && t_FlashTesting.IsFlashTasting)
        {
            t_FlashTesting.FlashPosNbUpdate(5, true);
            t_FlashTesting.FlashPosNbUpdate(6, false);
            t_FlashTesting.FlashPosNbUpdate(7, false);
        }
        // 2.flash testing pos part
        if(other.tag == "Pos" && t_FlashTesting.IsFlashTasting)
        {
            if(CheckID == other.GetComponent<T_FlashControl>().PillarID && CheckID< t_FlashTesting.Pos.Length-1)
            {
                CheckID++;
                t_FlashTesting.FlashTestingPosUpdate(CheckID);
            }
            if (CheckID == other.GetComponent<T_FlashControl>().PillarID && CheckID == t_FlashTesting.Pos.Length-1)
            {
                Debug.Log("testing flash successfully!");
                t_FlashTesting.FlashTestingPosUpdate(999);
                CheckID = 999;
                // start to nb exp guide part
            }
        }
        // 3.flash nb exp part
        // 4.flash testing exp part
    }
}
