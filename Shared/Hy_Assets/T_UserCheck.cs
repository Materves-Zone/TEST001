using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_UserCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UserCheckInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject Manager;
    public T_FlashTesting t_FlashTesting;
    private int CheckID;

    private void UserCheckInit()
    {
        CheckID = 0;
        t_FlashTesting = Manager.GetComponent<T_FlashTesting>();
    }
    private void UserCheckStart()
    {
        CheckID = 0;
    }
    private void UserCheckUpdate()
    {

    }
    private void UserCheckReset()
    {
        UserCheckInit();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "FlashPos" && t_FlashTesting.IsFlashTasting)
        {
            
        }
    }
}
