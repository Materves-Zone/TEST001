using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_AvatarTesting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AvatarPosNbInit();
        AvatarTestingPosInit();
        AvatarExpNbInit();
        AvatarTestingExpInit();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public T_UserCheck _UserCheck;
    public T_ArrowPointer _ArrowPointer;
    public GameObject T_Avatar;
    public GameObject[] PosNbs;
    public GameObject[] ExpNbs;
    public GameObject[] Pos;
    public GameObject[] ExpObjs;
    public bool IsOnlyShow = false;
    public bool IsAvatarTesting = false;

    // avatar nb guide part
    public void AvatarPosNbInit()
    {
        IsAvatarTesting = false;
        PosNbs[0].SetActive(false);
        ArrowpointersControl(0, false);
        T_Avatar.SetActive(false);
        
    }
    public void AvatarPosNbStart()
    {
        IsAvatarTesting = true;

       PosNbs[0].SetActive(true);
       PosNbs[1].SetActive(true);
       PosNbs[2].SetActive(true); 

    }
    public void AvatarPosNbUpdate(int id, bool show)
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
    public void AvatarPosNbReset()
    {
        AvatarPosNbInit();
        PosNbs[8].GetComponent<ReStart>().Show_Menu();
        PosNbs[8].GetComponent<ReStart>().Hide_Menu();
        AvatarPosNbStart();
    }
    public void AvatarPosNbGuideTutorial()
    {
        AvatarPosNbUpdate(5, true);
        AvatarPosNbAnimationUpdate("NbPosAvatar", "NbAvatarFindPos");
    }

    // avatar testing part
    public void AvatarTestingPosInit()
    {
        IsAvatarTesting = false;
        for (int i = 0; i < Pos.Length; i++)
        {
            Pos[i].GetComponent<T_FlashControl>().IsFlash = true;
            Pos[i].SetActive(false);
        }
        //_ArrowPointer.ArrowpointersInit();
    }
    public void AvatarTestingPosStart()
    {
        Debug.Log("avatar pos testing");
        AvatarPosNbInit();
        T_Avatar.SetActive(true);
        ArrowpointersControl(0, true);
        IsAvatarTesting = true;

        _UserCheck.CheckID = 0;
        if (IsOnlyShow)
        {
            IsAvatarTesting = true;
            Pos[0].SetActive(true);
            Pos[0].GetComponent<T_FlashControl>().IsFlash = true;
        }
        else
        {
            IsAvatarTesting = true;
            for (int i = 0; i < Pos.Length; i++)
            {
                Pos[i].SetActive(true);
            }
            Pos[0].GetComponent<T_FlashControl>().IsFlash = true;
        }

        // Arrow ?
        //ArrowpointersControl(0, true);
        // avatar show and move to the pillar
        AvatarestingPosUpdate(0);
    }
    public void AvatarestingPosUpdate(int id)
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
        //_ArrowPointer.ArrowpointersUpdate(id);

        if(id == 0)
        {
            AvatarPosNbAnimationUpdate("Avatar(Test)", "Step1");
        }
        else if(id == 1)
        {
            AvatarPosNbAnimationUpdate("Avatar(Test)", "Step2");
        }
        else if (id == 2)
        {
            AvatarPosNbAnimationUpdate("Avatar(Test)", "Step3");
        }
        else if (id == 3)
        {
            AvatarPosNbAnimationUpdate("Avatar(Test)", "Step4");
        }
    }
    public void AvatarestingPosReset()
    {
        AvatarTestingPosInit();
        _UserCheck.CheckID = 0;
    }

    // avatar nb exp part
    public void AvatarExpNbInit()
    {
        IsAvatarTesting = false;
        ExpNbs[0].SetActive(false);
    }
    public void AvatarExpNbStart(int id)
    {
        IsAvatarTesting = true;
     
        if(id == 0)
        {
            ExpNbs[0].SetActive(true);
            ExpNbs[10].SetActive(true);
        }
        else if(id == 1)
        {
            ExpNbs[0].SetActive(true);
            ExpNbs[1].SetActive(true);
            ExpNbs[2].SetActive(true);
            ExpNbs[10].SetActive(false);
        }
    }
    public void AvatarExpNbUpdate(int id, bool show)
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
    public void AvatarExpNbReset()
    {
        AvatarExpNbInit();
        ExpNbs[8].GetComponent<ReStart>().Show_Menu();
        ExpNbs[8].GetComponent<ReStart>().Hide_Menu();
        AvatarExpNbStart(1);
    }
    public void AvatarExpNbGuideTutorial()
    {
        AvatarPosNbAnimationUpdate("NbAvatarExp", "NbAvatarFindPos");
        AvatarExpNbUpdate(11, true);
    }

    // avatar nb testing part
    public void AvatarTestingExpInit()
    {
        T_Avatar.SetActive(false);
        ArrowpointersControl(0, false);
        IsAvatarTesting = false;
        for (int i = 0; i < ExpObjs.Length; i++)
        {
            ExpObjs[i].GetComponent<T_FlashControl>().IsFlash = false;
            ExpObjs[i].SetActive(false);
        }
    }
    public void AvatarTestingExpStart()
    {
        for (int i = 0; i < ExpObjs.Length; i++)
        {
            IsAvatarTesting = true;
            ExpObjs[i].SetActive(true);
            if (i == 0)
            {
                ExpObjs[i].GetComponent<T_FlashControl>().IsFlash = true;
            }
        }
        AvatarExpNbInit();
        IsAvatarTesting = true;
        //ArrowpointersControl(4, true);
        T_Avatar.SetActive(true);
        ArrowpointersControl(0, true);
        AvatarPosNbAnimationUpdate("Avatar(Test)","Step8");
        AvatarPosNbAnimationUpdate("Avatar(Test)", "Step5");
    }
    public void AvatarTestingExpUpdate(int id)
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
    public void AvatarTestingExpReset()
    {
        AvatarTestingExpInit();
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
    public void AvatarPosNbAnimationUpdate(string objname, string animname)
    {
        GameObject.Find(objname).GetComponent<Animator>().Play(animname);
    }
}
