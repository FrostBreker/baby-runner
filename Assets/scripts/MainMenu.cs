using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad;
    public string levelToLoadBonus;

    public GameObject settingsWindow;
    public GameObject hidePanel;
    public GameObject chooseLevels;

    public void StartGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindows()
    {
        settingsWindow.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void HideButton()
    {
        hidePanel.SetActive(true);
    }

    public void CloseHidePanel()
    {
        hidePanel.SetActive(false);
    }

    public void ChooseLevels()
    {
        chooseLevels.SetActive(true);
    }

    public void CloseChooseLevels()
    {
        chooseLevels.SetActive(false);
    }

    public void BonusButton()
    {
        SceneManager.LoadScene(levelToLoadBonus);
    }
}
