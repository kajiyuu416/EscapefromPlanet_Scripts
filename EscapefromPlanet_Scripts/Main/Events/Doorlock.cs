using UnityEngine;
using System.Collections;
using TMPro;
using Cinemachine;
public class Doorlock : MonoBehaviour
{
    //コライダーと接触時テキスト表示、カメラワーク変更
    [SerializeField] TextMeshProUGUI doorlockText;
    [SerializeField] CinemachineVirtualCamera subcamera7;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            doorlockText.text = "        〜扉は緊急ロック中〜 \n"+ 
                "コンソールルームにて解除可能";
            subcamera7.Priority = Const.CO.const_Int_List[0];
            GameManager.pauseflag = true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine("SetAction1");
        }
    }
    private IEnumerator SetAction1()
    {
        yield return new WaitForSeconds(Const.CO.const_Float_List[4]);
        subcamera7.Priority = 0;
        GameManager.pauseflag = false;
        doorlockText.text = "";
        StartCoroutine("SetAction2");
    }
    private IEnumerator SetAction2()
    {
        yield return new WaitForSeconds(Const.CO.const_Float_List[4]);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
}
