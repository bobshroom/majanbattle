using Unity.VisualScripting;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    private GameObject player;
    private Transform playerTransform;
    public bool isSummoning;
    [SerializeField] private float pushTime;
    [SerializeField] private float pushPower;
    private float time;
    private bool isConfused;
    [SerializeField] private Transform confusedEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("player");
        playerTransform = player.GetComponent<Transform>();
        confusedEffect = transform.GetChild(0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time -= Time.deltaTime;
        Vector2 direction = (playerTransform.position - transform.position).normalized;

        // プレイヤーの方向に力を加える
        //rb.linearVelocity = direction * moveSpeed * Time.deltaTime;
        if (!isSummoning & !isConfused)
        {
            if (rb.linearVelocity.sqrMagnitude < moveSpeed)
            {
                rb.AddForce(direction * moveSpeed * Time.deltaTime * 10.0f);
            }
            if (time <= 0.0f)
            {
                time = pushTime;
                if (rb.linearVelocity.sqrMagnitude < 1.0f)
                {
                    rb.AddForce(direction * moveSpeed * Time.deltaTime * pushPower, ForceMode2D.Impulse);
                }
            }
        }
    }

    public void GetConfused(float time)
    {
        isConfused = true;
        confusedEffect.gameObject.SetActive(true);
        CancelInvoke();
        Invoke("leaveConfused", time);
    }
    private void leaveConfused()
    {
        isConfused = false;
        confusedEffect.gameObject.SetActive(false);
    }
}
