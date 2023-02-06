using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_FlashTesting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FlashPosNbInit();
        FlashTestingPosInit();
        FlashExpNbInit();
        FlashTestingExpInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public T_UserCheck _UserCheck;
    public T_ArrowPointer _ArrowPointer;
    public GameObject[] FlashPosNbs;
    public GameObject[] FlashExpNbs;
    public GameObject[] Pos;
    public GameObject[] ExpObjs;
    public bool IsOnlyShow = false;
    public bool IsFlashTasting = false;

    // flash nb guide part
    public void FlashPosNbInit()
    {
        IsFlashTasting = false;
        FlashPosNbs[0].SetActive(false);
    }
    public void FlashPosNbStart()
    {
        IsFlashTasting = true;
        FlashPosNbs[0].SetActive(true);
        FlashPosNbs[1].SetActive(true);
        FlashPosNbs[2].SetActive(true);

    }
    public void FlashPosNbUpdate(int id, bool show)
    {
        if(show)
        {
            FlashPosNbs[id].SetActive(true);
        }
        else
        {
            FlashPosNbs[id].SetActive(false);
        }
    }
    public void FlashPosNbReset()
    {
        FlashPosNbInit();
        FlashPosNbs[8].GetComponent<ReStart>().Show_Menu();
        FlashPosNbs[8].GetComponent<ReStart>().Hide_Menu();
    }

    // flash testing part
    public void FlashTestingPosInit()
    {
        IsFlashTasting = false;
        for (int i = 0; i < Pos.Length; i++)
        {
            Pos[i].GetComponent<T_FlashControl>().IsFlash = false;
            Pos[i].SetActive(false);
        }
        _ArrowPointer.ArrowpointersInit();
    }
    public void FlashTestingPosStart()
    {
        Debug.Log("flash testing");
        
        FlashPosNbInit();

        _UserCheck.CheckID = 0;
        if (IsOnlyShow)
        {
            IsFlashTasting = true;
            Pos[0].SetActive(true);
            Pos[0].GetComponent<T_FlashControl>().IsFlash = true;
        }
        else
        {
            IsFlashTasting = true;
            for (int i = 0; i < Pos.Length; i++)
            {
                Pos[i].SetActive(true);
            }
            Pos[0].GetComponent<T_FlashControl>().IsFlash = true;
        }

        ArrowpointersControl(0, true);
    }
    public void FlashTestingPosUpdate(int id)
    {
        if(IsOnlyShow)
        {
            for (int i = 0; i < Pos.Length; i++)
            {
                Pos[i].SetActive(false);
                if (i==id)
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
    public void FlashTestingPosReset()
    {
        FlashTestingPosInit();
        _UserCheck.CheckID = 0;
    }

    // flash nb exp part
    public void FlashExpNbInit()
    {
        IsFlashTasting = false;
        FlashExpNbs[0].SetActive(false);
    }
    public void FlashExpNbStart(int id)
    {
        IsFlashTasting = true;
        if (id==0)
        {
            FlashExpNbs[0].SetActive(true);
            FlashExpNbs[1].SetActive(false);
            FlashExpNbs[2].SetActive(false);
            FlashExpNbs[3].SetActive(false);
            FlashExpNbs[10].SetActive(true);
        }
        else if(id == 1)
        {
            FlashExpNbs[0].SetActive(true);
            FlashExpNbs[1].SetActive(true);
            FlashExpNbs[2].SetActive(true);
            FlashExpNbs[3].SetActive(false);
            FlashExpNbs[10].SetActive(false);
        }

    }
    public void FlashExpNbUpdate(int id, bool show)
    {
        if (show)
        {
            FlashExpNbs[id].SetActive(true);
        }
        else
        {
            FlashExpNbs[id].SetActive(false);
        }
    }
    public void FlashExpNbReset()
    {
        FlashExpNbInit();
        FlashExpNbs[8].GetComponent<ReStart>().Show_Menu();
        FlashExpNbs[8].GetComponent<ReStart>().Hide_Menu();
        FlashExpNbStart(1);
    }

    // flash nb testing part
    public void FlashTestingExpInit()
    {
        IsFlashTasting = false;
        for (int i = 0; i < ExpObjs.Length; i++)
        {
            ExpObjs[i].GetComponent<T_FlashControl>().IsFlash = false;
            ExpObjs[i].SetActive(false);
        }
    }
    public void FlashTestingExpStart()
    {
        for (int i = 0; i < ExpObjs.Length; i++)
        {
            IsFlashTasting = true;
            ExpObjs[i].SetActive(true);
            if (i == 0) 
            {
                ExpObjs[i].GetComponent<T_FlashControl>().IsFlash = true;
            }
        }
        FlashExpNbInit();
        IsFlashTasting = true;
        ArrowpointersControl(4, true);
    }
    public void FlashTestingExpUpdate(int id)
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
    public void FlashTestingExpReset()
    {
        FlashTestingExpInit();
        _UserCheck.CheckID = 0;
    }

    // other
    public void ArrowpointersControl(int id, bool show)
    {
        if(show)
        {
            _ArrowPointer._Arrowpointers[id].SetActive(true);
        }
        else
        {
            _ArrowPointer._Arrowpointers[id].SetActive(false);
        }
    }
}
