using UnityEngine;

public class UnlockDoorSC : MonoBehaviour
{
    //�t���O���Ԃ�ƁA�J���ς݂̃h�A�𐶐�
    [SerializeField] GameObject lockDoor;
    [SerializeField] GameObject unlockDoor;
    private bool generateFlag = false;
    private void Update()
    {
        Generate_Door();
    }

    private void Generate_Door()
    {
        if(actionEvent.actionFlag && !generateFlag)
        {
            generateFlag = true;
            Instantiate(unlockDoor, transform.position, Quaternion.identity);
            lockDoor.SetActive(false);
 
        }
    }

}
