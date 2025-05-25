using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{
    [SerializeField] GameObject howToPlayObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) & gameObject.name == "howtoplaybutton")
        {
            howToPlayObj.SetActive(false);
        }
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
    public void howToPlay()
    {
        howToPlayObj.SetActive(true);
    }
}
