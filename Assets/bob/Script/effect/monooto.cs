using System.Collections.Generic;
using UnityEngine;

public class monooto : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audioClips= new List<AudioClip>();
    private AudioSource audioSource;
    private float soundTime = 1.0f;
    private float time;
    private Rigidbody2D rb;
    private float power = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time -= Time.deltaTime;
        if (rb.linearVelocity.magnitude >= power * rb.mass) { //音を鳴らす条件を満たした場合
            if (time <= 0.0f)
            {
                time = soundTime * UnityEngine.Random.Range(0.5f, 1.5f);
                audioSource.PlayOneShot(audioClips[UnityEngine.Random.Range(0, audioClips.Count)]);
            }
        }
    }
}
