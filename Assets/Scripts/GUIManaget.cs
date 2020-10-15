using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GUIManaget : MonoBehaviour
{

    public GUIStyle ScoreUI;
    public GUIStyle LifeImage;
    public GUIStyle PlayerLifeUI;
    public GUIStyle PauseBtnUI;
    public GUIStyle LevelText;
    public Button PauseBtn;
    public Canvas PauseBtnCanvas;

    public Button Resume, Paused_Home, Paused_Restart;
    public GameObject LevelListObject;


    Vector2 ScreenSize;
    float ScreenWidth;
    float ScreenHeight;
    // Start is called before the first frame update
    void Awake()
    {
        ScreenSize = new Vector2(Screen.safeArea.width, Screen.safeArea.height);
        ScreenWidth = Screen.safeArea.width;
        ScreenHeight = Screen.safeArea.height;

 
    }

    void LoadLevel()
    {
        Destroy(GameObject.FindWithTag("LevelBlock"));
        Transform CurrentLevelBlock = Instantiate(LevelListObject.transform.GetChild(GameManager.CurrentLevel - 1));
        CurrentLevelBlock.position = new Vector2(
            Camera.main.ScreenToWorldPoint(new Vector3(ScreenWidth / 2, 0f, 0f)).x,
            Camera.main.ScreenToWorldPoint(new Vector3(0f, ScreenHeight - 100, 0f)).y - CurrentLevelBlock.localScale.y  
            );

            // new Vector2(, );
    }

    void Start()
    {
        PauseBtn.onClick.AddListener(TriggerPauseManu);
        Paused_Home.onClick.AddListener(JumpToHome);
        Paused_Restart.onClick.AddListener(Restart);
        Resume.onClick.AddListener(TriggerResume);
        LoadLevel();

       
    }

    void OnGUI()
    {
        GUI.Label(new Rect(ScreenWidth - 240 - 300, (Screen.height - ScreenHeight) + 20, 300, 100), "" + GameControler.Score, ScoreUI);
        GUI.Label(new Rect((Screen.width - ScreenWidth) + 200, (Screen.height - ScreenHeight) + 20, 300, 100), "Lavel " + (GameManager.CurrentLevel < 10 ? "0" : "") + GameManager.CurrentLevel, LevelText);
        GUI.Box(new Rect(ScreenWidth - 240, (Screen.height - ScreenHeight) + 20, 90, 90),  "", LifeImage);
        GUI.Label(new Rect(ScreenWidth  - 150, (Screen.height - ScreenHeight) + 20, 100, 100), "" + GameControler.PlayerLife, PlayerLifeUI);

        //   if (GUI.Button(new Rect((Screen.width - ScreenWidth )+ 20, (Screen.height - ScreenHeight) + 20, 130, 130), "Click"))

        //    Debug.Log("Pause");

        PauseBtn.gameObject.transform.position = new Vector2(
            Camera.main.ScreenToWorldPoint(new Vector3((Screen.width -ScreenWidth), 0f,0f)).x + PauseBtn.transform.localScale.x /3,
            Camera.main.ScreenToWorldPoint(new Vector3(0f,ScreenHeight ,0f)).y - PauseBtn.transform.localScale.y /3
            );
    }


    public void TriggerResume()
    {

        GameControler.isGamePaused = false;
    }

    public void TriggerPauseManu()
    {
        GameControler.isGamePaused = true;
    }

    public void JumpToHome()
    {

    }

    public void Restart()
    {

    }
}
