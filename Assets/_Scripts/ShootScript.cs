using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody2D))]
public class ShootScript : MonoBehaviour
{
    public float fireRate = 0.3f;

    public float moveForce = 1f;

    private bool isShooting = false;

    private Rigidbody2D rb;

    public Transform spawner;
    public GameObject bulletObject;

    public float bulletSpeed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void StartShooting()
    {
        isShooting = true;
        StartCoroutine(ShootAndMove());
    }

    public void StopShooting()
    {
        isShooting = false;
        StopCoroutine(ShootAndMove());
    }

    private IEnumerator ShootAndMove()
    {
        while (isShooting)
        {
            GameObject newBullet = Instantiate(bulletObject, spawner);
            newBullet.transform.SetParent(null);
            BulletScript bulletScript = newBullet.GetComponent<BulletScript>();
            bulletScript.SetBulletSpeed(bulletSpeed);
            rb.AddForce(-transform.right * moveForce, ForceMode2D.Impulse);
            yield return new WaitForSeconds(fireRate);
        }
    }
}