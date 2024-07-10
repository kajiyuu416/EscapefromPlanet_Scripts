using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class FadeInOut : MonoBehaviour
{
    public bool fadeInFlag;
    public bool fadeOutFlag;
    private Image blackScreen;
    private bool fadeIn = false;
    private bool fadeOut = false;
    private bool fadeOutEnd;
    //�t���O���Ԃ�ƃt�F�[�h�C���A�t�F�[�h�A�E�g�̏���
    private void Start()
    {
        StartCoroutine(FadeIn());
    }
    private void Update()
    {
        FadeIn_OutFlag();
    }
    public IEnumerator FadeIn()
    {
        blackScreen = GameObject.Find("BlackScreen").GetComponent<Image>();
        var color = blackScreen.color;
        yield return new WaitForSeconds(Const.CO.const_Float_List[0]);

        while (color.a >= 0)
        {
            color.a -= 0.1f;
            blackScreen.color = color;

            yield return null;
        }
        fadeInFlag = false;
        fadeIn = false;
        fadeOutEnd = false;
    }
    public IEnumerator FadeOut()
    {
        blackScreen = GameObject.Find("BlackScreen").GetComponent<Image>();
        blackScreen.gameObject.SetActive(true);
        var color = blackScreen.color;

        while (color.a <= Const.CO.const_Float_List[0])
        {
            color.a += 0.1f;
            blackScreen.color = color;

            yield return null;
        }
        fadeOutFlag = false;
        fadeOut = false;
        fadeOutEnd = true;
    }

    public void FadeIn_OutFlag()
    {
        if(fadeInFlag)
        {
            if(!fadeIn)
            {
                StartCoroutine(FadeIn());
                fadeIn = true;
            }
        }

        if(fadeOutFlag)
        {
            if(!fadeOut)
            {
                StartCoroutine(FadeOut());
                fadeOut = true;
            }
        }
    }

    public bool Duplicate_fadeOutEnd
    {
        get
        {
            return fadeOutEnd;
        }

        set
        {
            fadeOutEnd = value;
        }
    }

}
