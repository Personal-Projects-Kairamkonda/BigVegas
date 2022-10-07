using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMathDistance : MonoBehaviour
{

    public Vector2 currentPosition;
    public float xPos;
    public  float yPos;
    public float total;
    public float distance;
    public float normalizeXPos;
    public float normalizeYPos;
    public Vector2 normalization;

    void LengthOfVector()
    {
        currentPosition = new Vector2(transform.position.x, transform.position.y);

        xPos = (transform.position.x * transform.position.x);
        yPos = (transform.position.y * transform.position.y);

        total = xPos + yPos;

        distance =(float) System.Math.Sqrt(total);

        normalizeXPos = transform.position.x / distance;
        normalizeYPos = transform.position.y / distance;

        normalization = new Vector2(normalizeXPos, normalizeYPos);
        #region Debugs
        /*
        Debug.Log($"Length of a vector is {distance}");

        Debug.Log($"Magnitude of a Vector is {pt.magnitude} ");

        Debug.Log($"Distance of a Vector is {Vector3.Distance(Vector3.zero,pt)} ");
        */
        #endregion

    }

    private void OnDrawGizmos()
    {
        LengthOfVector();

        Gizmos.DrawLine(Vector2.zero, normalization);

    }
}


