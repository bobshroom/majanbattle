using System;
using TMPro;
using UnityEngine;

public class showClearTime : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "クリアタイム：" + MathF.Round(gameManager.clearTime, 2).ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
