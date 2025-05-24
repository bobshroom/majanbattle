using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    private int point = 0;
    private point pointsc;
    public static float clearTime;
    public bool isTimerStart;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointsc = GameObject.Find("point").GetComponent<point>();
        isTimerStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerStart)
        {
            clearTime += Time.deltaTime;
        }
    }
    public void getPoint(int n)
    {
        point += n;
        pointsc.changeText("point:" + point.ToString());
        if (point >= 136)
        {
            SceneManager.LoadScene("ending");
        }
    }
}
