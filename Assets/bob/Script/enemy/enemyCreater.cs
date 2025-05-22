using System.Collections;
using UnityEngine;

public class enemyCreater : MonoBehaviour
{
    [SerializeField] private GameObject closedDoor;
    [SerializeField] private GameObject openDoor;
    [SerializeField] private GameObject enemy;
    private Transform parent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parent = GameObject.Find("enemy").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void create()
    {
        StartCoroutine("createEnemy");
    }

    public IEnumerator createEnemy()
    {
        closedDoor.SetActive(false);
        openDoor.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        GameObject instant = Instantiate(enemy, transform.position, Quaternion.identity);
        instant.GetComponent<enemyController>().isSummoning = true;
        for (int i = 0; i < 500; i++)
        {
            instant.transform.position = transform.position + -transform.up * (i - 250) * 0.003f;
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        instant.GetComponent<enemyController>().isSummoning = false;
        yield return new WaitForSeconds(0.5f);
        closedDoor.SetActive(true);
        openDoor.SetActive(false);
        instant.transform.parent = parent;
    }
}
