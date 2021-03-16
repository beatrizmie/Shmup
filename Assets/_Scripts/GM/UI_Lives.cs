using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// References for lifeBar: https://dev.to/henriquederosa/unity-criar-uma-barra-de-vida-ge4

public class UI_Lives : MonoBehaviour
{
    GameManager gm;
    public Image lifeBar;

    public int maxLives = 10;

    public int Life
    {
        get
        {
            return gm.lives;
        }
        set
        {
            gm.lives = Mathf.Clamp(value, 0, maxLives);
        }
    }

    void Start()
    {
        gm = GameManager.GetInstance();
    }

    void Update()
    {
        lifeBar.fillAmount = gm.lives*1.0f / maxLives;
    }
}
