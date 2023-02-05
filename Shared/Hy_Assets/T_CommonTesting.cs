using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_CommonTesting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TTSPosNbInit();
        TTSTestingPosInit();
        TTSExpNbInit();
        TTSTestingExpInit();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public T_UserCheck _UserCheck;
    public T_ArrowPointer _ArrowPointer;
    public GameObject[] PosNbs;
    public GameObject[] ExpNbs;
    public GameObject[] Pos;
    public GameObject[] ExpObjs;
    public bool IsOnlyShow = false;
    public bool IsTTSTasting = false;

    // tts nb guide part
    public void TTSPosNbInit()
    {
        IsTTSTasting = false;
        PosNbs[0].SetActive(false);
    }
    public void TTSPosNbStart()
    {
        IsTTSTasting = true;
        PosNbs[0].SetActive(true);
        PosNbs[1].SetActive(true);
        PosNbs[2].SetActive(true);

    }
    public void TTSPosNbUpdate(int id, bool show)
    {
        if (show)
        {
            PosNbs[id].SetActive(true);
        }
        else
        {
            PosNbs[id].SetActive(false);
        }
    }
    public void TTSPosNbReset()
    {
        TTSPosNbInit();
        PosNbs[8].GetComponent<ReStart>().Show_Menu();
        PosNbs[8].GetComponent<ReStart>().Hide_Menu();
    }

    // tts testing part
    public void TTSTestingPosInit()
    {
        IsTTSTasting = false;
        for (int i = 0; i < Pos.Length; i++)
        {
            Pos[i].GetComponent<T_FlashControl>().IsFlash = false;
            Pos[i].SetActive(false);
        }
        _ArrowPointer.ArrowpointersInit();
    }
    public void TTSTestingPosStart()
    {
        Debug.Log("flash testing");

        TTSPosNbInit();

        _UserCheck.CheckID = 0;
        if (IsOnlyShow)
        {
            IsTTSTasting = true;
            Pos[0].SetActive(true);
            Pos[0].GetComponent<T_FlashControl>().IsFlash = true;
        }
        else
        {
            IsTTSTasting = true;
            for (int i = 0; i < Pos.Length; i++)
            {
                Pos[i].SetActive(true);
            }
            Pos[0].GetComponent<T_FlashControl>().IsFlash = true;
        }

        ArrowpointersControl(0, true);
    }
    public void TTSTestingPosUpdate(int id)
    {
        if (IsOnlyShow)
        {
            for (int i = 0; i < Pos.Length; i++)
            {
                Pos[i].SetActive(false);
                if (i == id)
                {
                    Pos[i].SetActive(true);
                    Pos[i].GetComponent<T_FlashControl>().IsFlash = true;
                }
            }
        }
        else
        {
            for (int i = 0; i < Pos.Length; i++)
            {
                Pos[i].GetComponent<T_FlashControl>().IsFlash = false;
                if (i == id)
                {
                    Pos[i].GetComponent<T_FlashControl>().IsFlash = true;
                }
            }
        }
        _ArrowPointer.ArrowpointersUpdate(id);
    }
    public void TTSTestingPosReset()
    {
        TTSTestingPosInit();
        _UserCheck.CheckID = 0;
    }

    // tts nb exp part
    public void TTSExpNbInit()
    {
        IsTTSTasting = false;
        ExpNbs[0].SetActive(false);
    }
    public void TTSExpNbStart()
    {
        IsTTSTasting = true;
        ExpNbs[0].SetActive(true);
        ExpNbs[1].SetActive(true);
        ExpNbs[2].SetActive(true);
        ExpNbs[3].SetActive(false);
    }
    public void TTSExpNbUpdate(int id, bool show)
    {
        if (show)
        {
            ExpNbs[id].SetActive(true);
        }
        else
        {
            ExpNbs[id].SetActive(false);
        }
    }
    public void TTSExpNbReset()
    {
        TTSExpNbInit();
        ExpNbs[8].GetComponent<ReStart>().Show_Menu();
        ExpNbs[8].GetComponent<ReStart>().Hide_Menu();
        TTSExpNbStart();
    }

    // tts nb testing part
    public void TTSTestingExpInit()
    {
        IsTTSTasting = false;
        for (int i = 0; i < ExpObjs.Length; i++)
        {
            ExpObjs[i].GetComponent<T_FlashControl>().IsFlash = false;
            ExpObjs[i].SetActive(false);
        }
    }
    public void TTSTestingExpStart()
    {
        for (int i = 0; i < ExpObjs.Length; i++)
        {
            IsTTSTasting = true;
            ExpObjs[i].SetActive(true);
            if (i == 0)
            {
                ExpObjs[i].GetComponent<T_FlashControl>().IsFlash = true;
            }
        }
        TTSExpNbInit();
        IsTTSTasting = true;
        ArrowpointersControl(4, true);
    }
    public void TTSTestingExpUpdate(int id)
    {
        for (int i = 0; i < ExpObjs.Length; i++)
        {
            ExpObjs[i].GetComponent<T_FlashControl>().IsFlash = false;
            if (i == id)
            {
                ExpObjs[i].GetComponent<T_FlashControl>().IsFlash = true;
            }
        }
    }
    public void TTSTestingExpReset()
    {
        TTSTestingExpInit();
        _UserCheck.CheckID = 0;
    }

    // other
    public void ArrowpointersControl(int id, bool show)
    {
        if (show)
        {
            _ArrowPointer._Arrowpointers[id].SetActive(true);
        }
        else
        {
            _ArrowPointer._Arrowpointers[id].SetActive(false);
        }
    }
}
