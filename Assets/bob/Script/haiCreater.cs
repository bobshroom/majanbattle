using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class haiCreater : MonoBehaviour
{
    [SerializeField] private GameObject hai;
    [SerializeField] private Transform parent;

    [SerializeField] private float delay;
    [SerializeField] private bool isstope;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isstope = false;
        Debug.Log("コルーチンの呼び出し");
        StartCoroutine(createHai(delay));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator createHai(float waitTime)
    {
        Debug.Log("コルーチンスタート");
        while (true)
        {
            if (isstope)
            {
                yield break;
            }
            for (int i = 0; i < 10; i++)
            {
                GameObject instant = Instantiate(hai, new Vector2(UnityEngine.Random.Range(-8.0f, 8.0f), UnityEngine.Random.Range(-4.0f, 4.0f)), Quaternion.identity);
                instant.transform.SetParent(parent);
            }
            yield return new WaitForSeconds(waitTime);
        }
    }
}
