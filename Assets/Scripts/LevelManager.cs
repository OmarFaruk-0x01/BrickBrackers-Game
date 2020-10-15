using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
            
    }

    public void LevelLoad(int levelIndex)
    {
        GameManager.CurrentLevel = levelIndex;
        SceneManager.LoadScene("Main");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
