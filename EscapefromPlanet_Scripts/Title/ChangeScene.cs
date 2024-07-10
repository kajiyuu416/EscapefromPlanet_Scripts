using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.Video;

//OPScene,DemoScene�i�f���V�[���j�ɂĎg�p
//�f����C�ӂŃX�L�b�v���鏈���A�f���I����MainScene�Ɉڍs���鏈��
//Scene�����O�ɓǂݍ��݁A�؂�ւ������^�C�~���O�Ńt���O��Ԃ����ƂŃX���[�Y�ɃV�[����؂�ւ�����悤�Ɏ���
public class ChangeScene : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] FadeInOut fadeinout;
    [SerializeField] string sceneName;
    private GameManager2 gamemanager2;
    private AsyncOperation asyncLoad;
    private void Start()
    {
        gamemanager2 = FindObjectOfType<GameManager2>();
        videoPlayer.loopPointReached += LoopPointReached;
        StartCoroutine("Skip");
    }
    IEnumerator Skip()
    {
        var current_GP = Gamepad.current;
        var SkipButton = current_GP.buttonEast;
        asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;
        bool waitFlag = true;
        while(waitFlag)
        {
            yield return null;
            waitFlag = !SkipButton.wasPressedThisFrame;
        }
        yield return fadeinout.FadeOut();
        asyncLoad.allowSceneActivation = true;
        if(SceneManager.GetActiveScene().name == "OPScene")
        {
            gamemanager2.Duplicate_firstLoadFlag = true;
        }
        yield return asyncLoad;
    }
    public void LoopPointReached(VideoPlayer vp)
    {
        // ����Đ��������̏���
        if(SceneManager.GetActiveScene().name == "OPScene")
        {
            gamemanager2.Duplicate_firstLoadFlag = true;
        }
        asyncLoad.allowSceneActivation = true;
    }
}
