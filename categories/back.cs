using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back : MonoBehaviour {
    public void goBack()
    {
        Initiate.Fade("selectCategory", Color.black, 3.5f);
    }

    public void retry()
    {
        Initiate.Fade("gameScene", Color.black, 3.5f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            goBack();
    }
}
