using UnityEngine;
public class StandUpAnimation : MonoBehaviour
{
    //�v���C���[�̋N���オ�胂�[�V�����Đ�
    public Animator animator;
    private bool isStand;
    private void Start()
    {
        isStand = true;
        animator.SetBool("StandUp", isStand);
        Invoke("endanimation",3f);
    }
    private void endanimation()
    {
        animator.SetBool("StandUp",false);
    }
 
}
