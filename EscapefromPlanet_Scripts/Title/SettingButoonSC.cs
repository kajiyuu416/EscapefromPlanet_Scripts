using UnityEngine;
using UnityEngine.UI;

public class SettingButoonSC : MonoBehaviour
{
    //SettingButoon�������ꂽ�Ƃ��ݒ���J������
    public Button settingButton;
    private void Start()
    {
        settingButton = GetComponent<Button>();
        settingButton.onClick.AddListener(() => {
            GameManager2.Setting();
        });
    }
}
