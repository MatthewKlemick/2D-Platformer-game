using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(BTM());
    }
    IEnumerator BTM()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");
    }

}
