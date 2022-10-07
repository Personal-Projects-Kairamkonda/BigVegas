using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Rat : MonoBehaviour
{
    [SerializeField] private Transform human;

    GameInputs input;
    Animator animator;
    TextMesh dialougeText;

    Vector3 direction;
    bool move;
    float angle;
    float dis;

    void OnEnable() => input.DoozyControls.Enable();
    void OnDisable() => input.DoozyControls.Disable();

    float moveThresshold=5f;

    void Awake()
    {
        input = new GameInputs();
        animator = transform.GetChild(0).GetComponent<Animator>();
        dialougeText = transform.GetChild(1).GetComponent<TextMesh>();
        input.DoozyControls.Movement.performed += ctx => move=ctx.ReadValueAsButton();

        dialougeText.text = " Hi, Big Vegas";
    }

    void FixedUpdate()
    {
        CalculateAngle();
    }

    void CalculateAngle()
    {
        direction = human.position - transform.position;
        Debug.DrawRay(transform.position, direction, Color.white);
        angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        transform.localEulerAngles = angle * Vector3.up;

        float distance = Vector3.Distance(transform.position, human.position);
        move = distance>moveThresshold;

        if (move)
        {
            transform.Translate(Vector3.forward * 0.8f * Time.fixedDeltaTime);
            animator.SetBool("move", move);
        }
        else
        {
            dialougeText.text = "I have got you a puzzle";
            animator.SetBool("move", move);
        }
    }

    void OnDrawGizmos()
    {
        GizmosRay(transform.position, -Vector3.right * 10 + transform.position, Color.red);
        GizmosRay(human.position, human.position + (-Vector3.forward) * 10, Color.blue);
    }

    void GizmosRay(Vector3 start, Vector3 end, Color col)
    {
        Gizmos.color = col;
        Gizmos.DrawLine(start, end);
    }

}
