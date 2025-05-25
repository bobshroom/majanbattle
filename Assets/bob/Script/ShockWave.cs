using UnityEngine;

public class ShockWave : MonoBehaviour
{
    [SerializeField] private float force = 500f;
    public float radius = 5f;
    [SerializeField] private float confusedTime;
    public int futtobasucount = 0;
    [SerializeField] private GameObject futtobasuMark;
    [SerializeField] private Transform futtobasuParent;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) & futtobasucount > 0)
        {
            futtobasucount--;
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
}