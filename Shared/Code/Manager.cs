using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject[] Pillars;
    public GameObject ExiObj;
    public GameObject[] ExiObjs;
    public int TotalPillars;
    public bool IsFlashTest;
    public bool IsAvatarTest;
    public bool IsTTSTest;
    public int FindPillarID;

    // Initial
    public void Init()
    {
        TotalPillars = Pillars.Length;
        if(IsFlashTest)
        {
            Pillars[0].GetComponent<PillarControl>().IsFlash = true;
        }
        else
        {
            Pillars[0].GetComponent<PillarControl>().IsFlash = false;
        }

        if(IsAvatarTest)
        {
            GameObject.Find("Avatar_Guider").SetActive(true);
            GameObject.Find("Avatar_Guider").GetComponent<AvatarGuider>().IsMove = true;
            GameObject.Find("Avatar_Guider").GetComponent<AvatarGuider>().IsStartGuide = true;
            GameObject.Find("Avatar_Guider").GetComponent<AvatarGuider>().PillarID = 0;
        }
        else
        {
            GameObject.Find("Avatar_Guider").SetActive(false);
        }

        if(IsTTSTest)
        {
            GameObject.Find("Avatar_Player").GetComponent<TTS>().TTSRePlay(0);
        }
        else
        {
            GameObject.Find("Avatar_Player").GetComponent<TTS>().TTSStop();
        }

        ExiObj.SetActive(false);
    }

    // Flash Control
    public void FlashArray(int FlashID)
    {
        if(IsFlashTest)
        {
            for (int i = 0; i < Pillars.Length; i++)
            {
                Pillars[i].GetComponent<PillarControl>().IsFlash = false;
                if (i == FlashID)
                {
                    Pillars[i].GetComponent<PillarControl>().IsFlash = true;
                }
            }
        }
    }

    // Avatar Control
    public void AvatarControl()
    {
        if (FindPillarID < TotalPillars)
        {
            GameObject.Find("Avatar_Guider").GetComponent<AvatarGuider>().PillarID = FindPillarID;
        }
    }
    public void AvatarFindExiObj()
    {
        StartCoroutine(AvatarFindObj());
    }
    private IEnumerator AvatarFindObj()
    {
        Debug.Log("Part A");
        GameObject.Find("Avatar_Guider").GetComponent<AvatarGuider>().IsMove = false;
        GameObject.Find("Avatar_Guider").GetComponent<AvatarGuider>().IsMovePart = true;
        GameObject.Find("Avatar_Guider").GetComponent<AvatarGuider>().ExiObjID = 0;
        yield return new WaitForSeconds(6f);
        Debug.Log("Part B");
        GameObject.Find("Avatar_Guider").GetComponent<AvatarGuider>().ExiObjID = 1;
        yield return new WaitForSeconds(1f);
    }

    // TTS Control
    public void TTSControl()
    {
        if (FindPillarID < TotalPillars)
        {
            GameObject.Find("Avatar_Player").GetComponent<TTS>().TTSRePlay(FindPillarID);
        }
    }
    public void TTSExiControl()
    {
        GameObject.Find("Avatar_Player").GetComponent<TTS>().TTSExiPlay();
    }

    // Exi Animation Control
    public void ExiObjAnimation()
    {
        ExiObj.GetComponent<Animator>().Play("ExiObjFlash");
    }

}
