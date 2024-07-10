using UnityEngine;
using UnityEngine.InputSystem;
//�A�N�V�����ǉ��@��W�����v�ƃX���C�f�B���O�̒ǉ�
public class AdditionPlayerAction : MonoBehaviour
{
    [SerializeField] GameObject eventObj;
    private PlayerController playerController;
    private FloatPowerSC floatPowerSC;
    private const float jumpOverPower = 200.0f;
    private const float slidingPower = 1000.0f;
    private bool isjumpOver;
    private Animator animator;
    private new Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerController = FindObjectOfType<PlayerController>();
        floatPowerSC = FindObjectOfType<FloatPowerSC>();
    }
    private void Update()
    {
        Additional_Actions();
    }
    private void Additional_Actions()
    {
        //����̃t���O���A���Ă����ꍇ�̂ݏ���
        if(GameManager2.additionPlayerActionGetFlag && !playerController.Duplicate_isDead)
        {
            var current_GP = Gamepad.current;
            var JumpOver = current_GP.buttonNorth;
            var RunningSlide = current_GP.buttonEast;
            bool isrun = playerController.Duplicate_isRun;
            bool isground = playerController.Duplicate_isgroundFlag;
            bool isjump = playerController.Duplicate_isJump;
            bool isfloat = floatPowerSC.Duplicate_isFloatFlag;

            //Player���n�ʂƐڐG���A�����Ă����Ԃœ���̃{�^������������
            if(isrun && isground)
            {
                if(PlayerController.Interval_InputButtondown(JumpOver,1.5f) && !isjump &&!isfloat)
                {
                    isjumpOver = true;
                    floatPowerSC.Duplicate_isFloat = false;
                    rigidbody.AddForce(transform.up * jumpOverPower, ForceMode.Impulse);
                }

                if(PlayerController.Interval_InputButtondown(RunningSlide, Const.CO.const_Float_List[0]))
                {
                    rigidbody.AddForce(transform.forward * slidingPower, ForceMode.Impulse);
                    floatPowerSC.Duplicate_isFloat = false;
                    SoundManager SM = SoundManager.Instance;
                    animator.SetTrigger("RunningSlide");
                    SM.SettingPlaySE8();
                }
              
            }
            if(eventObj.activeSelf)
            {
                eventObj.SetActive(false);
            }

            if(playerController.Duplicate_isDead)
            {
                isjumpOver = false;
            }
        }
        animator.SetBool("Jumpover", isjumpOver);
    }
    public void OverJumpmiss()
    {
        bool isground = playerController.Duplicate_isgroundFlag;
        isjumpOver = false;
        isground = false;
        animator.SetBool("Jumpover",false);
    }
    private void OnTriggerEnter(Collider collision)
    {
        bool isground = playerController.Duplicate_isgroundFlag;

        if(!isground)
        {
            if(collision.CompareTag("ground"))
            {
                isjumpOver = false;
            }
        }
    }
    public bool Duplicate_isjumpOver
    {
        get
        {
            return isjumpOver;
        }
        set
        {
            isjumpOver = value;
        }
    }
}
