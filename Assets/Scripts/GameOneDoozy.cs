using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOneDoozy : MonoBehaviour
{
    private Animator animator;

    private string[] animationStrings= new string[4];

    private string style1 = "Hip Hop Dancing";
    private string style2 = "Gangnam Style";
    private string style3 = "Chicken Dance";
    private string style4 = "Robot Hip Hop Dance";

    void Awake()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();

        animationStrings[0] = style1;
        animationStrings[1] = style2;
        animationStrings[2] = style3;
        animationStrings[3] = style4;
    }

    public void RandomAnimation()
    {
        string currentAnim = AnimatorInfo();
        string randAnim = animationStrings[Random.Range(0, 4)];

        if (currentAnim!=randAnim)
        {
            animator.Play(randAnim);
        }
        else
        {
            RandomAnimation();
        }
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
