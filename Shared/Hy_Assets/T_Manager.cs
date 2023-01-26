using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class T_Manager : MonoBehaviour
{
    // Before start
    private void Awake()
    {
        SysInit();
    }
    // Start is called before the first frame update
    void Start()
    {
        SysInit();
    }
    // Update is called once per frame
    void Update()
    {
        /*
        
        1.Testing reset
        2.Testing flash
        3.Testing tts
        4.Testing avatar
        
         */

        // Testing reset
        SysReset();
    }

    public GameObject[] _pointsPos;
    public GameObject[] _pointsArrows;
    public GameObject[] _exiObj;
    public AudioClip[] _tts;
    public Button[] _btns;

    public GameObject _playercheck;
    public GameObject _avatarguide;
    public GameObject _startpoint;
    public AudioSource _audiosource;
    public Toggle toggle;

    public bool IsTestingStart = false;
    public bool IsTestingReset = false;
    public bool IsTestingFlash = false;
    public bool IsTestingTTS = false;
    public bool IsTestingAvatar = false;
    public bool IsPointerDisappera = false;

    /// <summary>
    /// Main system
    /// </summary>
    public void SysInit()
    {
        IsTestingStart = true;

        IsTestingFlash = false;
        IsTestingTTS = false;
        IsTestingAvatar = false;

        Scene_FlashInit();
        Scene_TTSInit();
        Scene_AvatarInit();
        Co_PointerArrowInit();
        Co_ExihibitorInit();
        Co_StartPosInit();
        Co_PlayerCheckInit(); 
        UI_Init();
    }
    public void SysReset()
    {
        if(IsTestingReset)
        {
            Debug.Log("Testing reset successfully!");
            SysInit();
            IsTestingStart = true;
            IsTestingReset = false;
        }
    }

    /// <summary>
    /// Flash testing environment
    /// </summary>
    public void Scene_FlashInit()
    {
        toggle.interactable = true;
        toggle.isOn = false;
        IsTestingFlash = false;
        for (int i = 0; i < _pointsPos.Length; i++)
        {
            _pointsPos[i].GetComponent<MeshRenderer>().enabled = true;
            _pointsPos[i].SetActive(false);
        }
    }
    public void Scene_FlashTestingStart()
    {
        if(IsTestingStart)
        {
            IsPointerDisappera = toggle.isOn;
            toggle.interactable = false;

            for (int i = 0; i < _pointsPos.Length; i++)
            {
                _pointsPos[i].GetComponent<T_FlashControl>().IsFlash = false;
                _pointsPos[i].SetActive(true);

                if (i == 0)
                {
                    _pointsPos[i].GetComponent<T_FlashControl>().IsFlash = true;
                }
            }

            if (IsPointerDisappera)
            {
                for (int i = 0; i < _pointsPos.Length; i++)
                {
                    _pointsPos[i].GetComponent<T_FlashControl>().IsFlash = false;
                    _pointsPos[i].SetActive(false);

                    if (i == 0)
                    {
                        _pointsPos[i].SetActive(true);
                        _pointsPos[i].GetComponent<T_FlashControl>().IsFlash = true;
                    }
                }
            }

            IsTestingFlash = true;

            Co_PointerArrowStart();
        }
        
    }
    public void Scene_FlashTestingUpdate(int PosID)
    {
        if(IsTestingFlash)
        {
            if (PosID < _pointsPos.Length)
            {
                _pointsPos[PosID - 1].GetComponent<T_FlashControl>().IsFlash = false;
                _pointsPos[PosID].GetComponent<T_FlashControl>().IsFlash = true;

                if(IsPointerDisappera)
                {
                    _pointsPos[PosID - 1].SetActive(false);
                    _pointsPos[PosID].SetActive(true);
                }
            }
            if (PosID == _pointsPos.Length)
            {
                _pointsPos[PosID - 1].GetComponent<T_FlashControl>().IsFlash = false;
            }
        }
    }

    /// <summary>
    /// TTS testing environment
    /// </summary>
    public void Scene_TTSInit()
    {
        IsTestingTTS = false;
        _audiosource.playOnAwake = false;
        _audiosource.PlayOneShot(null);
    }
    public void Scene_TTSStart()
    {
        if(IsTestingStart)
        {
            _audiosource.PlayOneShot(_tts[0]);
            for (int i = 0; i < _pointsPos.Length; i++)
            {
                _pointsPos[i].GetComponent<T_FlashControl>().IsFlash = false;
                //_pointsPos[i].GetComponent<MeshRenderer>().enabled = false;
                _pointsPos[i].SetActive(true);
            }

            IsTestingTTS = true;

            Co_PointerArrowStart();
        }
    }
    public void Scene_TTSUpdate(int TTSID)
    {
        if(IsTestingTTS)
        {
            if (_audiosource.isPlaying)
            {
                _audiosource.Stop();
                _audiosource.PlayOneShot(_tts[TTSID]);
            }
            _audiosource.PlayOneShot(_tts[TTSID]);
        }
    }

    /// <summary>
    /// Avatar testing environment
    /// </summary>
    public void Scene_AvatarInit()
    {
        _avatarguide.SetActive(false);
    }
    public void Scene_AvatarStart()
    {
        if(IsTestingStart)
        {
            for (int i = 0; i < _pointsPos.Length; i++)
            {
                //_pointsPos[i].GetComponent<MeshRenderer>().enabled = false;
                _pointsPos[i].SetActive(true);
            }
            _avatarguide.SetActive(true);
            _avatarguide.GetComponent<T_AvatarControl>().AvatarTTSStart();
            _avatarguide.GetComponent<T_AvatarControl>().AvatarMoveStart();
            IsTestingAvatar = true;

            Co_PointerArrowStart();
        }
    }
    public void Scene_AvatarUpdate(int FindID)
    {
        if(IsTestingAvatar)
        {
            
            _avatarguide.GetComponent<T_AvatarControl>().PillarID = FindID;
            _avatarguide.GetComponent<T_AvatarControl>().IsMove = true;
            _avatarguide.GetComponent<T_AvatarControl>().IsMovePart = false;
        }
    }
    public void Scene_AvatarObjUpdate(int FindID)
    {
        if (IsTestingAvatar)
        {
            _avatarguide.GetComponent<T_AvatarControl>().ExiObjID = FindID;
            _avatarguide.GetComponent<T_AvatarControl>().IsMove = false;
            _avatarguide.GetComponent<T_AvatarControl>().IsMovePart = true;

        }
    }
    public void Scene_AvatarTTSUpdate(int FindID)
    {
        if (IsTestingAvatar)
        {
            _avatarguide.GetComponent<T_AvatarControl>().AvatarTTSUpdate(FindID);
        }
    }
    public void Scene_AvatarChangeFIndObj()
    {
        _avatarguide.GetComponent<T_AvatarControl>().IsMove = false;
        _avatarguide.GetComponent<T_AvatarControl>().IsMovePart = true;
    }

    /// <summary>
    /// Pointer arrow (Common)
    /// </summary>
    public void Co_PointerArrowInit()
    {
        for (int i = 0; i < _pointsArrows.Length; i++)
        {
            _pointsArrows[i].SetActive(false);
        }
    }
    public void Co_PointerArrowStart()
    {
        Co_PointerArrowUpdate(0);
    }
    public void Co_PointerArrowUpdate(int FindID)
    {
        for (int i = 0; i < _pointsArrows.Length; i++)
        {
            _pointsArrows[i].SetActive(false);
            if (i==FindID)
            {
                _pointsArrows[i].SetActive(true);
            }
        }
    }

    /// <summary>
    /// Exihibition object (Common)
    /// </summary>
    public void Co_ExihibitorInit()
    {
        for (int i = 0; i < _exiObj.Length; i++)
        {
            _exiObj[i].SetActive(false);
        }
    }
    public void Co_ExihibitorStart(int ShowTypeID)
    {
        for (int i = 0; i < _exiObj.Length; i++)
        {
            _exiObj[i].SetActive(true);
        }

        //1.flash
        //2.tts
        //3.avatar

        if (ShowTypeID == 0)
        {
            // ie animation
            StartCoroutine(IEFlash());
        }
        else if(ShowTypeID == 1)
        {
            // ie tts
            StartCoroutine(IETTS());
        }
        else if (ShowTypeID == 2)
        {
            // ie avatar
            StartCoroutine(IEAvatar());
        }
    }
    private IEnumerator IEFlash()
    {
        yield return new WaitForSeconds(1f);
        Co_PointerArrowUpdate(4);
        _exiObj[0].GetComponent<Animator>().Play("ExiObjFlash");
        yield return new WaitForSeconds(6f);
        Co_PointerArrowUpdate(5);

        StopCoroutine(IEFlash());
    }
    private IEnumerator IETTS()
    {
        yield return new WaitForSeconds(1f);
        Co_PointerArrowUpdate(4);
        Scene_TTSUpdate(0);
        yield return new WaitForSeconds(6f);
        Co_PointerArrowUpdate(5);
        Scene_TTSUpdate(1);

        StopCoroutine(IETTS());
    }
    private IEnumerator IEAvatar()
    {
        yield return new WaitForSeconds(1f);
        Co_PointerArrowUpdate(4);
        Scene_AvatarObjUpdate(1);
        Scene_AvatarTTSUpdate(0);
        yield return new WaitForSeconds(6f);
        Co_PointerArrowUpdate(5);
        Scene_AvatarObjUpdate(2);
        Scene_AvatarTTSUpdate(1);

        StopCoroutine(IEAvatar());
    }

    /// <summary>
    /// Start pointpos (Common)
    /// </summary>
    public void Co_StartPosInit()
    {
        _startpoint.SetActive(true);
    }

    /// <summary>
    /// Player (Common)
    /// </summary>
    public void Co_PlayerCheckInit()
    {
        _playercheck.GetComponent<T_PlayerCheck>().PlayerCheckInit();
    }

    /// <summary>
    /// UI (PC Testing)
    /// </summary>
    public void UI_Init()
    {
        _btns[0].onClick.AddListener(Btn_Reset);
        _btns[1].onClick.AddListener(Btn_TestingFlash);
        _btns[2].onClick.AddListener(Btn_TestingTTS);
        _btns[3].onClick.AddListener(Btn_TestingAvatar);
        
    }
    public void Btn_Reset()
    {
        Debug.Log("Reset");
        IsTestingReset = true;
    }
    public void Btn_TestingFlash()
    {
        if(IsTestingStart)
        {
            Debug.Log("Flash");
            // To do ...
            Scene_FlashTestingStart();
            IsTestingStart = false;
        }
    }
    public void Btn_TestingTTS()
    {

        if (IsTestingStart)
        {
            Debug.Log("TTS");
            // To do ...
            Scene_TTSStart();
            IsTestingStart = false;
        }
    }
    public void Btn_TestingAvatar()
    {

        if (IsTestingStart)
        {
            Debug.Log("Avatar");
            // To do ...
            Scene_AvatarStart();
            IsTestingStart = false;
        }
    }
}
