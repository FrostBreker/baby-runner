using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public void Paused()
    {
        pauseMenuUI.SetActive(true);
    }
}
