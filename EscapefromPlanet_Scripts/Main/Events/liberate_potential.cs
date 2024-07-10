using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine.Assertions.Must;

//�R���C�_�[�ɐڐG���Ă����Ԃœ���̃{�^�����͂��������ۂ�
//�C�x���g�𔭐������A�v���C���[�֔\�͕t�^�̃t���O��Ԃ�
public class liberate_potential: MonoBehaviour
{
    [SerializeField] TextMeshProUGUI actionPop;
    [SerializeField] TextMeshProUGUI actiontmessage;
    [SerializeField] TextMeshProUGUI skipText;
    [SerializeField] SpawnEffect spawneffect;
    [SerializeField] GameObject actionimage;
    [SerializeField] List<BoxCollider> boxColList;
    [SerializeField] List<MeshRenderer>meshRenList;
    public bool actionFlag;

    private void Update()
    {
        OnClose();
    }
    private void Awake()
    {
        not_applicable();
    }
    private void OnTriggerStay(Collider collision)
    {
        var current_GP = Gamepad.current;
        var Check = current_GP.leftShoulder;
        if (collision.CompareTag("Player") && Check.wasPressedThisFrame && !GameManager2.additionPlayerActionGetFlag)
        {
            if (!actionFlag)
            {
                OnCheck();
                Invoke("GiveOverJump",Const.CO.const_Float_List[1]);
            }
        }
        if(collision.CompareTag("Player") && Check.wasPressedThisFrame && GameManager2.additionPlayerActionGetFlag && !GameManager2.floatPowerGetFlag)
        {
            if (!actionFlag)
            {
                OnCheck();
                Invoke("GiveFloat", Const.CO.const_Float_List[1]);
            }
        }
        if(collision.CompareTag("Player"))
        {
            actionPop.text = "LB�{�^�����͂ŃA�N�V�����s��";
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            actionPop.text = "LB�{�^�����͂ŃA�N�V�����s��";
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            actionPop.text = "";
        }
    }
    private void OnCheck()
    {
        GameManager.pauseflag = true;
        SoundManager.Instance.SettingPlaySE12();
        spawneffect.enabled = true;
        actionFlag = true;
        actionPop.text = "";
        skipText.text = "B�{�^���ŃX�L�b�v";
    }
    //�t���O��Ԃ��AUI�̔�\��
    private void OnClose()
    {
        var current_GP = Gamepad.current;
        var close = current_GP.buttonEast;
        if(actionFlag && close.wasPressedThisFrame && !GameManager2.additionPlayerActionGetFlag)
        {
            GameManager2.additionPlayerActionGetFlag = true;
            actionimage.SetActive(false);
            StartCoroutine(GameManager.Standbytime());
            not_applicable();
            actionFlag = false;
            skipText.text = "";
            actionPop.text = "";
        }
        else if(actionFlag && close.wasPressedThisFrame && GameManager2.additionPlayerActionGetFlag && !GameManager2.floatPowerGetFlag)
        {
            GameManager2.floatPowerGetFlag = true;
            actionimage.SetActive(false);
            StartCoroutine(GameManager.Standbytime());
            not_applicable();
            actionFlag = false;
            skipText.text = "";
            actionPop.text = "";
        }
    }
    private void GiveOverJump()
    {
        if(!GameManager2.additionPlayerActionGetFlag)
        {
            skipText.text = "";
            actionimage.SetActive(true);
        }
        SoundManager SM = SoundManager.Instance;
        SM.SettingPlaySE11();
    }
    private void GiveFloat()
    {
        if(!GameManager2.floatPowerGetFlag)
        {
            skipText.text = "";
            actionimage.SetActive(true);
        }
        SoundManager SM = SoundManager.Instance;
        SM.SettingPlaySE11();
    }
    //����̃t���O���Ԃ��Ă��鎞�A���X�g���̃R���C�_�[�A���b�V�����\���ɂ���
    private void not_applicable()
    {
        if(GameManager2.additionPlayerActionGetFlag)
        {
            boxColList[0].enabled = false;
            meshRenList[0].enabled = false;
        }

        if(GameManager2.floatPowerGetFlag)
        {
            boxColList[Const.CO.const_Int_List[0]].enabled = false;
            meshRenList[Const.CO.const_Int_List[0]].enabled = false;
        }
    }
}

