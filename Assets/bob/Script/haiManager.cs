using System.Collections;
using Cysharp.Threading.Tasks.Triggers;
using Unity.VisualScripting;
using UnityEngine;

public class haiManager : MonoBehaviour
{
    [SerializeField] private int point;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
