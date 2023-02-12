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

    public void AllReseting()
    {
        f_FlashTesting.AllTestingReset();
        f_TTSTesting.AllTestingReset();
        f_AvatarTesting.AllTestingReset();
    }
}
