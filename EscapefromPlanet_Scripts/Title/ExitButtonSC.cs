using UnityEngine;
using UnityEngine.UI;

public class ExitButtonSC : MonoBehaviour
{
    //ExitButton�������ꂽ�Ƃ��ɃQ�[�����I�����鏈��
    public Button exitButton;
    private void Start()
    {
        exitButton = GetComponent<Button>();
        exitButton.onClick.AddListener(() =>
        {
            GameManager2.EndGame();
        });
    }
}
