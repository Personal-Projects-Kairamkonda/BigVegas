using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseAIInstruction : BaseAI
{
    private Vector3 direction;
    private float distance;
    private float angle;

    private string message;

    void FixedUpdate()
    {
        CalculateAngle();
        UpdateTextData();
    }

    private void CalculateAngle()
    {
        direction = target.position - transform.position;
        angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        transform.localEulerAngles = angle * Vector3.up;

        distance = Vector3.Distance(transform.position, target.position);

        if(distance>15)
        {
            message = "Hi Vegas";
            animator.Play("Happy Idle");
        }
        if (distance<13)
        {
            message = "I have got a challange for you";
            animator.Play("Offensive Idle");
        }
        if (distance<5)
        {
            message="Enter into portal to start";
            dialougeText.text = message;
        }
        
    }

    private void UpdateTextData()
    {
        dialougeText.text = message;
    }
}
