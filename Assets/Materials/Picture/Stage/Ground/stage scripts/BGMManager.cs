using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance;       // Singleton instance
    public AudioSource audioSource;          // AudioSource to play BGM
    private float savedTime = 0f;            // Variable to save playback position
    public int sceneChangeLimit = 3;         // Number of scene changes before self-destruct
    private int sceneChangeCount = 0;        // Counter for scene changes

    private void Awake()
    {
        // Singleton pattern setup
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Prevent destruction across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy if instance already exists
            return;
        }
    }

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>(); // Retrieve attached AudioSource if available
        }

        ResumeBGM(); // Initial playback
        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to scene loaded event
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe from scene loaded event
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        sceneChangeCount++; // Increment the scene change counter

        if (sceneChangeCount >= sceneChangeLimit)
        {
            Destroy(gameObject); // Destroy after reaching the limit
        }
    }

    public void SaveCurrentPosition()
    {
        // Save the current playback position
        if (audioSource != null)
        {
            savedTime = audioSource.time;
        }
    }

    public void ResumeBGM()
    {
        // Resume playback from saved position
        if (audioSource != null)
        {
            audioSource.time = savedTime;
            audioSource.Play();
        }
    }
}
