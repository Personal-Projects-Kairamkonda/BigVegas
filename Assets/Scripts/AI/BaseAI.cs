using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAI : MonoBehaviour
{
    [SerializeField]protected Transform target;
    protected Animator animator;
    protected TextMesh dialougeText;

    void Awake()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        dialougeText = transform.GetChild(1).GetComponent<TextMesh>();
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
