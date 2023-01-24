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
        BtnS1.onClick.AddListener(UIS1);
        BtnS2.onClick.AddListener(UIS2);
        BtnS3.onClick.AddListener(UIS3);
    }

    // 直接调用这几个公共接口
    public void UIReset()
    {
        GameObject.Find("Manager").GetComponent<Manager>().TestReset();
    }
    public void UIS1()
    {
        Debug.Log("Click S1");
        GameObject.Find("Manager").GetComponent<Manager>().TestFlash();
        BtnS1.interactable = false;
        BtnS2.interactable = false;
        BtnS3.interactable = false;
    }
    public void UIS2()
    {
        GameObject.Find("Manager").GetComponent<Manager>().TestTTS();
        BtnS1.interactable = false;
        BtnS2.interactable = false;
        BtnS3.interactable = false;
    }
    public void UIS3()
    {
        GameObject.Find("Manager").GetComponent<Manager>().TestAvatar();
        BtnS1.interactable = false;
        BtnS2.interactable = false;
        BtnS3.interactable = false;
    }
}
