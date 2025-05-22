using System.Collections.Generic;
using UnityEngine;

public class enemySummonerManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> doors;
    [SerializeField] private List<enemyCreater> enemyCreaters;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject door in doors)
        {
            enemyCreaters.Add(door.GetComponent<enemyCreater>());
        }
        Debug.Log(enemyCreaters.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            enemyCreaters[0].create();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            enemyCreaters[1].create();
        }
    }
    public void create(int i)
    {
        enemyCreaters[i].create();
    }
}
