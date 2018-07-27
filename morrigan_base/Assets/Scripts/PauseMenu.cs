using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject UI;
    public GameObject buttons;
    public GameObject options;

    public bool Paused = false;
    bool inOptions = false;

    private void Start()
    {
        UI.SetActive(true);
        pauseMenu.SetActive(false);
        options.SetActive(false);
    }

    void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused && !inOptions) { Resume(); }
            else { Pause(); }            
        }
        // Options menu
        if (inOptions && Input.GetKeyDown(KeyCode.Escape)) { OK(); }
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
        inOptions = true;
        buttons.SetActive(false);
        options.SetActive(true);
    }

    public void OK()
    {
        inOptions = false;
        buttons.SetActive(true);
        options.SetActive(false);
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
