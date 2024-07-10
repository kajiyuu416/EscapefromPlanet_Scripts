using System.Collections;
using UnityEngine;
using Cinemachine;
using TMPro;
using UnityEngine.InputSystem;

//�����𖞂����A�R���C�_�[�ɐڐG�����ꍇ�A�J�����̈ʒu�؂�ւ��ƃe�L�X�g�\���ABGM�ύX�A�^�C�}�[�\�����s��
//�C�x���g�V�[���̃X�L�b�v����
public class EscapeEventSC : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera subcamera3;
    [SerializeField] SunMove sunmove;
    [SerializeField] TextMeshProUGUI skipText;
    [SerializeField] TextMeshProUGUI actiontmessage;
    [SerializeField] GameObject timer;
    private bool escapeEvent;
    private bool eventskip;
    private void Update()
    {
        EventSkip();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player") && GameManager2.ALF && GameManager2.additionPlayerActionGetFlag && GameManager2.floatPowerGetFlag)
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            subcamera3.Priority = Const.CO.const_Int_List[0];
            GameManager.instance.playerui.SetActive(false);
            GameManager.pauseflag = true;
            SoundManager.Instance.StopAudio();
            SoundManager.Instance.SettingPlaySE14();
            MessageIndication();
        }
    }
    private void MessageIndication()
    {
        escapeEvent = true;
        actiontmessage.text = "";
        if(!eventskip)
        {
            StartCoroutine("SetText1");
        }
    }
    private IEnumerator SetText1()
    {
        yield return new WaitForSeconds(Const.CO.const_Float_List[2]);
        if(!eventskip)
        {
            actiontmessage.text = "�����z���F���D�ɐڋߒ���";
            StartCoroutine("SetText2");
        }
    }
    private IEnumerator SetText2()
    {
        yield return new WaitForSeconds(Const.CO.const_Float_List[3]);
        if(!eventskip)
        {
            actiontmessage.text = "�ً}�E�o���u��ڎw���Ă�������";
            StartCoroutine("SetAction");
        }
    }
    private IEnumerator SetAction()
    {
        yield return new WaitForSeconds(Const.CO.const_Float_List[3]);
        if(!eventskip)
        {
            EventEnd();
        }
    }
    private void EventEnd()
    {
        actiontmessage.text = "";
        skipText.text = "";
        subcamera3.Priority = 0;
        SoundManager.Instance.StopAudio();
        SoundManager.Instance.Startbgm3();
        GameManager.pauseflag = false;
        GameManager.instance.playerui.SetActive(true);
        escapeEvent = false;
        sunmove.MPF = true;
        timer.SetActive(true);
    }
    private void EventSkip()
    {
        var current_GP = Gamepad.current;
        var Skip = current_GP.buttonEast;

        if(escapeEvent && !eventskip)
        {
            skipText.text = "B�{�^���ŃX�L�b�v";
            if(Skip.wasPressedThisFrame)
            {
                eventskip = true;
                EventEnd();
            }
        }
    }
}
