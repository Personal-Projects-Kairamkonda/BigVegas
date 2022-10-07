using UnityEngine;

public class RadialTrigger : MonoBehaviour
{   
    [HideInInspector]
    public Transform obj;
    [Range(0, 5)]
    public float radius = 1;
    public double distance;
    public float totalRadius;

    private void OnDrawGizmos()
    {
        Vector3 origin = transform.position;
        Vector3 enemy = obj.position;

        double length = MyDistance(origin, enemy);
        distance = length;

        //Instead of square root of length, it is better to multiply the radius twice
        //This is similar to squaring on both sides
        totalRadius = radius *radius ;
        bool inInside = length < totalRadius;

        Gizmos.color = inInside ? Color.green : Color.red;
        Gizmos.DrawWireSphere(origin, radius);
    }

    /// <summary>
    /// Using Distance formula
    /// (a,b)= Square root of a*a+b*b
    /// </summary>
    /// <param name="a"> from </param>
    /// <param name="b"> to </param>
    /// <returns> float value </returns>
    double MyDistance(Vector2 a, Vector2 b)
    {
        Vector3 distance = a - b;
        double length = distance.x * distance.x + distance.y * distance.y;
        return length;
    }
}
