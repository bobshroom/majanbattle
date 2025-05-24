using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class haiManager : MonoBehaviour
{
    [SerializeField] private int point;
    public pai_status pai_Status;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = pai_Status.image;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
    void OnDestroy()
    {
        GameObject.Find("GameManager").GetComponent<gameManager>().getPoint(point);
    }
}
