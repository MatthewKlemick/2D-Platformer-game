using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroScript : MonoBehaviour
{
    private int ProgressNumber;

    public KeyCode Progresskey;

    public Text introText;

    void Start()
    {
        ProgressNumber = 0;
        
        StartCoroutine(wait());
    }

    void FixedUpdate()
    {

        switch (ProgressNumber) 
        {
        case 0:
            introText.text = "once there was a gready king";
            break;   
        case 1:
            introText.text = "the king asked to much of his subjects";
            break;
        case 2:
            introText.text = "the king took to much of ther're gold";
            break;
        case 3:
            introText.text = "so they exiled the king";
            break;
        default:
            SceneManager.LoadScene("Level1");
            break;
        }

    }

    
    IEnumerator wait()
    {
        yield return new WaitForSeconds(4);

        ProgressNumber += 1;

        StartCoroutine(wait());
    }
        
}
