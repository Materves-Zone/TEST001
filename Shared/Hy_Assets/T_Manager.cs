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
    public GameObject[] _flashNbObjs;
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
    public bool IsTesterMode = false; // -- 测试员模式
    
    /*
     * 总共3种场景每个场景2种模式（寻路，探索）
     */
    //public bool IsNBFlashPosGuide = false;
    //public bool IsNBFlashExpGuide = false;
    //public bool IsNBTTSPosGuide = false;
    //public bool IsNBTTSExpGuide = false;
    //public bool IsNBAvatarPosGuide = false;
    //public bool IsNBAvatarExpGuide = false;

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
        Scene_FlashNBPosInit();
        //Scene_FlashNBExpInit();

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
    public void Scene_FlashNBPosInit()
    {
        for (int i = 0; i < _flashNbObjs.Length; i++)
        {
            _flashNbObjs[i].SetActive(false);
        }

        IsTestingFlash = false;
    }
    public void Scene_FlashNBPosStart()
    {
        _flashNbObjs[0].SetActive(true);
        _flashNbObjs[1].SetActive(true);

        IsTestingFlash = true;
    }
    public void Scene_FlashNBPosUpdate(int ID)
    {
        for (int i = 0; i < _flashNbObjs.Length; i++)
        {
            if(i == ID)
            {
                _flashNbObjs[i].SetActive(true);
            }
        }
    }
    public void Scene_FlashNBReset()
    {
        Scene_FlashNBPosInit();
        Scene_FlashNBPosStart();
    }

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
        if (IsTestingFlash)
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

            IsTestingStart = true;

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

    public void Scene_FlashNBExpInit()
    {

    }
    public void Scene_FlashNBExpStart()
    {

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

            //Co_PointerArrowStart();
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

            //Co_PointerArrowStart();
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
    /// Tester (Common)
    /// </summary>
    public void Co_TesterInit()
    {
        IsTesterMode = false;
    }
    public void Co_TesterStart()
    {

    }
    public void Co_TesterF_ShowMesh(bool IsMeshShow)// -- 测试员模式
    {
        if(IsTesterMode)
        {
            if(IsMeshShow)
            {
                /*
                 * 显示房间
                 * 显示柱子
                 * 开启可拖拽功能
                 */
            }
            else
            {
                /*
                 * 隐藏房间
                 * 隐藏柱子
                 * 关闭可拖拽功能
                 */
            }
        }
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
            //Scene_FlashTestingStart();
            Scene_FlashNBPosStart();
            IsTestingStart = false;
        }
    } // ++ 改 20230202
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
    public void Btn_TesterMode() // -- 测试员模式
    {
        /*
        0. 第一次点击鼠标
        1. 进入测试员模式 true
        2. 显示物体场景
        3. 可拖拽功能开启
        4. 点击事件 ID = 1
        4. 第二次点击鼠标
        5. 隐藏物体
        6. 退出测试员模式 fale
        7. 重置点击事件 ID = 0
         */
    }

    /// <summary>
    /// NB Guide Mode
    /// </summary>
    public void NBGuideInit()
    {

    }
    public void NBGuideSelect(int TypeID)
    {
        if(TypeID==0)
        {
            /*
             * NB 闪烁寻路自动部分 IE
             * NB 闪烁寻路互动部分 TimeLine 等方法
             */
        }
        else if (TypeID == 1)
        {
              /*
             * NB 闪烁探索自动部分 IE
             * NB 闪烁探索互动部分 TimeLine 等方法
             */
        }
        else if (TypeID == 2)
        {
            /*
           * NB 语音探索自动部分 IE
           * NB 语音探索互动部分 TimeLine 等方法
           */
        }
        else if (TypeID == 3)
        {
            /*
           * NB 语音探索自动部分 IE
           * NB 语音探索互动部分 TimeLine 等方法
           */
        }
        else if (TypeID == 4)
        {
            /*
           * NB 拟人探索自动部分 IE
           * NB 拟人探索互动部分 TimeLine 等方法
           */
        }
        else if (TypeID == 5)
        {
            /*
           * NB 拟人探索自动部分 IE
           * NB 拟人探索互动部分 TimeLine 等方法
           */
        }
    }
}
