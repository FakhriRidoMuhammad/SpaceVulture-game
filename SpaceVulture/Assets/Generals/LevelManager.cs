using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
    

}
