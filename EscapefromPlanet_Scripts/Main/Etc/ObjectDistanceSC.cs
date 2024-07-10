using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDistanceSC : MonoBehaviour
{
    [SerializeField] List<GameObject> laserobjectList;
    private const float destroyDistance = 100.0f;
    //Razer�I�u�W�F�N�g�����X�g�ɓo�^��
    //�����ɉ����ăI�u�W�F�N�g���\���ɂ���B�������׌y���ׁ̈B
    private void Update()
    {
        Check_Distance();
    }
    private void Check_Distance()
    {
        foreach(var obj in laserobjectList)
        {
            float distance = Vector3.Distance(transform.position, obj.transform.position);

            if(distance > destroyDistance && obj.activeSelf)
            {
                obj.gameObject.SetActive(false);
            }
            else if(distance < destroyDistance && !obj.activeSelf)
            {
                obj.gameObject.SetActive(true);
            }

        }
    }
}