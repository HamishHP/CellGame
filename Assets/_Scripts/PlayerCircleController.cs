using UnityEngine;

public class PlayerCircleController : MonoBehaviour
{
    public Camera cam;

    private bool isShooting = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        FaceCursor();
    }

    private Vector3 GetMousePos()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        return mousePos;
    }

    private void OnMouseDown()
    {
        isShooting = true;
    }

    private void OnMouseUp()
    {
        isShooting = false;
    }

    private Vector3 GetMouseDirection()
    {
        // Calculate the direction vector from the character to the mouse pointer
        Vector3 direction = GetMousePos() - transform.position;
        return direction.normalized;
    }

    private void FaceCursor()
    {
        Vector3 direction = GetMouseDirection();

        // Calculate the angle in degrees between the direction vector and the up vector (top of the character)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the character to face the mouse pointer
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}