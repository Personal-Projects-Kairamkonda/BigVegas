using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOneBigVegas : MonoBehaviour
{
    private Animator animator;

    public TextMeshProUGUI dialougeText;

    private string style1= "Hip Hop Dancing";
    private string style2= "Gangnam Style";
    private string style3 = "Chicken Dance";
    private string style4 = "Robot Hip Hop Dance";

    void Awake()
    {
        animator = transform.GetChild(0).GetComponent<Animator>(); 
        FlashScreen.instance.UpdateDialougeText( "Hi Doozy");
    }

    public void PlayHipHopDancing()
    {
        animator.Play(style1);
        FlashScreen.instance.UpdateDialougeText("Hip Hop Dancing");
    }

    public void PlayGangnamStyle()
    {
        animator.Play(style2);
        FlashScreen.instance.UpdateDialougeText("Gangnam Style");
    }

    public void PlayChickenDance()
    {
        animator.Play(style3);
        FlashScreen.instance.UpdateDialougeText(style3);
    }

    public void PlayRobotHipHopDance()
    {
        animator.Play(style4);
        FlashScreen.instance.UpdateDialougeText(style4);
    }

    public string AnimatorInfo()
    {
        string state;
        AnimatorClipInfo[] clipInfo;
        clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        state = clipInfo[0].clip.name;
        return state;
    }
}
