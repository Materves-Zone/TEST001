using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarGuider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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

    public void AvatarInit()
    {

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
}
