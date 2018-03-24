using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SplashScreen : MonoBehaviour {

    public Image splashImage;

    private void Start()
    {
        splashImage.canvasRenderer.SetAlpha(0.0f);
        StartCoroutine(SplashProcess());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            SceneManager.LoadScene("mainMenu");
        }
    }

    void SplashIn()
    {
        splashImage.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    void SplashOut()
    {
        splashImage.CrossFadeAlpha(0.0f, 2.5f, false);
    }

    public IEnumerator SplashProcess()
    {
        SplashIn();
        yield return new WaitForSeconds(2);
        SplashOut();
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
    }
}
