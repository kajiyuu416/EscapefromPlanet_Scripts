using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

//StartButton�������ꂽ��Q�[�����J�n���鏈��
//�I������^�[�Q�b�g���O��Ȃ��悤�Ƀ{�^���̓��́A�}�E�X�̃N���b�N���͂�����ꍇ
//�^�[�Q�b�g��StartButton�ɍ��킹��
public class StartButtonSC : MonoBehaviour
{
    public Button startButton;
    [SerializeField] GameObject StartButton;

    private void Start()
    {
        startButton = GetComponent<Button>();
        startButton.onClick.AddListener(() =>
        {
            GameManager2.GameStart();
            EventSystem.current.SetSelectedGameObject(null);
        });
    }
    private void Update()
    {
        if(GameManager2.connect)
        {
            var current_GP = Gamepad.current;
            var Cansel = current_GP.buttonEast;
            if(Cansel.wasPressedThisFrame)
            {
                EventSystem.current.SetSelectedGameObject(StartButton);
            }
        }
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            EventSystem.current.SetSelectedGameObject(StartButton);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }
}
