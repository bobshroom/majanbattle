using UnityEngine;

public class ebibullet : MonoBehaviour
{
    [SerializeField] private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("ds", 5.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
    }
    void ds()
    {
        Destroy(gameObject);
    }
}
