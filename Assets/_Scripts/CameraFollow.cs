using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 0.2f;
    public bool isBound = false;
    public Vector2 maxPosition = new Vector2(0, 0);
    public Vector2 minPosition = new Vector2(0, 0);

    private void FixedUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            if (isBound)
            {
                targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
                targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            }

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}