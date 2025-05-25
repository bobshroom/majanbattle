using System.Collections;
using UnityEngine;

public class ShockWave : MonoBehaviour
{
    [SerializeField] private float force = 500f;
    public float radius = 5f;
    [SerializeField] private float confusedTime;
    public int futtobasucount = 0;
    [SerializeField] private GameObject futtobasuMark;
    [SerializeField] private Transform futtobasuParent;
    [SerializeField] private GameObject shockEffect;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) & futtobasucount > 0)
        {
            futtobasucount--;
            StartCoroutine(waveEffect());
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
            if (futtobasuParent.childCount > 0)
            {
                Transform lastChild = futtobasuParent.GetChild(futtobasuParent.childCount - 1);
                Destroy(lastChild.gameObject);
            }
        }
    }

    public void GetHatu()
    {
        GameObject instant = Instantiate(futtobasuMark);
        instant.transform.SetParent(futtobasuParent);
        instant.GetComponent<hpMarkManager>().futtobasi = true;
        instant.transform.position = new Vector2(5.17f, -4.7f);
        instant.transform.Translate(-0.6f * futtobasucount, 0, 0);
        futtobasucount++;
    }

    IEnumerator waveEffect()
    {
        float i = 0.0f;
        SpriteRenderer sr = shockEffect.GetComponent<SpriteRenderer>();
        shockEffect.SetActive(true);
        changeToumeido(1.0f, sr);
        shockEffect.transform.localScale = new Vector2(0, 0);
        while (i <= 50)
        {
            shockEffect.transform.localScale = new Vector2(i, i);
            i += Time.deltaTime * 300.0f;
            yield return null;
        }
        i = 0.0f;
        while (i <= 50.0f)
        {
            shockEffect.transform.localScale = new Vector2(i + 50, i + 50);
            changeToumeido((50 - i) * 0.02f, sr);
            i += Time.deltaTime * 300.0f;
            yield return null;
        }
    }

    void changeToumeido(float n, SpriteRenderer sr) {
        Color color = sr.color;
        color.a = n;
        sr.color = color;
    }
}