using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonFunctions : MonoBehaviour
{

    GameObject parentObject;
    GameObject mainButtonGroup;
    GameObject settingsButtonGroup;
    GameObject levelButtonGroup;
    GameObject numberOfPlayersSelection;

    int selectedLevel = 0;

    private void Start() {
        parentObject = gameObject.transform.parent.gameObject;

        mainButtonGroup = GetChildWithName(parentObject, "MainButtonGroup");
        settingsButtonGroup = GetChildWithName(parentObject, "SettingsButtonGroup");
        levelButtonGroup = GetChildWithName(parentObject, "LevelButtonGroup");
        numberOfPlayersSelection = GetChildWithName(parentObject, "NumberOfPlayersSelection");

        mainButtonGroup.SetActive(true);
        settingsButtonGroup.SetActive(false);
        levelButtonGroup.SetActive(false);
        numberOfPlayersSelection.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

    public void OpenSettings()
    {
        mainButtonGroup.SetActive(false);
        settingsButtonGroup.SetActive(true);
    }

    public void OpenLevelSelection()
    {
        mainButtonGroup.SetActive(false);
        levelButtonGroup.SetActive(true);
    }

    public void BackToMainMenu()
    {
        mainButtonGroup.SetActive(true);
        settingsButtonGroup.SetActive(false);
        levelButtonGroup.SetActive(false);
        settingsButtonGroup.SetActive(false);
    }

    public void BackToLevelSelection()
    {
        mainButtonGroup.SetActive(false);
        settingsButtonGroup.SetActive(false);
        levelButtonGroup.SetActive(true);
        settingsButtonGroup.SetActive(false);
        numberOfPlayersSelection.SetActive(false);
    }

    public void SelectLevel(int level)
    {
        selectedLevel = level;
        levelButtonGroup.SetActive(false);
        numberOfPlayersSelection.SetActive(true);
    }

    public void SelectNoOfPlayers(int noOfPlayers)
    {
        PlayerPrefs.SetFloat("noOfPlayers", noOfPlayers);
        StartLevel();
    }

    public void StartLevel()
    {
        switch(selectedLevel)
        {
            case 1: SceneManager.LoadScene("SampleScene");
                    break;
        }
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
