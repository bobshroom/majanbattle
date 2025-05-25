using UnityEngine;

public class ebibullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rd;
    private float muki;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("ds", 5.0f);
        rd = GetComponent<Rigidbody2D>();
        muki = transform.eulerAngles.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.Translate(transform.right * speed * Time.deltaTime);
        rd.linearVelocity = transform.right * speed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, 0, muki);
    }
    void ds()
    {
        Destroy(gameObject);
    }
}
