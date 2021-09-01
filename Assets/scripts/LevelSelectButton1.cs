using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectButton1 : MonoBehaviour
{
    public GameObject Lvl1;
    public GameObject Lvl2;

    public string menu;

    public void flecheDroiteButton()
    {
        Lvl2.SetActive(true);
        Lvl1.SetActive(false);
    }

    public void flecheGaucheButton()
    {
        SceneManager.LoadScene(menu);
    }
}
