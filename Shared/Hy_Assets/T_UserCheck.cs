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
    public T_TTSTesting t_TTSTesting;
    public T_AvatarTesting t_AvatarTesting;
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
        // Flash Testing
        // 1.flash nb pos part
        if(other.name == "FlashPosInsideCircle" && t_FlashTesting.IsFlashTasting)
        {
            /*
             * 1.enter the start circle to trigger the nb part
             * 2.nb part start()
             */
            Debug.Log("start nb pos guide");
            t_FlashTesting.FlashPosNbUpdate(2, false);
            t_FlashTesting.FlashPosNbUpdate(3, true);
            t_FlashTesting.FlashPosNbUpdate(4, true);
        }
        if(other.name == "FlashNbPos" && t_FlashTesting.IsFlashTasting)
        {
            t_FlashTesting.FlashPosNbUpdate(4, false);
            t_FlashTesting.FlashPosNbUpdate(5,  true);
            t_FlashTesting.FlashPosNbUpdate(6, false);
            t_FlashTesting.FlashPosNbUpdate(7, false);
            t_FlashTesting.FlashPosNbUpdate(9, false);
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
                t_FlashTesting.FlashExpNbStart(0);
            }
        }
        // 3.flash nb exp part
        if(other.name == "FlashExpInsideCircle" && t_FlashTesting.IsFlashTasting)
        {
            Debug.Log("start exp pos guide");
            t_FlashTesting.FlashExpNbUpdate(2, false);
            t_FlashTesting.FlashExpNbUpdate(3, true);
            t_FlashTesting.FlashExpNbUpdate(4, true);
        }
        if (other.name == "Object" && t_FlashTesting.IsFlashTasting)         
        {
            Debug.Log("restart or next part");
            t_FlashTesting.FlashExpNbUpdate(5, true);
            t_FlashTesting.FlashExpNbUpdate(6, false);
            t_FlashTesting.FlashExpNbUpdate(7, false);
            t_FlashTesting.FlashExpNbUpdate(9, false);
        }
        // 4.flash testing exp part
        if (other.tag == "Exp" && t_FlashTesting.IsFlashTasting)
        {
            if (other.name == "PartA")
            {
                t_FlashTesting.FlashTestingExpUpdate(1);
                t_FlashTesting.ArrowpointersControl(4, false);
                t_FlashTesting.ArrowpointersControl(5, true);
            }
            else if (other.name == "PartB")
            {
                t_FlashTesting.FlashTestingExpUpdate(0);
                t_FlashTesting.ArrowpointersControl(4, true);
                t_FlashTesting.ArrowpointersControl(5, false);
                Debug.Log("flash testing is finishing!");
            }
        }

        // TTS Testing
        // 1.tts nb pos part
        if (other.name == "StandAreaTTSPos" && t_TTSTesting.IsTTSTasting)
        {
            Debug.Log("start nb pos guide");
            t_TTSTesting.TTSPosNbUpdate(2, false);
            t_TTSTesting.TTSPosNbUpdate(3, true);
            t_TTSTesting.TTSPosNbUpdate(4, true);
        }
        if (other.name == "Apple_Pic" && t_TTSTesting.IsTTSTasting)
        {
            t_TTSTesting.TTSPosNbUpdate(4, false);
            t_TTSTesting.TTSPosNbUpdate(5, true);
            t_TTSTesting.TTSPosNbUpdate(6, false);
            t_TTSTesting.TTSPosNbUpdate(7, false);
            t_TTSTesting.TTSPosNbUpdate(9, false);
        }
        // 2.tts testing part
        if (other.tag == "Pos" && t_TTSTesting.IsTTSTasting)
        {
            if (CheckID == other.GetComponent<T_FlashControl>().PillarID && CheckID < t_TTSTesting.Pos.Length - 1)
            {
                CheckID++;
                t_TTSTesting.TTSTestingExpUpdate(CheckID);
            }
            if (CheckID == other.GetComponent<T_FlashControl>().PillarID && CheckID == t_TTSTesting.Pos.Length - 1)
            {
                Debug.Log("testing flash successfully!");
                t_TTSTesting.TTSTestingExpUpdate(999);
                CheckID = 999;
                // start to nb exp guide part
                t_TTSTesting.TTSExpNbStart(0);
            }
        }
        // 3.tts nb exp part
        if (other.name == "StandAreaTTSExp" && t_TTSTesting.IsTTSTasting)
        {
            Debug.Log("start nb exp guide");
            t_TTSTesting.TTSExpNbUpdate(2,false);
            t_TTSTesting.TTSExpNbUpdate(3, true);
            t_TTSTesting.TTSExpNbUpdate(4, true);
        }
        if (other.name == "Tree_Pic" && t_TTSTesting.IsTTSTasting)
        {
            Debug.Log("arrive at the position");
            t_TTSTesting.TTSExpNbUpdate(5, true);
            t_TTSTesting.TTSExpNbUpdate(6, false);
            t_TTSTesting.TTSExpNbUpdate(7, false);
            t_TTSTesting.TTSExpNbUpdate(9, false);
        }
        // 4.tts testing part
        if(other.tag == "Exp" && t_TTSTesting.IsTTSTasting)
        {
            Debug.Log("start tts testing exp part");
            if(other.name == "PartA")
            {
                t_TTSTesting.TTSTestingExpUpdate(5);
                t_FlashTesting.ArrowpointersControl(4, false);
                t_FlashTesting.ArrowpointersControl(5, true);
            }
            else if(other.name == "PartB")
            {
                t_TTSTesting.TTSTestingExpUpdate(4);
                t_FlashTesting.ArrowpointersControl(4, true);
                t_FlashTesting.ArrowpointersControl(5, false);
                Debug.Log("flash testing is finishing!");
            }
        }

        // Avatar Testing
        // 1.avatar nb pos guide
        if (other.name == "StandAreaAvatarPos" && t_AvatarTesting.IsAvatarTesting)
        {
            Debug.Log("start avatar nb guide");
        }
        if(other.name == "" && t_AvatarTesting.IsAvatarTesting)
        {
            Debug.Log("show obj avatar nb guide");
        }
        // 2.avatar testing pos part
        if(other.tag=="Pos" && t_AvatarTesting.IsAvatarTesting)
        {

        }
        // 3.avatar nb exp part
        if(other.name=="StandAreaAvatarExp" && t_AvatarTesting.IsAvatarTesting)
        {

        }
        // 4.avatar testing exp
        if(other.tag=="Exp" && t_AvatarTesting.IsAvatarTesting)
        {

        }
    }
}
