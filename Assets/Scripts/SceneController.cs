using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static SceneController _instance;
    public static SceneController Instance { get { return _instance; } }
    public static int Score { get; set; } = 0;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    public static void StartGame()
    {
        Score = 0;
        SceneManager.LoadScene("Game");
    }

    public static void EndGame()
    {
        SceneManager.LoadScene("End");
    }

    public static void Menu()
    {
        SceneManager.LoadScene("Start");
    }
}
