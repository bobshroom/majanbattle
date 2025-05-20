using UnityEngine;

public class ShockWave : MonoBehaviour
{
    [SerializeField] private float force = 500f;
    public float radius = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int k = 0;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
            Debug.Log(colliders.Length + "個の物体を検知");
            foreach (Collider2D hit in colliders)
            {
                Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    k += 1;
                    Vector3 direction = hit.transform.position - transform.position;
                    rb.AddForce(direction.normalized * force * rb.mass / 2, ForceMode2D.Impulse);
                }
            }
            Debug.Log(k + "個のオブジェクトを吹き飛ばしました");
        }
    }
}