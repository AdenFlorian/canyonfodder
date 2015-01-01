using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    public GameObject mainMenu;
    public GameObject endOfRoundMenu;
    public GameObject noneMenu;
    public Text highscoreTextUI;

    private GameObject activeMenu;

    private void Awake()
    {
        Instance = this;
        activeMenu = noneMenu;
    }

    private void Start()
    {
    }

    private void Update()
    {
    }

    public void ShowMenu(Menu menu)
    {
        switch (menu) {
            case Menu.Main:
                ActivateMenu(mainMenu);
                break;

            case Menu.EndOfRound:
                ActivateMenu(endOfRoundMenu);
                break;

            case Menu.None:
                ActivateMenu(noneMenu);
                break;

            default: break;
        }
    }

    public void ActivateMenu(GameObject menuGO)
    {
        activeMenu.SetActive(false);
        activeMenu = menuGO;
        activeMenu.SetActive(true);
    }
}

public enum Menu
{
    Main,
    EndOfRound,
    None
}