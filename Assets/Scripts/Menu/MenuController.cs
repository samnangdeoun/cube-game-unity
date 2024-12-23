using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        AudioManager.GetInstance().Play("vine_boom");
        SceneManager.LoadScene(sceneName);
    }
    public void LoadCurrentScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
