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

    public GameObject[] FlashPosNbs;
    public GameObject[] FlashExpNbs;
    public GameObject[] Pos;
    public GameObject[] ArrowPointers;
    public bool IsOnlyShow = false;
    public bool IsFlashTasting = false;

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

    public void FlashTestingPosInit()
    {
        IsFlashTasting = false;
        for (int i = 0; i < Pos.Length; i++)
        {
            Pos[i].GetComponent<T_FlashControl>().IsFlash = false;
            Pos[i].SetActive(false);
        }
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
    }
    public void FlashTestingPosReset()
    {
        FlashTestingPosInit();
        _UserCheck.CheckID = 0;
    }

    public void FlashExpNbInit()
    {

    }
    public void FlashExpNbStart()
    {

    }
    public void FlashExpNbUpdate()
    {

    }
    public void FlashExpNbReset()
    {

    }

    public void FlashTestingExpInit()
    {

    }
    public void FlashTestingExpStart()
    {

    }
    public void FlashTestingExpUpdate()
    {

    }
    public void FlashTestingExpReset()
    {

    }
}
