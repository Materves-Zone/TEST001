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

    public GameObject[] Pos;
    public bool IsOnlyShow = false;
    public bool IsFlashTasting = false;

    private void FlashPosNbInit()
    {

    }
    private void FlashPosNbStart()
    {

    }
    private void FlashPosNbUpdate()
    {

    }
    private void FlashPosNbResry()
    {

    }

    private void FlashTestingPosInit()
    {
        IsFlashTasting = false;
        for (int i = 0; i < Pos.Length; i++)
        {
            Pos[i].GetComponent<T_FlashControl>().IsFlash = false;
            Pos[i].SetActive(false);
        }
    }
    private void FlashTestingPosStart()
    {
        IsFlashTasting = true;
        Pos[0].SetActive(true);
        Pos[0].GetComponent<T_FlashControl>().IsFlash = true;
    }
    private void FlashTestingPosUpdate(int id)
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
    private void FlashTestingPosReset()
    {
        FlashTestingPosInit();
    }

    private void FlashExpNbInit()
    {

    }
    private void FlashExpNbStart()
    {

    }
    private void FlashExpNbUpdate()
    {

    }
    private void FlashExpNbReset()
    {

    }

    private void FlashTestingExpInit()
    {

    }
    private void FlashTestingExpStart()
    {

    }
    private void FlashTestingExpUpdate()
    {

    }
    private void FlashTestingExpReset()
    {

    }
}
