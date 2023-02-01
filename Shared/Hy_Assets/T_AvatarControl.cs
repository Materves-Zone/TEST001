using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_AvatarControl : MonoBehaviour
{
    private void OnEnable()
    {
        AvatarTTSInit();
        AvatarMoveInit();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PillarID);
        AvatarMoveUpdate(PillarID);
        AvatarMoveExiObjUpdate(ExiObjID);
    }

    public GameObject ObjAvatar;
    public float AvatarSpeed;
    public int PillarID;
    public int ExiObjID;
    public int TTSID;
    public bool IsMove = false;
    public bool IsMovePart = false;
    public AudioClip[] TTSClips;
    public AudioSource avatar_audioSource;

    /// <summary>
    /// Sound init
    /// </summary>
    /*
    1. initialize pos and audio
    2. follow pillars' points
    3. follow exihibitor object points
    */
    public void AvatarTTSInit()
    {
        avatar_audioSource.playOnAwake = false;
        avatar_audioSource.PlayOneShot(null);
    }
    public void AvatarTTSStart()
    {
        Debug.Log("1");
        avatar_audioSource.PlayOneShot(TTSClips[0]);
    }
    public void AvatarTTSUpdate(int AvatarTTSID)
    {
        Debug.Log("2");
        if (avatar_audioSource.isPlaying)
        {
            avatar_audioSource.Stop();
        }
        avatar_audioSource.PlayOneShot(TTSClips[AvatarTTSID]);
    }

    public void AvatarMoveInit()
    {       
        IsMove = false;
        IsMovePart = false;

        Vector3 tempv3 = GameObject.Find("Manager").GetComponent<T_Manager>()._startpoint.transform.position;
        ObjAvatar.transform.position = tempv3;
        ObjAvatar.transform.LookAt(new Vector3(tempv3.x, ObjAvatar.transform.position.y, tempv3.z));
    }
    public void AvatarMoveStart()
    {
        IsMove = true;
        IsMovePart = false;
        PillarID = 0;

        Debug.Log(IsMove);
    }
    public void AvatarMoveUpdate(int AvatarPosID)
    {
        if(IsMove)
        {
            Vector3 tempv3 = GameObject.Find("Manager").GetComponent<T_Manager>()._pointsPos[AvatarPosID].transform.position;
            ObjAvatar.transform.position = Vector3.Lerp(ObjAvatar.transform.position, new Vector3(tempv3.x, ObjAvatar.transform.position.y, tempv3.z), AvatarSpeed);
            ObjAvatar.transform.LookAt(new Vector3(tempv3.x, ObjAvatar.transform.position.y, tempv3.z));
        }

    }
    public void AvatarMoveExiObjUpdate(int AvatarExiObjID)
    {
        if(IsMovePart)
        {
            Vector3 tempv3 = GameObject.Find("Manager").GetComponent<T_Manager>()._exiObj[AvatarExiObjID].transform.position;
            ObjAvatar.transform.position = Vector3.Lerp(ObjAvatar.transform.position, new Vector3(tempv3.x, ObjAvatar.transform.position.y, tempv3.z), AvatarSpeed);
            ObjAvatar.transform.LookAt(new Vector3(tempv3.x, ObjAvatar.transform.position.y, tempv3.z));
        }

    }

}
