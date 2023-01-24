using UnityEngine;

public class Check_Trigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private int CheckID;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "Pillar")
    //    {
    //        Debug.Log("Enter");
    //        GameObject.Find("Manager").GetComponent<Manager>().IsFlash = false;
    //        GameObject.Find("Manager").GetComponent<Manager>().MaterialFlash();

    //        if(GameObject.Find("Manager").GetComponent<Manager>().PillarID < 3)
    //        {
    //            GameObject.Find("Manager").GetComponent<Manager>().PillarID++;
    //            GameObject.Find("Manager").GetComponent<Manager>().IsFlash = true;
    //        }

    //        other.GetComponent<Collider>().enabled = false;
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        // Flash
        if (other.tag == "Pillar" && CheckID ==other.GetComponent<PillarControl>().PillarID && GameObject.Find("Manager").GetComponent<Manager>().IsFlashTest)
        {
            CheckID++;
            Debug.Log("Next Flash");
            GameObject.Find("Manager").GetComponent<Manager>().FlashArray(CheckID);
            GameObject.Find("Manager").GetComponent<Manager>().PointArrowControl(CheckID);
        }
        // Show Flash ExiObj
        if (other.tag == "Pillar" && CheckID == 4 && GameObject.Find("Manager").GetComponent<Manager>().IsFlashTest)
        {
            GameObject.Find("Manager").GetComponent<Manager>().ExiObj.SetActive(true);
            GameObject.Find("Manager").GetComponent<Manager>().ExiObjAnimation();
        }

        // Avatar
        if (other.tag == "Pillar" && CheckID == other.GetComponent<PillarControl>().PillarID && GameObject.Find("Manager").GetComponent<Manager>().IsAvatarTest)
        {
            // Find pillars
            CheckID++;
            Debug.Log("Find the Next Pillar");
            GameObject.Find("Manager").GetComponent<Manager>().FindPillarID = CheckID;
            GameObject.Find("Manager").GetComponent<Manager>().AvatarControl();
            GameObject.Find("Manager").GetComponent<Manager>().PointArrowControl(CheckID);

            // Play avatar's TTS
            Debug.Log("Play avatar's TTS");

        }
        // Show Avatar ExiObj
        if (other.tag == "Pillar" && CheckID == 4 && GameObject.Find("Manager").GetComponent<Manager>().IsAvatarTest)
        {
            GameObject.Find("Manager").GetComponent<Manager>().ExiObj.SetActive(true);
            GameObject.Find("Manager").GetComponent<Manager>().AvatarFindExiObj();
            //GameObject.Find("Manager").GetComponent<Manager>().ExiObjAnimation();
        }

        // TTS
        if (other.tag == "Pillar" && CheckID == other.GetComponent<PillarControl>().PillarID && GameObject.Find("Manager").GetComponent<Manager>().IsTTSTest)
        {
            CheckID++;
            Debug.Log("Play Next TTS");
            GameObject.Find("Manager").GetComponent<Manager>().FindPillarID = CheckID;
            GameObject.Find("Manager").GetComponent<Manager>().TTSControl();
            GameObject.Find("Manager").GetComponent<Manager>().PointArrowControl(CheckID);
        }
        // TTS ExiObj
        if (other.tag == "Pillar" && CheckID == 4 && GameObject.Find("Manager").GetComponent<Manager>().IsTTSTest)
        {
            GameObject.Find("Manager").GetComponent<Manager>().ExiObj.SetActive(true);
            GameObject.Find("Manager").GetComponent<Manager>().TTSExiControl();
        }

        if (other.tag == "Pillar" && CheckID == other.GetComponent<PillarControl>().PillarID)
        {
            Debug.Log("~~~~~");
            CheckID++;
            GameObject.Find("Manager").GetComponent<Manager>().PointArrowControl(CheckID);
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Pillar")
    //    {
    //        Debug.Log("Exit");
    //    }
    //}
}
