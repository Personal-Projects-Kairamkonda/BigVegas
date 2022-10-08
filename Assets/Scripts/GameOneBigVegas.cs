using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOneBigVegas : MonoBehaviour
{
    private Animator animator;

    public Text dialougeText;

    private string style1= "Hip Hop Dancing";
    private string style2= "Gangnam Style";

    void Awake()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    public void PlayHipHopDancing()
    {
        animator.Play(style1);
        UpdateDialougeText("Hip Hop Dancing");
    }

    public void PlayGangnamStyle()
    {
        animator.Play(style2);
        UpdateDialougeText("Gangnam Style");
    }

    public void UpdateDialougeText(string dialouge)
    {
        dialougeText.text = dialouge;
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
