using TMPro;
using UnityEngine;

public class point : MonoBehaviour
{
    private gameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<gameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
    public void changeText(string text)
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = text;
    }
}
