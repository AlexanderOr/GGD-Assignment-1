using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GameObject WinUI;

    public void OnTriggerEnter2D(Collider2D Enter)
    {
        if(Enter.gameObject.tag == "Win")
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            WinUI.SetActive(true);

        }
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
