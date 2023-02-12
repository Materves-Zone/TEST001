using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_UserTrigger : MonoBehaviour
{
    public int CheckID = 0;
    public F_FlashTesting f_FlashTesting;
    public F_TTSTesting f_TTSTesting;
    public F_AvatarTesting f_AvatarTesting;

    public void TriggerInit()
    {
        CheckID = 0;
    }
    public void OnTriggerEnter(Collider other)
    {
        if(f_FlashTesting.IsFlashTesting)
        {
            // nb flash pos and nb exp part
            switch (other.name)
            {
                case "FlashPosInsideCircle":
                    f_FlashTesting.NbFlashPosUpdate(0);
                    break;

                case "FlashNbPos":
                    f_FlashTesting.NbFlashPosUpdate(1);
                    break;

                case "FlashExpInsideCircle":
                    f_FlashTesting.NbFlashExpUpdate(0);
                    break;

                case "Object":
                    f_FlashTesting.NbFlashExpUpdate(1);
                    break;
            }
            // testing flash pos part
            if(other.tag == "Pos" && CheckID == other.transform.GetComponent<T_FlashControl>().PillarID)
            {
                CheckID++;
                if (CheckID < f_FlashTesting.PosPosition.Length)
                {
                    f_FlashTesting.TestingFlashPosUpdate(CheckID);
                }
                else if(CheckID == f_FlashTesting.PosPosition.Length)
                {
                    Debug.Log("start to nb exp part");
                    f_FlashTesting.TestingFlashPosUpdate(CheckID);
                    f_FlashTesting.NbFlashExpStart(0);
                    CheckID = 999;
                }
            }
            // testing flash exp part
            if(other.tag == "Exp")
            {
                switch (other.name)
                {
                    case "PartA":
                        f_FlashTesting.TestingFlashExpUpdate(0);
                        break;

                    case "PartB":
                        f_FlashTesting.TestingFlashExpUpdate(1);
                        break;
                }
            }
        }
        else if(f_TTSTesting.IsTTSTesting)
        {
            // nb tts pos and nb exp part 
            switch (other.name)
            {
                case "StandAreaTTSPos":
                    f_TTSTesting.NbTTSPosUpdate(0);
                    break;

                case "Apple_Pic":
                    f_TTSTesting.NbTTSPosUpdate(1);
                    break;

                case "StandAreaTTSExp":
                    f_TTSTesting.NbTTSExpUpdate(0);
                    break;

                case "Tree_Pic":
                    f_TTSTesting.NbTTSExpUpdate(1);
                    break;
            }
            // testing tts pos part
            if(other.tag == "Pos" && CheckID == other.transform.GetComponent<F_PosID>().PosID)
            {
                CheckID++;
                if(CheckID < f_TTSTesting.PosPosition.Length)
                {
                    f_TTSTesting.TestingTTSPosUpdate(CheckID);
                }
                else if(CheckID == f_TTSTesting.PosPosition.Length)
                {
                    Debug.Log("start to nb tts exp guide part");
                    f_TTSTesting.NbTTSExpStart(0);
                    CheckID = 999;
                }
            }
            // testing tts exp part
            if(other.tag == "Exp")
            {
                switch (other.name)
                {
                    case "PartA":
                        f_TTSTesting.TestingTTSExpUpdate(0);
                        break;

                    case "PartB":
                        f_TTSTesting.TestingTTSExpUpdate(1);
                        break;
                }
            }
        }
        else if (f_AvatarTesting.IsAvatarTesting)
        {
            // nb avatar pos and nb exp part
            switch (other.name)
            {
                case "StandAreaAvatarPos":
                    f_AvatarTesting.NbAvatarPosUpdate(0);
                    break;

                case "NbPosAvatarPillar":
                    f_AvatarTesting.NbAvatarPosUpdate(1);
                    break;

                case "StandAreaAvatarExp":
                    f_AvatarTesting.NbAvatarExpUpdate(0);
                    break;

                case "NbExpAvatarPillar":
                    Debug.Log("1");
                    f_AvatarTesting.NbAvatarExpUpdate(1);
                    break;
            }
            // testing avatar pos part
            if(other.tag == "Pos" && CheckID == other.transform.GetComponent<F_PosID>().PosID)
            {
                CheckID++;
                if (CheckID < f_AvatarTesting.PosPosition.Length)
                {
                    f_AvatarTesting.TestingAvatarPosUpdate(CheckID);
                }
                else if(CheckID == f_AvatarTesting.PosPosition.Length)
                {
                    Debug.Log("start to nb avatar exp guide part");
                    f_AvatarTesting.NbAvatarExpStart(0);
                    CheckID = 999;
                }
            }
            // testing avatar exp part
            if(other.tag == "Exp")
            {
                switch(other.name)
                {
                    case "PartA":
                        f_AvatarTesting.TestingAvatarExpUpdate(0);
                        break;

                    case "PartB":
                        f_AvatarTesting.TestingAvatarExpUpdate(1);
                        break;
                }
            }
        }
    }
}
