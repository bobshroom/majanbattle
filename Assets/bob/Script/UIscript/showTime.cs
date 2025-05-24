using System;
using TMPro;
using Unity.Mathematics;
using Unity.Mathematics.Geometry;
using UnityEngine;

public class showTime : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("UpdateTime", 0, 0.124104782917f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateTime()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "経過時間：" + MathF.Round(gameManager.clearTime, 2).ToString();
    }
}
