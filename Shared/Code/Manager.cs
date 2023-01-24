using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    private void Awake()
    {
        SysInit();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Init();
    }

    // Update is called once per frame
    void Update()
    {
        Init();
    }

    public GameObject[] Pillars;
    public GameObject ExiObj;
    public GameObject[] ExiObjs;
    public GameObject[] PointArrows;
    public int TotalPillars;
    public bool IsFlashTest;
    public bool IsAvatarTest;
    public bool IsTTSTest;
    public bool IsStartTest = false;
    public int FindPillarID;

    // SystemInitial
    public void SysInit()
    {
        Debug.Log("System init!");
        for (int i = 0; i < PointArrows.Length; i++)
        {
            PointArrows[i].SetActive(false);
            PointArrows[0].SetActive(true);
        }
    }

    // TestingInitial
    public void Init()
    {
        if(IsStartTest)
        {
            TotalPillars = Pillars.Length;
            if (IsFlashTest)
            {
                Pillars[0].GetComponent<PillarControl>().IsFlash = true;
            }
            else
            {
                Pillars[0].GetComponent<PillarControl>().IsFlash = false;
            }

            if (IsAvatarTest)
            {
                GameObject.Find("Avatar_Guider").SetActive(true);
                GameObject.Find("Avatar_Guider").GetComponent<AvatarGuider>().IsMove = true;
                GameObject.Find("Avatar_Guider").GetComponent<AvatarGuider>().IsStartGuide = true;
                GameObject.Find("Avatar_Guider").GetComponent<AvatarGuider>().PillarID = 0;
                // TTS
                AvatarTTSInit();
            }
            else
            {
                GameObject.Find("Avatar_Guider").SetActive(false);
            }

            if (IsTTSTest)
            {
                GameObject.Find("Avatar_Player").GetComponent<TTS>().TTSRePlay(0);
            }
            else
            {
                GameObject.Find("Avatar_Player").GetComponent<TTS>().TTSStop();
            }

            ExiObj.SetActive(false);

            IsStartTest = false;
        }
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
            // pillars
            GameObject.Find("Avatar_Guider").GetComponent<AvatarGuider>().PillarID = FindPillarID;

            // avatar pillars
            GameObject.Find("Avatar_Guider").GetComponent<AvatarGuider>().TTSID = FindPillarID;
            GameObject.Find("Avatar_Guider").GetComponent<AvatarGuider>().AvatarTTS();
        }
    }
    public void AvatarFindExiObj()
    {
        StartCoroutine(AvatarFindObj());
    }
    private IEnumerator AvatarFindObj()
    {
        Debug.Log("Part A");
        // Find Pillars
        GameObject.Find("Avatar_Guider").GetComponent<AvatarGuider>().IsMove = false;
        GameObject.Find("Avatar_Guider").GetComponent<AvatarGuider>().IsMovePart = true;
        GameObject.Find("Avatar_Guider").GetComponent<AvatarGuider>().ExiObjID = 0;
        // TTS
        GameObject.Find("Avatar_Guider").GetComponent<AvatarGuider>().TTSID = 4;
        GameObject.Find("Avatar_Guider").GetComponent<AvatarGuider>().AvatarTTS();
        yield return new WaitForSeconds(6f);

        Debug.Log("Part B");
        GameObject.Find("Avatar_Guider").GetComponent<AvatarGuider>().ExiObjID = 1;
        // TTS
        GameObject.Find("Avatar_Guider").GetComponent<AvatarGuider>().TTSID = 4;
        GameObject.Find("Avatar_Guider").GetComponent<AvatarGuider>().AvatarTTS();
        yield return new WaitForSeconds(1f);
    }
    private void AvatarTTSInit()
    {
        GameObject.Find("Avatar_Guider").GetComponent<AvatarGuider>().AvatarTTS();
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

    // Pointer Arrow Control
    public void PointArrowControl(int PointerArrowID)
    {
        for (int i = 0; i < PointArrows.Length; i++)
        {
            PointArrows[i].SetActive(false);
            if (i == PointerArrowID)
            {
                PointArrows[i].SetActive(true);
            }
        }
    }

    // Mode Selection
    public void TestFlash()
    {
        IsFlashTest = true;
        IsTTSTest = false;
        IsAvatarTest = false;
        IsStartTest = true;
    }
    public void TestTTS()
    {
        IsFlashTest = false;
        IsTTSTest = true;
        IsAvatarTest = false;
        IsStartTest = true;
    }
    public void TestAvatar()
    {
        IsFlashTest = false;
        IsTTSTest = false;
        IsAvatarTest = true;
        IsStartTest = true;
    }
    public void TestReset()
    {
        Debug.Log("Reset Testing!");
        SceneManager.LoadScene("TestEnvironment(MR)", LoadSceneMode.Single);
    }
    
}
