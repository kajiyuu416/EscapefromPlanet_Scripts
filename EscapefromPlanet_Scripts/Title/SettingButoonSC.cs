using UnityEngine;
using UnityEngine.UI;

public class SettingButoonSC : MonoBehaviour
{
    //SettingButoonが押されたとき設定を開く処理
    public Button settingButton;
    private void Start()
    {
        settingButton = GetComponent<Button>();
        settingButton.onClick.AddListener(() => {
            GameManager2.Setting();
        });
    }
}
