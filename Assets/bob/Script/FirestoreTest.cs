using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class FirestoreTest : MonoBehaviour
{
    string projectId = "majanbattle-87e14"; // ← ここにあなたのプロジェクトIDを入力

    void Start()
    {
        StartCoroutine(GetFirestoreData());
    }

    IEnumerator GetFirestoreData()
    {
        Debug.Log("firebaseからデータを取得");
        string url = $"https://firestore.googleapis.com/v1/projects/{projectId}/databases/(default)/documents/scores";

        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error: " + request.error);
        }
        else
        {
            Debug.Log("Firestore Response:\n" + request.downloadHandler.text);
        }
        Debug.Log("データの取得終了");
    }
}
