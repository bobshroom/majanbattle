using System.Collections.Generic;
using UnityEngine;

public class enemySummonerManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> doors;
    [SerializeField] private List<enemyCreater> enemyCreaters;
    [SerializeField] List<GameObject> enemylist = new List<GameObject>();
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
            enemyCreaters[1].create(enemylist[1]);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            enemyCreaters[0].create(enemylist[0]);
        }
    }
    public void create(int doorid, int enemyid)
    {
        enemyCreaters[doorid].create(enemylist[enemyid]);
    }
}
