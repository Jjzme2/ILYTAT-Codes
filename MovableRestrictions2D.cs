using UnityEngine;

public class MovableRestrictions2D : MonoBehaviour
{
    [SerializeField]
    private float xMin = -8.0f;
    [SerializeField]
    private float xMax = 8.0f;
    [SerializeField]
    private float yMin = -4.0f;
    [SerializeField]
    private float yMax = 4.0f;


    public void MoveWithinConstraints()
    {
        if (transform.position.x < xMin)
        {
            float posY = transform.position.y;
            float posZ = transform.position.z;
            transform.position = new Vector3(xMin, posY, posZ);
        }

        if (transform.position.x > xMax)
        {
            float posY = transform.position.y;
            float posZ = transform.position.z;
            transform.position = new Vector3(xMax, posY, posZ);
        }

        if (transform.position.y < yMin)
        {
            float posX = transform.position.x;
            float posZ = transform.position.z;
            transform.position = new Vector3(posX, yMin, posZ);
        }

        if (transform.position.y > yMax)
        {
            float posX = transform.position.x;
            float posZ = transform.position.z;
            transform.position = new Vector3(posX, yMax, posZ);
        }
    }

}