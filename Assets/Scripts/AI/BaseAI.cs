using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseAI : MonoBehaviour
{
    [SerializeField]protected Transform target;
    protected Animator animator;
    protected TextMeshPro dialougeText;

    void Awake()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        dialougeText = transform.GetChild(1).GetComponent<TextMeshPro>();
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
