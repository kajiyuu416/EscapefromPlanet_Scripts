using UnityEngine;

//�v���C���[�̎q�I�u�W�F�N�g�i�e�p�[�c�j�Ɏg�p
//�Q�[���I�[�o�[���Ƀv���C���[�{�͔̂�\���ɂ�
//�q�I�u�W�F�N�g�i�e�p�[�c�j��\���A���[�U�[�ɍ~��Ε����̓����_���ȕ����ɗ͂�������΂����悤�ȕ\��������
public class Child : MonoBehaviour
{
    private const float speed = 20.0f;
    private float time;
    private float vecX;
    private float vecY;
    private float vecZ;
    private Vector3 initialPosition;
    public GameObject particleObject;
    public PlayerController playerController;
    private MeshRenderer meshRenderer;
    private new Rigidbody rigidbody;
    private BoxCollider boxCollider;

    private void Start()
    {
        time = 1.0f;
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.isTrigger = true;
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void Update()
    {
        time -= Time.deltaTime;
        initialPosition = gameObject.transform.position;
    }
    public void On()
    {
        meshRenderer.enabled = true;
    }
    private void OnTriggerEnter(Collider triger)
    {
        if(triger.CompareTag("laser"))
        {
            boxCollider.isTrigger = false;
            Instantiate(particleObject,this.transform.position,Quaternion.identity);
            rigidbody.constraints = RigidbodyConstraints.None;
            this.gameObject.transform.parent = null;
            playerController.PlayerDeath();
            if (time <= 0.0f)
            {
                vecX = Random.Range(-5, 5);
                vecY = Random.Range(2, 5);
                vecZ = Random.Range(-5, 5);
                transform.position = new Vector3(vecX, vecY, vecZ);
                transform.position = initialPosition;
                rigidbody.velocity = transform.forward.normalized * speed;
                time = Const.CO.const_Float_List[3];
            }
        }
     
    }

}

