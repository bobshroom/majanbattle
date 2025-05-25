using System.Collections;
using System.Security.Cryptography;
using Unity.Mathematics;
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
    [SerializeField] private bool randomPush;
    [SerializeField, Header("えび先輩関連の設定")] private bool boss;
    [SerializeField] private float shootdelay;
    [SerializeField] private float reloadTime;
    [SerializeField] private GameObject shootsprite;
    private bool isShooting;
    private SpriteRenderer spriteRenderer;
    private SpriteRenderer spriteRenderer2;
    [SerializeField] private GameObject bullet;
    private AudioSource audioSource;
    [SerializeField] private AudioClip gunreload;
    [SerializeField] private AudioClip gunShot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (boss)
        {
            spriteRenderer2 = shootsprite.GetComponent<SpriteRenderer>();
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        time = shootdelay;
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
            if (direction.x <= 0.0f)
            {
                spriteRenderer.flipX = true ^ boss;
            }
            else
            {
                spriteRenderer.flipX = false ^ boss;
            }
            if (rb.linearVelocity.sqrMagnitude < moveSpeed)
            {
                if (!isShooting)
                {
                    rb.AddForce(direction * moveSpeed * Time.deltaTime * 10.0f);
                }
            }
            if (boss)
            {
                if (time <= 0.0f)
                {
                    StartCoroutine(shoot());
                }
            }
            else
            {
                if (time <= 0.0f)
                {

                    if (randomPush)
                    {
                        time = UnityEngine.Random.Range(pushTime * 0.8f, pushPower * 1.2f);
                        rb.AddForce(new Vector2(UnityEngine.Random.Range(0.0f, 1.0f), UnityEngine.Random.Range(0.0f, 1.0f)).normalized * moveSpeed * Time.deltaTime * pushPower, ForceMode2D.Impulse);
                    }
                    else
                    {
                        time = pushTime;
                        if (rb.linearVelocity.sqrMagnitude < 1.0f)
                        {
                            rb.AddForce(direction * moveSpeed * Time.deltaTime * pushPower, ForceMode2D.Impulse);
                        }
                    }
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
    IEnumerator shoot()
    {
        audioSource.PlayOneShot(gunreload);
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        shootsprite.transform.eulerAngles = new Vector3(0, 0, angle);
        if (shootsprite.transform.eulerAngles.z <= 270.0f & shootsprite.transform.eulerAngles.z >= 90.0f)
        {
            spriteRenderer2.flipX = true;
            shootsprite.transform.eulerAngles = new Vector3(0, 0, angle + 180.0f);
        }
        else
        {
            spriteRenderer2.flipX = false;
        }
        GetComponent<SpriteRenderer>().enabled = false;
        shootsprite.GetComponent<SpriteRenderer>().enabled = true;
        time = shootdelay;
        isShooting = true;
        for (int i = 0; i < 100; i++) {
            if (isConfused)
            {
                GetComponent<SpriteRenderer>().enabled = true;
                shootsprite.GetComponent<SpriteRenderer>().enabled = false;
                isShooting = false;
                yield break;
            }
            yield return new WaitForSeconds(reloadTime / 100.0f);
        }
        GameObject instant = Instantiate(bullet, transform.position, quaternion.identity);
        audioSource.PlayOneShot(gunShot);
        instant.transform.eulerAngles = new Vector3(0, 0, angle);
        yield return new WaitForSeconds(reloadTime / 10.0f);
        GetComponent<SpriteRenderer>().enabled = true;
        shootsprite.GetComponent<SpriteRenderer>().enabled = false;
        isShooting = false;
        yield return null;
    }
}
