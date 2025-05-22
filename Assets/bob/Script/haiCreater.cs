using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEditor;

public class haiCreater : MonoBehaviour
{
    [SerializeField] private GameObject hai;
    [SerializeField] private Transform parent;

    [SerializeField] private float delay;
    [SerializeField] private bool isstope;
    [SerializeField] private List<pai_status> pai_Statuses = new List<pai_status>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pai_Statuses = LoadAllPai("Assets/bob/ScriptableObject/pai_script");
        isstope = false;
        StartCoroutine(createHai(delay));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator createHai(float waitTime)
    {
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
                int index = UnityEngine.Random.Range(0, pai_Statuses.Count);
                instant.GetComponent<haiManager>().pai_Status = pai_Statuses[index];
                pai_Statuses.RemoveAt(index);
                if (pai_Statuses.Count == 0)
                {
                    yield break;
                }
            }
            yield return new WaitForSeconds(waitTime);
        }
    }
    
    private List<pai_status> LoadAllPai(string folderPath)
    {
        List<pai_status> scriptableObjects = new List<pai_status>();

        // フォルダ内のアセットパスを取得
        string[] assetPaths = AssetDatabase.FindAssets("t:ScriptableObject", new[] { folderPath });

        foreach (string assetPath in assetPaths)
        {
            string path = AssetDatabase.GUIDToAssetPath(assetPath);
            pai_status obj = AssetDatabase.LoadAssetAtPath<pai_status>(path);

            if (obj != null)
            {
                if (obj.id == 15 | obj.id == 25 | obj.id == 35)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        scriptableObjects.Add(obj);
                    }
                } else if ((int)(obj.id / 10) != 5) {
                    for (int i = 0; i < 4; i++)
                    {
                        scriptableObjects.Add(obj);
                    }
                }
                else
                {
                    scriptableObjects.Add(obj);
                }
            }
        }

        return scriptableObjects;
    }

}
