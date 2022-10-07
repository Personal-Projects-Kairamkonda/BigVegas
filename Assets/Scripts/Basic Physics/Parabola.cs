using UnityEngine;

public class Parabola : MonoBehaviour
{
    [SerializeField] private float axisLength;
    [SerializeField] private float length;
    [SerializeField] private Vector3 originPos;
    [SerializeField] private Vector3 startPos;
    [SerializeField] private Vector3 finalPos;

    void OnDrawGizmos()
    {
        originPos = Vector3.zero;
        startPos = new Vector3(-length, -length, 0);
        finalPos = new Vector3(length, -length, 0);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(startPos, originPos);
        Gizmos.DrawLine(originPos, finalPos);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(originPos, Vector3.right*axisLength);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(originPos, Vector3.up*axisLength);
    }
}

/*
 * Parabola Formula y= ax2+bx+c
 * For jump use negative parabola y=-x2
 * 
 */