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
        // Flash testing
        if (other.tag == "Pillar" && CheckID == other.GetComponent<T_FlashControl>().PillarID && tmanager.IsTestingFlash)
        {
            CheckID++;
            if(CheckID < tmanager._pointsPos.Length)
            {
                tmanager.Co_PointerArrowUpdate(CheckID);
            }

            //Debug.Log("pillar :" + CheckID);
            if(CheckID == tmanager._pointsPos.Length)
            {
                // show exihibitor gameobject
                tmanager.Co_ExihibitorStart(0);
            }

            // To do something ...
            tmanager.Scene_FlashTestingUpdate(CheckID);
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
            if (CheckID == tmanager._pointsPos.Length)
            {
                // show exihibitor gameobject
                tmanager.Co_ExihibitorStart(1);
            }

            tmanager.Scene_TTSUpdate(CheckID);
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
