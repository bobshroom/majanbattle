using UnityEngine;

public class gameManager : MonoBehaviour
{
    private int point = 0;
    private point pointsc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointsc = GameObject.Find("point").GetComponent<point>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void getPoint(int n)
    {
        point += n;
        pointsc.changeText("point:" + point.ToString());
    }
}
