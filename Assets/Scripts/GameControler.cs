using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameControler : MonoBehaviour
{

    public Animator PauseAnim;
    public GameObject PausePanal;

    private GameObject Blocks;
    public GameObject PowerManager;
    public GameObject CompleteUi;
    public GameObject GameOverUI;
    public Transform powerSupplyer;
    public List<Vector2> PowersPosition;


    public static int Score = 0;
    public static int PlayerLife = 3;
    public static int NormalBlockPerScore = 10;
    public static int BrickableBlockPerScore = 20;
    public static int FreezedBlockPerScore = 30;

    public static int NormalBlockNumber = 0;
    public static int BrickableBlockNumber = 0;
    public static int FreezedBlockNumber = 0;


    public static bool isGameOver = false;
 
    public static bool isGamePaused = false;
    // Power Section - End - 


        public void Restart()
    {
        ResetAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public static void ResetAll()
    {
        Score = 0;
        PlayerLife = 3;
        NormalBlockNumber = 0;
        BrickableBlockNumber = 0;
        FreezedBlockNumber = 0;
        isGamePaused = false;
        isGameOver = false;
        GameObject.FindWithTag("Ball").SendMessage("ResetBall");
        GameObject.FindWithTag("Player").SendMessage("ResetBar");
}
    public Rigidbody2D Player, Ball;


    public void IncreaseBlockNumber(string blockName)
    {
      
    }

    void Start()
    {

        Blocks = GameObject.FindWithTag("LevelBlock");
        StartCoroutine("LoadPower");
        GameManager.isBallMoving = false;
        Time.timeScale = 1;
    }


    IEnumerator LoadPower()
    {
        while (!isGameOver)
        {
            Invoke("PowerLoad", 5);
            yield return new WaitForSeconds(5);
        }
    }
    void PowerLoad()
    {
       if (Blocks.transform.childCount > 3)
        {
            int Rnd = Mathf.CeilToInt(Random.Range(0f, PowerManager.transform.childCount));

            Transform Block = Blocks.transform.GetChild(Mathf.CeilToInt(Random.Range(0f, Blocks.transform.childCount - 1)));
            if (Block.tag != "NonBrickable_Block")
            {

            
            Transform Power = PowerManager.transform.GetChild(Rnd >= PowerManager.transform.childCount ? PowerManager.transform.childCount - Rnd : Rnd);
            GameObject PowerClone = Instantiate(Power.gameObject, powerSupplyer);
            PowerClone.transform.position = Block.transform.position;
            PowersPosition.Add(Block.transform.position);
            PowerClone.SetActive(false);
            Block.SendMessage("SetPower", PowerClone);
            if (powerSupplyer.childCount > 1 && !powerSupplyer.GetChild(0).gameObject.activeInHierarchy)
            {
                Destroy(powerSupplyer.GetChild(0).gameObject);
            }

            }
            else
            {
                Invoke("PowerLoad", 0);
            }

        }
        else
        {
            StopCoroutine("LoadPower");
        }
      
    }


    void Update()
    {
        if (isGamePaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }


        if(PlayerLife < 1)
        {
            GameOverUI.SetActive(true);
            Time.timeScale = 0;
            isGameOver = true;

        }

        if (GameObject.FindWithTag("Normal_Block") == null && GameObject.FindWithTag("Brickable_Block") == null && GameObject.FindWithTag("Freezed_Block") == null)
        {
            CompleteUi.SetActive(true);
            Time.timeScale = 0;
        }

    }



    public void ResumeGame()
    {
        StartCoroutine("LoadAnim");
    }


    IEnumerator LoadAnim()
    {
        PauseAnim.SetTrigger("down");
        yield return new WaitForSeconds(1f);
        PausePanal.SetActive(false);
    }




    public void JumpNextLevel()
    {
        GameManager.CurrentLevel += 1;
        Restart();
    }
    public void JumpToHome()
    {
        SceneManager.LoadScene("Welcome");
        ResetAll();
    }



    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && !GameManager.isBallMoving)
        {
            Ball.gameObject.SendMessage("GoBall");
            GameManager.isBallMoving = true;
        }


            if (Input.touchCount > 0)
            {
                Debug.Log(Input.GetTouch(0).position);
                if (Input.GetTouch(0).position.y > 500f && Input.GetTouch(0).position.y < Screen.safeArea.height - 150 && !GameManager.isBallMoving)
                {
                    Ball = GameObject.FindWithTag("Ball").GetComponent<Rigidbody2D>();
                    Ball.gameObject.SendMessage("GoBall");
                    GameManager.isBallMoving = true;
                }

            }
        }


    }


