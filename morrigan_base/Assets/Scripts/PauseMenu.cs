using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public static bool Paused = false;
    public GameObject pauseMenu;
    public GameObject UI;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Resume();
            } else
            {
                Pause();
            }
            
        }
	}

    void Pause()
    {
        pauseMenu.SetActive(true);
        UI.SetActive(false);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        UI.SetActive(true);
        Time.timeScale = 1f;
        Paused = false;
    }

    public void Options()
    {
        Debug.Log("Options");
    }

    public void Exit()
    {
        Debug.Log("Exit");
    }
}
