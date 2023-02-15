using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_StaffSettings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public F_FlashTesting f_FlashTesting;
    public F_TTSTesting f_TTSTesting;
    public F_AvatarTesting f_AvatarTesting;
    public GameObject[] ShowHideObjs;
    private int ClickID;

    public void AllReseting()
    {
        f_FlashTesting.AllTestingReset();
        f_TTSTesting.AllTestingReset();
        f_AvatarTesting.AllTestingReset();
    }

    public void ShowHideSettings ()
    {
        switch (ClickID)
        {
            case 0:
                ClickID++;
                // Show
                for (int i = 0; i < ShowHideObjs.Length; i++)
                {
                    ShowHideObjs[i].SetActive(true);
                }
                // Drag enable ...
                break;

            case 1:
                // Hide
                for (int i = 0; i < ShowHideObjs.Length; i++)
                {
                    ShowHideObjs[i].SetActive(false);
                }
                // Drag isable ...
                break;
        }
    }
}
