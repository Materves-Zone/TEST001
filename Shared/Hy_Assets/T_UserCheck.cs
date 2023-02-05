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
        if(other.name == "FlashPosInsideCircle" && t_FlashTesting.IsFlashTasting)
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
                t_FlashTesting.FlashExpNbStart();
            }
        }
        // 3.flash nb exp part
        if(other.name == "FlashExpInsideCircle" && t_FlashTesting.IsFlashTasting)
        {
            Debug.Log("start exp pos guide");
            t_FlashTesting.FlashExpNbUpdate(3, true);
            t_FlashTesting.FlashExpNbUpdate(4, true);
        }
        if (other.name == "Object" && t_FlashTesting.IsFlashTasting)         
        {
            Debug.Log("restart or next part");
            t_FlashTesting.FlashExpNbUpdate(5, true);
            t_FlashTesting.FlashExpNbUpdate(6, false);
            t_FlashTesting.FlashExpNbUpdate(7, false);
        }
        // 4.flash testing exp part
        if (other.tag == "Exp" && t_FlashTesting.IsFlashTasting)
        {
            if (other.name == "PartA")
            {
                t_FlashTesting.FlashTestingExpUpdate(1);
            }
            else if (other.name == "PartB")
            {
                t_FlashTesting.FlashTestingExpUpdate(0);
                Debug.Log("flash testing is finishing!");
            }
        }
    }
}
