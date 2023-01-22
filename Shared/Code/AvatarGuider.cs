using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarGuider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AvatarInit();
        //AvatarTTS();
    }

    // Update is called once per frame
    void Update()
    {
        AvatarUpdate();
        AvatarObjUpdate();
    }

    public GameObject ObjAvatar;
    public bool IsStartGuide;
    public bool IsMove;
    public bool IsMovePart = false;
    public float AvatarSpeed;
    public int PillarID;
    public int ExiObjID;
    public int TTSID;
    public AudioClip[] TTSClips;
    private AudioSource avatar_audioSource;

    public void AvatarInit()
    {
        avatar_audioSource = this.GetComponent<AudioSource>();
        avatar_audioSource.playOnAwake = false;
    }
    public void AvatarUpdate()
    {
        if(IsStartGuide)
        {
            if(IsMove)
            {
                Vector3 tempv3 = GameObject.Find("Manager").GetComponent<Manager>().Pillars[PillarID].transform.position;
                ObjAvatar.transform.position = Vector3.Lerp(ObjAvatar.transform.position, new Vector3(tempv3.x, ObjAvatar.transform.position.y, tempv3.z), AvatarSpeed);
                ObjAvatar.transform.LookAt(new Vector3(tempv3.x, ObjAvatar.transform.position.y, tempv3.z));
            }
        }
    }
    public void AvatarObjUpdate()
    {
        if (IsStartGuide)
        {
            if (IsMovePart)
            {
                //Debug.Log(IsMovePart);
                Vector3 tempv3 = GameObject.Find("Manager").GetComponent<Manager>().ExiObjs[ExiObjID].transform.position;
                ObjAvatar.transform.position = Vector3.Lerp(ObjAvatar.transform.position, new Vector3(tempv3.x, ObjAvatar.transform.position.y, tempv3.z), AvatarSpeed);
                ObjAvatar.transform.LookAt(new Vector3(tempv3.x, ObjAvatar.transform.position.y, tempv3.z));
            }
        }
    }
    public void AvatarTTS()
    {
        //Debug.Log("Play TTS ::" + TTSID);
        if(avatar_audioSource.isPlaying)
        {
            avatar_audioSource.Stop();
        }

        avatar_audioSource.PlayOneShot(TTSClips[TTSID]);
    }
}
