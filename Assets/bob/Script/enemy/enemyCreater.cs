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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parent = GameObject.Find("enemy").transform;
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
        for (int i = 0; i < 500; i++)
        {
            instant.transform.position = transform.position + -transform.up * (i - 250) * 0.004f;
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        instant.GetComponent<enemyController>().isSummoning = false;
        //instant.GetComponent<PolygonCollider2D>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        instant.transform.parent = parent;
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
