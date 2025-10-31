using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Main game manager - handles game state, scene transitions, etc.
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [Header("Game State")]
    private bool isPaused = false;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Update()
    {
        // Pause/Unpause with ESC key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    
    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
        
        Debug.Log(isPaused ? "Game Paused" : "Game Resumed");
    }
    
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
    
    public bool IsPaused()
    {
        return isPaused;
    }
}
