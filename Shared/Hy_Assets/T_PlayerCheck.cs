using UnityEngine;

public class T_PlayerCheck : MonoBehaviour
{
    private void Awake()
    {
        PlayerCheckInit();
    }
    
    public int CheckID;
    private T_Manager tmanager;

    public void PlayerCheckInit()
    {
        CheckID = 0;
        tmanager = GameObject.Find("Manager").GetComponent<T_Manager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Start point → Flash Nb Pos guide
        if(other.tag == "StartPos" && tmanager.IsTestingFlash)
        {
            Debug.Log("!!!");
            //显示柱子和箭头并引导语
            tmanager.Scene_FlashNBPosUpdate(2);      
            tmanager.Scene_FlashNBPosUpdate(3);
        }
        // Flash Nb Pos guide → flash pos task
        if (other.name == "FlashPos" && tmanager.IsTestingFlash)
        {
            Debug.Log("Flash pos guide finished and start to flash pos task");
            tmanager.Scene_FlashNBPosUpdate(4);
            //tmanager.Scene_FlashTestingStart();
        }
        // Flash pos testing
        if (other.tag == "Pillar" && CheckID == other.GetComponent<T_FlashControl>().PillarID && tmanager.IsTestingFlash)
        {
            CheckID++;
            if(CheckID < tmanager._pointsPos.Length)
            {
                tmanager.Co_PointerArrowUpdate(CheckID);
            }
             
            //Debug.Log("pillar :" + CheckID);

            // To do something ...
            tmanager.Scene_FlashTestingUpdate(CheckID);
        }
        // Flash pos testing → Flash Nb Exp guide
        if (CheckID == tmanager._pointsPos.Length && tmanager.IsTestingFlash)
        {
            // show exihibitor gameobject
            // tmanager.Co_ExihibitorStart(0);
            // timeline show
        }
        // Flash Nb Exp → flash task
        if (other.name == "FlashExp" && tmanager.IsTestingFlash)
        {

        }
        
        

        // TTS testing
        if (other.tag == "Pillar" && CheckID == other.GetComponent<T_FlashControl>().PillarID && tmanager.IsTestingTTS)
        {
            CheckID++;
            //if (CheckID < tmanager._pointsPos.Length)
            //{
            //    tmanager.Co_PointerArrowUpdate(CheckID);
            //}

            Debug.Log("pillar :" + CheckID);
            tmanager.Scene_TTSUpdate(CheckID);
        }
        if (CheckID == tmanager._pointsPos.Length && tmanager.IsTestingTTS)
        {
            // show exihibitor gameobject
            tmanager.Co_ExihibitorStart(1);
        }

        // Avatar testing
        if (other.tag == "Pillar" && CheckID == other.GetComponent<T_FlashControl>().PillarID && tmanager.IsTestingAvatar)
        {
            CheckID++;
            //if (CheckID < tmanager._pointsPos.Length)
            //{
            //    tmanager.Co_PointerArrowUpdate(CheckID);
            //}

            Debug.Log("1M");
            if (CheckID == tmanager._pointsPos.Length)
            {
                // show exihibitor gameobject
                Debug.Log("2M");
                tmanager.Scene_AvatarChangeFIndObj();
                tmanager.Co_ExihibitorStart(2);

                return;
            }

            tmanager.Scene_AvatarUpdate(CheckID);
            tmanager.Scene_AvatarTTSUpdate(CheckID);
        }
    }
}
