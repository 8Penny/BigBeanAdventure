using UnityEngine;
using UnityEngine.SceneManagement;

public class MENU : MonoBehaviour {
    
	void Start () {
		
	}

	void Update () {
		
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
        Debug.Log("Going to settings");
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
