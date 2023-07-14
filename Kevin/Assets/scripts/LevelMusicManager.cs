using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMusicManager : MonoBehaviour
{
    public AudioClip[] levelMusic;  
    private AudioSource audioSource;
    private bool isPaused = false;
    private bool isResuming = false;
    public Button startButton;  

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded;

        
        startButton.onClick.AddListener(StartMusic);
    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

          
            if (isPaused)
            {
                audioSource.Pause();
            }
            else
            {
             
                if (!isResuming)
                {
                    isResuming = true;
                    audioSource.Play();
                }
                else
                {
                    audioSource.UnPause();
                    isResuming = false;
                }
            }
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int currentLevelIndex = scene.buildIndex;

 
        if (currentLevelIndex < levelMusic.Length)
        {
            AudioClip levelClip = levelMusic[currentLevelIndex];

            
            audioSource.clip = levelClip;
            audioSource.Play();
        }
    }

    private void StartMusic()
    {
  
        audioSource.Stop();
        audioSource.Play();
    }
}
