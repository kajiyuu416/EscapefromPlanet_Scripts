using UnityEngine;
using UnityEngine.UI;
//Player�ƃ��[�U�[�̋����ɉ����Ċ댯��m�点��}�[�N�̕\���y�у��[�U�[�Ƃ̋����ɉ����ă}�[�N�̐F��ύX���鏈���B
public class ChangeColorScript : MonoBehaviour
{
    [SerializeField] Image WI;
    private float changeColorThreshold = 10.0f;
    private Color startColor = Color.white;
    private Color endColor = Color.red;
    private Transform target;
    private string tagname;
    private bool restriction;

    private void Start()
    {
        var go = GameObject.FindGameObjectWithTag("Player");

        if (go)
            target = go.transform;
        else
            Debug.LogWarning("�^�[�Q�b�g�ƂȂ� Player �^�O�̂����I�u�W�F�N�g���V�[����ɑ��݂��܂���");
        WI.enabled = false;
        tagname = "warningarea";
    }
    private  void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.tag == tagname)
        {
            restriction = true;
            WI.enabled = true;
            if (!target) return;
            float distance = Vector3.Distance(transform.position, target.position);

            if (distance < changeColorThreshold)
            {
                Color c = (endColor * (changeColorThreshold - distance) + startColor * distance) / changeColorThreshold;
                WI.color = c;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(restriction)
        {
            WI.enabled = false;
            restriction = false;
        }
    
    }
}