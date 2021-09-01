using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject infoPanelUI;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            }
        }
    }

    void Paused()
    {
        PlayerMovement.instance.enabled = false;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Resume()
    {
        PlayerMovement.instance.enabled = true;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }

    public void LoadMainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void RetryButton()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;
        //Premiere Scene ou il y a le joueur de base
        if (sceneName == "Level01")
        {
            Resume();
            Inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickedUpInThisSceneCount);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PlayerHealth.instance.Repsawn();
            pauseMenuUI.SetActive(false);
        }
        //autre scene ou il n'y pas de joueur 
        if (sceneName == "Level02")
        {
            Resume();
            Inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickedUpInThisSceneCount);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PlayerHealth.instance.Repsawn();
            pauseMenuUI.SetActive(false);
        }

        if (sceneName == "Level03")
        {
            Resume();
            Inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickedUpInThisSceneCount);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PlayerHealth.instance.Repsawn();
            pauseMenuUI.SetActive(false);
        }

        if (sceneName == "Level0202")
        {
            Resume();
            Inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickedUpInThisSceneCount);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PlayerHealth.instance.Repsawn();
            pauseMenuUI.SetActive(false);
        }

        if (sceneName == "Level0102")
        {
            Resume();
            Inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickedUpInThisSceneCount);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            PlayerHealth.instance.Repsawn();
            pauseMenuUI.SetActive(false);
        }
    }

    public void PauseButton()
    {
        pauseMenuUI.SetActive(true);
    }

    public void InfoButton()
    {
        infoPanelUI.SetActive(true);
    }

    public void CloseInfoPanel()
    {
        infoPanelUI.SetActive(false);
    }
}
