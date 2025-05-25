using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    private int point = 0;
    private point pointsc;
    public static float clearTime;
    public bool isTimerStart;
    [SerializeField] List<int> waves = new List<int>();
    private int index;
    public bool endlessmode = false;
    [SerializeField] private GameObject enemySummonerManager;
    private enemySummonerManager esm;
    private bool gameOver = false;
    [SerializeField] private GameObject gameOverWin;
    [SerializeField] private GameObject enemyList;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointsc = GameObject.Find("point").GetComponent<point>();
        isTimerStart = true;
        esm = enemySummonerManager.GetComponent<enemySummonerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerStart & !gameOver)
        {
            clearTime += Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        if (index == -1)
        {
            if (endlessmode)
            {

            }
        }
        else if (waves[index] <= point)
        {
            switch (index)
            {
                case 0:
                    esm.create(0, 0);
                    break;
                case 1:
                    esm.create(2, 0);
                    break;
                case 2:
                    esm.create(0, 1);
                    break;
                case 3:
                    esm.create(1, 1);
                    break;
                case 4:
                    esm.create(3, 2);
                    break;
                case 5:
                    esm.create(2, 1);
                    break;
                case 6:
                    esm.create(3, 1);
                    break;
                case 7:
                    esm.create(2, 2);
                    break;
                case 8:
                    esm.create(4, 3);
                    index = -2;
                    break;

            }
            index++;
        }
    }
    public void getPoint(int n)
    {
        point += n;
        pointsc.changeText(":" + point.ToString());
        if (point >= 136 & !gameOver)
        {
            GameOver(true);
            gameOver = true;
        }
    }
    void GameOver(bool isclear)
    {
        enemyList.SetActive(false);
        gameOverWin.SetActive(true);
    }
}
