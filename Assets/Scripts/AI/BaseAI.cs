using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAI : MonoBehaviour
{
    [SerializeField]protected Transform target;
    protected Animator animator;

    void Awake()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    
}
