using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField, Tooltip("上、下、右、左")] private List<UnityEngine.KeyCode> moveKey = new List<UnityEngine.KeyCode>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(moveKey[0]))
        {
            transform.Translate(0, moveSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(moveKey[1]))
        {
            transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(moveKey[2]))
        {
            transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(moveKey[3]))
        {
            transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
        }
        
    }
    
}
