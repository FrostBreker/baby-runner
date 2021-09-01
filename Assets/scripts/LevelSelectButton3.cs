using UnityEngine;

public class LevelSelectButton3 : MonoBehaviour
{
  //  public GameObject Lvl4;
    public GameObject Lvl2;
    public GameObject Lvl3;

  /*  public void flecheDroiteButton()
    {
        Lvl4.SetActive(true);
        Lvl3.SetActive(false);
    }
  */
    public void flecheGaucheButton()
    {
        Lvl2.SetActive(true);
        Lvl3.SetActive(false);
    }
}
