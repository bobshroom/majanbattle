using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerManager : MonoBehaviour
{
    [SerializeField] private int maxhp;
    public int hp;
    [SerializeField] private float mutekizikan;
    private SpriteRenderer sp;
    private bool mutekika;
    [SerializeField] private GameObject hpMarker;
    [SerializeField] private Transform hpmarkerparent;
    [SerializeField] private AudioClip playerHit;
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
            GetComponent<AudioSource>().PlayOneShot(playerHit);
            hp -= 10;
            if (hp <= 0)
            {
                SceneManager.LoadScene("ending");
                Destroy(gameObject);
            }
            StartCoroutine(muteki(mutekizikan));
            if (hpmarkerparent.childCount > 0)
            {
                Transform lastChild = hpmarkerparent.GetChild(hpmarkerparent.childCount - 1);
                Destroy(lastChild.gameObject);
            }
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
    public void GetHp(Sprite sprite)
    {
        hp += 10;
        GameObject instant = Instantiate(hpMarker);
        instant.GetComponent<SpriteRenderer>().sprite = sprite;
        instant.GetComponent<hpMarkManager>().thisHp = hp;
        instant.transform.position = new Vector2(-5.17f, -4.7f);
        instant.transform.Translate(0.06f * (hp-10), 0, 0);
        instant.transform.SetParent(hpmarkerparent);
    }
}