using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_TTSTesting : MonoBehaviour
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
    public AudioSource _AudioSource;
    public T_ArrowPointer _ArrowPointer;
    public GameObject[] PosNbs;
    public GameObject[] ExpNbs;
    public GameObject[] Pos;
    public GameObject[] ExpObjs;
    public AudioClip[] TTSClips;
    public bool IsOnlyShow = false;
    public bool IsTTSTasting = false;

    // tts nb guide part
    public void TTSPosNbInit()
    {
        IsTTSTasting = false;
        PosNbs[0].SetActive(false);
    }
    public void TTSPosNbStart(int id)
    {
        IsTTSTasting = true;
        if (id == 0)
        {
            PosNbs[0].SetActive(true);
            PosNbs[1].SetActive(true);
            PosNbs[2].SetActive(true);
        }

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
        Debug.Log("TTSPosNbReset");
        TTSPosNbInit();
        PosNbs[8].GetComponent<ReStart>().Show_Menu();
        PosNbs[8].GetComponent<ReStart>().Hide_Menu();
        TTSPosNbStart(0);
        PosNbs[3].SetActive(false);
    }

    // tts testing part
    public void TTSTestingPosInit()
    {
        IsTTSTasting = false;
        for (int i = 0; i < Pos.Length; i++)
        {
            Pos[i].GetComponent<MeshRenderer>().enabled = true;
            Pos[i].SetActive(false);
        }
        _ArrowPointer.ArrowpointersInit();
        _AudioSource.playOnAwake = false;
        _AudioSource.PlayOneShot(null);
    }
    public void TTSTestingPosStart()
    {
        Debug.Log("flash testing");
        TTSPosNbInit();
        IsTTSTasting = true;
        _UserCheck.CheckID = 0;

        for (int i = 0; i < Pos.Length; i++)
        {
            Pos[i].GetComponent<MeshRenderer>().enabled = true;
            Pos[i].SetActive(true);
        }

        TTSTestingPosUpdate(0);

        ArrowpointersControl(0, true);
    }
    public void TTSTestingPosUpdate(int id)
    {
        if(id < TTSClips.Length)
        {
            if (_AudioSource.isPlaying == true)
            {
                _AudioSource.Stop();
            }
            _AudioSource.PlayOneShot(TTSClips[id]);

            ArrowpointersControl(id, true);
        }
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
    public void TTSExpNbStart(int id)
    {
        if (id == 0)
        {
            ExpNbs[0].SetActive(true);
            ExpNbs[10].SetActive(true);
        }
        else if(id == 1)
        {
            ExpNbs[0].SetActive(true);
            ExpNbs[1].SetActive(true);
            ExpNbs[2].SetActive(true);
            ExpNbs[3].SetActive(false);
            ExpNbs[10].SetActive(false);

            //TTSTestingPosInit();
        }

        IsTTSTasting = true;
        _ArrowPointer.ArrowpointersInit();
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
        TTSExpNbStart(1);
    }

    // tts nb testing part
    public void TTSTestingExpInit()
    {
        IsTTSTasting = false;
        for (int i = 0; i < ExpObjs.Length; i++)
        {
            ExpObjs[i].SetActive(false);
        }
    }
    public void TTSTestingExpStart()
    {
        for (int i = 0; i < ExpObjs.Length; i++)
        {
            IsTTSTasting = true;
            ExpObjs[i].SetActive(true);
        }
        TTSExpNbInit();
        IsTTSTasting = true;
        TTSTestingPosUpdate(4); // Testing as 1 but real not
        ArrowpointersControl(4, true);
    }
    public void TTSTestingExpUpdate(int id)
    {
        TTSTestingPosUpdate(id); // Testing as 1 but real not -
    }
    public void TTSTestingExpReset()
    {
        TTSTestingExpInit();
        _UserCheck.CheckID = 0;
    }

    // other
    public void ArrowpointersControl(int id, bool show)
    {
        for (int i = 0; i < _ArrowPointer._Arrowpointers.Length; i++)
        {
            _ArrowPointer._Arrowpointers[i].SetActive(false);
        }

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
