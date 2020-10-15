using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WelcomeScreen : MonoBehaviour
{


    public void StartPlay()
    {
        SceneManager.LoadScene("Level Menu");
    }

    public void Facebook()
    {
        Application.OpenURL("https://facebook.com/omarfaruk-0x01");
    }

    public void Twitter()
    {
        Application.OpenURL("https://twitter.com/_omar__faruk_");
    }



}
