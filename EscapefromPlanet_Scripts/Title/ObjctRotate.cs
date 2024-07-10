using UnityEngine;
public class ObjctRotate : MonoBehaviour
{
    // ���S�_center�̎�����A��axis�ŁAperiod�����ŉ~�^��
    [SerializeField] Vector3 center = Vector3.zero;
    [SerializeField]Vector3 axis = Vector3.up;
    [SerializeField] float period = 2;
    private void Update()
    {
        transform.RotateAround( center,axis, 360 / period * Time.deltaTime);
    }
}
