using UnityEngine;
using UnityEngine.SceneManagement;

public class MENU : MonoBehaviour {

    public GameObject buttons;
    public GameObject SettingsMenu;
    public GameObject CloseText;

    bool inMenu = true;
    bool inSettings = false;
    bool inExit = false;

    //bool isRus = false;
    //bool sub = false;

    void Start()
    {
        SettingsMenu.SetActive(false);
        CloseText.SetActive(false);
    }

    void Update () {
        // Exit menu
        if (inMenu && !inSettings && Input.GetKeyDown(KeyCode.Escape)) { CloseGame(); };
        if (inExit && Input.GetKeyDown(KeyCode.Y)) { Application.Quit(); Debug.Log("quit"); }
        if (inExit && Input.GetKeyDown(KeyCode.N)) { buttons.SetActive(true); CloseText.SetActive(false); inExit = false; inMenu = true; }
        // Settings menu
        if (inSettings && Input.GetKeyDown(KeyCode.Escape)) { OK(); }
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Continue()
    {
        Debug.Log("Continue previous game");
    }

    public void Settings()
    {
        inMenu = false;
        inSettings = true;
        buttons.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    public void OK()
    {
        inMenu = true;
        inSettings = false;
        SettingsMenu.SetActive(false);
        buttons.SetActive(true);
    }

    public void CloseGame()
    {
        inMenu = false;
        inExit = true;
        buttons.SetActive(false);
        CloseText.SetActive(true);
    }
}
