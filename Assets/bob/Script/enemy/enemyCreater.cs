using System.Collections;
using UnityEngine;

public class enemyCreater : MonoBehaviour
{
    [SerializeField] private GameObject closedDoor;
    [SerializeField] private GameObject openDoor;
    [SerializeField] private GameObject enemy;
    private Transform parent;
    [SerializeField] private bool special;
    private bool DONTDOTHIS = false;
    [SerializeField] private AudioClip dooropen;
    [SerializeField] private AudioClip doorclose;
    private AudioSource audioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parent = GameObject.Find("enemy").transform;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void create(GameObject createnemy)
    {
        StartCoroutine(createEnemy(createnemy));
    }

    public IEnumerator createEnemy(GameObject createEnemy)
    {
        audioSource.PlayOneShot(dooropen);
        if (!special)
        {
            closedDoor.SetActive(false);
            openDoor.SetActive(true);
        }
        else
        {
            if (DONTDOTHIS)
            {
                yield break;
            }
            DONTDOTHIS = true;
            Debug.Log("豪華ドアを開きます");
            GetComponent<Animator>().SetTrigger("open");
            yield return new WaitForSeconds(2.0f);
        }
        yield return new WaitForSeconds(0.5f);
        GameObject instant = Instantiate(createEnemy, transform.position, Quaternion.identity);
        instant.GetComponent<enemyController>().isSummoning = true;
        //instant.GetComponent<PolygonCollider2D>().enabled = false;
        for (float i = 0; i < 500; i++)
        {
            instant.transform.position = transform.position + -transform.up * (i - 250) * 0.004f;
            i += Time.deltaTime * 150.0f;
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        instant.GetComponent<enemyController>().isSummoning = false;
        //instant.GetComponent<PolygonCollider2D>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        instant.transform.parent = parent;
        audioSource.PlayOneShot(doorclose);
        if (!special)
        {
            closedDoor.SetActive(true);
            openDoor.SetActive(false);
        }
        else
        {
            GetComponent<Animator>().SetTrigger("close");
            yield return new WaitForSeconds(2.0f);
            DONTDOTHIS = false;
        }
    }
}
