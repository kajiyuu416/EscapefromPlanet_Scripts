using UnityEngine;
//�v���C���[�ɒǏ]����e
public class MovetoShadow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] GameObject player;
    private Vector3 _initialPosition;
    private Vector3 nowP = Vector3.zero;
    private void Start()
    {
        _initialPosition = transform.position;
    }
    private void Update()
    {
        nowP.x = target.position.x;
        nowP.y = _initialPosition.y;
        nowP.z = target.position.z;
        transform.position = nowP;
        float dis = Vector3.Distance(transform.position, player.transform.position);
    }
}
