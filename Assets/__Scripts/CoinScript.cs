using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float coinLifetime = 15f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Destroy(gameObject, coinLifetime);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}