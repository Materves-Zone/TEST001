using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_BasicSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursorlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsLock = false;
    private void Cursorlock()
    {
        if(IsLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
