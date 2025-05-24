using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GameStart()
    {
        SceneManager.LoadScene("haiatume");
    }
    public void GoToWebsite(string url)
    {
        Application.OpenURL(url);
        // SceneManager.LoadScene("tobakuro's battle Scene");
    }
}
