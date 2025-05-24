using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
public class endingManager : MonoBehaviour
{
    string projectId = "majanbattle-87e14";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(GetFirestoreData());
        StartCoroutine(UpdateScore("auto", false));    //プレイヤーが未選択の状態に書き換え
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator GetFirestoreData()
    {
        Debug.Log("firebaseからデータを取得");
        string url = $"https://firestore.googleapis.com/v1/projects/{projectId}/databases/(default)/documents/selectCharacter";

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

    IEnumerator UpdateScore(string documentId, bool test)
    {
        Debug.Log("データの書き換え開始");
        string url = $"https://firestore.googleapis.com/v1/projects/{projectId}/databases/(default)/documents/selectCharacter/{documentId}?updateMask.fieldPaths=isSelectChara";

        string json = $@"
        {{
            ""fields"": {{
                ""isSelectChara"": {{""booleanValue"": {test.ToString().ToLower()} }}
            }}
        }}";

        var request = new UnityWebRequest(url, "PATCH");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("更新失敗: " + request.error);
        }
        else
        {
            Debug.Log("Boolean更新成功:\n" + request.downloadHandler.text);
        }
        Debug.Log("データの書き換え終了");
}
}
