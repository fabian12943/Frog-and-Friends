using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    private bool isGamePaused = false;
    private GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GetChildWithName(gameObject, "PauseMenu");
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseOrUnpauseGame()
    {
        if (Timer.timeRemaining > 0) 
        {
            if (!isGamePaused)
            {
                PauseGame();
            }
            else
            {
                UnpauseGame();
            }
        }
    }

    private void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
    }

    private void UnpauseGame()
    {
        Time.timeScale = 1;
        isGamePaused = false;
        pauseMenu.SetActive(false);
    }

    public void RestartLevel()
    {
        UnpauseGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitLevel()
    {
        UnpauseGame();
        SceneManager.LoadScene("Menu");
    }

    private GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null) 
        {
            return childTrans.gameObject;
        } 
        else 
        {
            return null;
        }
    }
}
