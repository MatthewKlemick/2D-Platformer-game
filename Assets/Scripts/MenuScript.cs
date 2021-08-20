using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public Button PlayButton,ExitButton,PlaySIButton;

    void Start()
    {
        PlayButton.onClick.AddListener(() => ButtonClicked(1));
        PlaySIButton.onClick.AddListener(() => ButtonClicked(2));
        ExitButton.onClick.AddListener(() => ButtonClicked(3));
    }

    void ButtonClicked(int buttonNo)
    {
        if(buttonNo == 1)
        {
            SceneManager.LoadScene("Intro");
        }
        if(buttonNo == 2)
        {
            SceneManager.LoadScene("Level1");
        }
        if(buttonNo == 3)
        {
            Application.Quit();
        }
    }
}
