using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;

public class haiManager : MonoBehaviour
{
    [SerializeField] public int point;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    void OnDestroy()
    {
        GameObject.Find("GameManager").GetComponent<gameManager>().getPoint(point);
    }
}
