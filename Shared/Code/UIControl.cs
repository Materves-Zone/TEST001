using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Button BtnReset;
    private Button BtnS1;
    private Button BtnS2;
    private Button BtnS3;

    private void UIInit()
    {
        BtnReset = GameObject.Find("Btn_Reset").GetComponent<Button>();
        BtnS1 = GameObject.Find("Btn_1").GetComponent<Button>();
        BtnS2 = GameObject.Find("Btn_2").GetComponent<Button>();
        BtnS3 = GameObject.Find("Btn_3").GetComponent<Button>();

        BtnReset.onClick.AddListener(UIReset);
    }

    private void UIReset()
    {
        GameObject.Find("Manager").GetComponent<Manager>().TestReset();
    }
    private void UIS1()
    {
        GameObject.Find("Manager").GetComponent<Manager>().TestFlash();
    }
    private void UIS2()
    {
        GameObject.Find("Manager").GetComponent<Manager>().TestTTS();
    }
    private void UIS3()
    {
        GameObject.Find("Manager").GetComponent<Manager>().TestAvatar();
    }
}
