using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectButton2 : MonoBehaviour
{
    public GameObject Lvl3;
    public GameObject Lvl1;
    public GameObject Lvl2;

    public void flecheDroiteButton()
    {
        Lvl3.SetActive(true);
        Lvl2.SetActive(false);
    }

    public void flecheGaucheButton()
    {
        Lvl1.SetActive(true);
        Lvl2.SetActive(false);
    }
}
