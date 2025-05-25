using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField, Tooltip("上、下、右、左")] private List<UnityEngine.KeyCode> moveKey = new List<UnityEngine.KeyCode>();
    [SerializeField, Tooltip("上、下、右、左")] private List<UnityEngine.KeyCode> moveKeySub = new List<UnityEngine.KeyCode>();
    private Rigidbody2D rd;
    private AudioSource audioSource;
    [SerializeField] private float ashiotoTime;
    private float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 move = new Vector2(0, 0);
        if (Input.GetKey(moveKey[0]) | Input.GetKey(moveKeySub[0]))
        {
            move += new Vector2(0, moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(moveKey[1]) | Input.GetKey(moveKeySub[1]))
        {
            move += new Vector2(0, -moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(moveKey[2]) | Input.GetKey(moveKeySub[2]))
        {
            move += new Vector2(moveSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(moveKey[3]) | Input.GetKey(moveKeySub[3]))
        {
            move += new Vector2(-moveSpeed * Time.deltaTime, 0);
        }
        if (move != new Vector2(0, 0))
        {
            time -= Time.deltaTime;
        }
        if (time < 0.0f)
        {
            audioSource.pitch = UnityEngine.Random.Range(0.7f, 1.3f);
            audioSource.Play();
            time = ashiotoTime;
        }

        rd.linearVelocity = move;
        
    }
    
}
