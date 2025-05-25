using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class haiManager : MonoBehaviour
{
    [SerializeField] private int point;
    public pai_status pai_Status;
    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = pai_Status.image;
        player = GameObject.Find("player");
        if ((int)(pai_Status.id / 10) == 5 | pai_Status.id == 46)
        {
            GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
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
        GameObject.Find("getPai").GetComponent<SpriteRenderer>().sprite = pai_Status.image;
        GameObject.Find("GameManager").GetComponent<gameManager>().getPoint(point);
        if ((int)(pai_Status.id / 10) == 5)
        {
            Debug.Log("hapManager" + "体力が回復しました");
            player.GetComponent<playerManager>().GetHp(pai_Status.image);
        }
        else if (pai_Status.id == 46)
        {
            player.GetComponent<ShockWave>().GetHatu();
        }
    }
}
