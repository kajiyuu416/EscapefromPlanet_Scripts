using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool opendoorFlag = false;
    public Animator animator;

    //�v���C���[���R���C�_�[�͈͓̔��ɔ����J���A�͈͊O�ɏo��Ɣ����܂�
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            opendoorFlag = true;
        }
        animator.SetBool("character_nearby", opendoorFlag);
    }

    private void OnTriggerExit(Collider collision)
    {

        if (collision.CompareTag("Player"))
        {
            opendoorFlag = false;

        }
        animator.SetBool("character_nearby", opendoorFlag);
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            opendoorFlag = true;
        }
        animator.SetBool("character_nearby", opendoorFlag);

    }
}
