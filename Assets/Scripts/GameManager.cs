using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image menuPanel;
    public TextMeshProUGUI toMenuText;

    private bool isInMenu;

    void Start()
    {
        isInMenu = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isInMenu)
        {
            toMenuText.gameObject.SetActive(false);
            isInMenu = true;
            menuPanel.gameObject.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isInMenu)
        {
            isInMenu = false;
            menuPanel.gameObject.SetActive(false);
        }
    }
}
