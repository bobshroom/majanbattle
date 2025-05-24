using System.Collections.Generic;
using UnityEngine;

public class confusedStar : MonoBehaviour
{
    private List<Transform> children = new List<Transform>();
    private List<float> multiplate = new List<float>();
    public float min;
    public float max;
    private float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Transform child in transform)
        {
            children.Add(child);
            multiplate.Add(UnityEngine.Random.Range(min, max));
        }
        Debug.Log(children);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += Time.deltaTime;
        for (int i = 0; i < children.Count; i++)
        {
            Debug.Log("子の座標を更新");
            children[i].transform.position = new Vector2(transform.position.x + Mathf.Sin(time * multiplate[i]) * 0.2f, transform.position.y + Mathf.Cos(time * multiplate[i]) * 0.1f);
        }
    }
}
