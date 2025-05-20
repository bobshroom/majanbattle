using UnityEngine;

public class enemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    private GameObject player;
    private Transform playerTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("player");
        playerTransform = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (playerTransform.position - transform.position).normalized;

            // プレイヤーの方向に力を加える
            rb.linearVelocity = direction * moveSpeed * Time.deltaTime;

    }
}
