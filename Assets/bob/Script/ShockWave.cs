using UnityEngine;

public class ShockWave : MonoBehaviour
{
    [SerializeField] private float force = 500f;
    public float radius = 5f;
    [SerializeField] private float confusedTime;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int k = 0;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
            foreach (Collider2D hit in colliders)
            {
                Rigidbody2D rb = hit.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    k += 1;
                    Vector3 direction = hit.transform.position - transform.position;
                    rb.AddForce(direction.normalized * force * rb.mass / 2, ForceMode2D.Impulse);
                }
                enemyController enemyController = hit.GetComponent<enemyController>();
                if (enemyController != null)
                {
                    enemyController.GetConfused(confusedTime);
                }
            }
        }
    }
}