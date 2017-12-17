using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour {
    public void goBack()
    {
        SceneManager.LoadScene("selectCategory");
    }

    public void retry()
    {
        SceneManager.LoadScene("gameScene");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            goBack();
    }
}
