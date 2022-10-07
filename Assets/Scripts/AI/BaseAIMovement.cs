using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAIMovement : BaseAI
{
    private Vector3 direction;
    private float distance;
    private float angle;
    private bool move;

    private float moveThreshold = 5f;

    void FixedUpdate()
    {
        CalculateAngle();
    }

    private void CalculateAngle()
    {
        direction = target.position - transform.position;

        angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        transform.localEulerAngles = angle * Vector3.up;

        distance = Vector3.Distance(transform.position, target.position);
        move = distance > moveThreshold;

        if (move)
        {
            transform.Translate(Vector3.forward * 0.8f * Time.fixedDeltaTime);
            animator.SetBool("move", move);
        }
        else
        {
            animator.SetBool("move", move);
        }
    }
}
