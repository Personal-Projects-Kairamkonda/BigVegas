using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOneDoozy : MonoBehaviour
{
    private Animator animator;

    private string[] animationStrings= new string[5];

    private string style1 = "Chicken Dance";
    private string style2 = "Gangnam Style";
    private string style3 = "Hip Hop Dancing";
    private string style4 = "Robot Hip Hop Dance";

    void Awake()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();

        animationStrings[0] = style1;
        animationStrings[1] = style2;
        animationStrings[2] = style3;
        animationStrings[3] = style4;
        animationStrings[4] = style1;
    }

    public void RandomAnimation()
    {
        animator.Play(animationStrings[Random.Range(0,5)]);

        /*
        for (int i = 0; i < animationStrings.Length; i++)
        {
            string currentAnim = AnimatorInfo();
            if (currentAnim == animationStrings[i])
            {
            }
        }
        */
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
