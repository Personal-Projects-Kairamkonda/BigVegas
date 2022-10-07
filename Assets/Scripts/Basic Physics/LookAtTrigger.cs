using UnityEngine;

/*
    Threshold from Zero to one
    One = very strict, need to look exactly towards the trigger
    Zero= perpendicular or closer means you are looking at it
*/

public class LookAtTrigger : MonoBehaviour
{
    public Transform player;

    [Range(0, 1)]
    public float threshold;

    private void OnDrawGizmos()
    {
        Vector2 center = transform.position;
        Vector2 playerPOs = player.position;

        Vector2 playerDirection = player.right;
        Vector2 playerLookingTiggerDirection = (center - playerPOs).normalized;

        float lookingdirection = MyDotProduct(playerLookingTiggerDirection, playerDirection);
        bool lookingEachother = lookingdirection >= threshold;

        Gizmos.color = lookingEachother ? Color.green : Color.red;
        Gizmos.DrawLine(center, playerPOs + playerLookingTiggerDirection);
        Gizmos.DrawLine(playerPOs, playerPOs + playerDirection);
    }

    /// <summary>
    /// Using Dot Product formula 
    /// (ax1,by1) (ax2,by2) = ax1*bx1+ay2*by2
    /// </summary>
    /// <param name="lhs"> Current player look direction</param>
    /// <param name="rhs"> Intial player direction</param>
    /// <returns> float value </returns>
    float MyDotProduct(Vector2 lhs, Vector2 rhs)
    {
        float value;
        value = lhs.x * rhs.x + lhs.y * rhs.y;
        return value;
    }

}
