using System.Collections;
using UnityEngine;

public class playerManager : MonoBehaviour
{
    [SerializeField] private int maxhp;
    private int hp;
    [SerializeField] private float mutekizikan;
    private SpriteRenderer sp;
    private bool mutekika;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hp = maxhp;
        sp = GetComponent<SpriteRenderer>();
        mutekika = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy" & !mutekika)
        {
            hp -= 10;
            if (hp <= 0)
            {
                Destroy(gameObject);
            }
            StartCoroutine(muteki(mutekizikan));
        }
    }
    IEnumerator muteki(float time)
    {
        mutekika = true;
        for (int i = 0; i < 10; i++)
        {
            sp.enabled = false;
            yield return new WaitForSeconds(time / 20);
            sp.enabled = true;
            yield return new WaitForSeconds(time / 20);
        }
        mutekika = false;
    }
}