using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameMaster : MonoBehaviour
{
    public GameObject UpgradeMenu;
    public GameObject EscMenu;
    public GameObject CrossHair;
    public GameObject DeadUI;
    [SerializeField]TestSaveAndLoad saveAndLoad;

    public GameObject DialoguePrinter;

    public GameObject Player;

    public AudioSource audioSource;
    public AudioClip BGM;

    //delegate
    public delegate void UpgradeMenuCallBack(bool active);
    public UpgradeMenuCallBack OnToggleUpgradeMenu;

    //public static bool GameIsPaused = false;
    public bool GameIsPaused = false;

    public bool GameStart;

    [SerializeField]

    public static int SkillPoints;
    public static int Level;
    public static float Exp;

    public bool IsNotGameScene;
    public bool PlayerDead;


    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        saveAndLoad = GetComponent<TestSaveAndLoad>();
        GameStart = true;



    audioSource.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerDead = false;
        
        GameIsPaused = false;
    }

    [SerializeField] float DeadTimer = 2f;
    [SerializeField] float Timer = 0;

    // Update is called once per frame
    void Update()
    {
        
        if(GameStart == true && IsNotGameScene == false)
        {
            saveAndLoad.LoadPlayer();
            GameStart = false;
        }
        
        //if(DialoguePrinter.activeInHierarchy == true)
        //{
        //    Pause();
        //}
        //else
        //{
        //    Resume();
        //}

        //audioSource.PlayOneShot(BGM);
        //Player = GameObject.FindGameObjectWithTag("Player");
        if (GameIsPaused == true)
        {
            Time.timeScale = 0f;
            Cursor.visible = true;
            
        }
        if (GameIsPaused == false)
        {
            Time.timeScale = 1f;
            Cursor.visible = false;
        }


        if (Player.activeInHierarchy == false && IsNotGameScene == false)
        {
            PlayerDead = true;

            Timer += Time.deltaTime;
            if(Timer >= DeadTimer)
            {
                CrossHair.SetActive(false);
                Time.timeScale = 0f;
                DeadUI.SetActive(true);
                Cursor.visible = true;

            }
        
        }
        else if(Player == null)
        {
            Debug.Log("not game scene");
        }

        if(Player.activeInHierarchy == true && PlayerDead == true)
        {
            PlayerDead = false;

            Time.timeScale = 1f;
            DeadUI.SetActive(false);
            CrossHair.SetActive(true);
            //Cursor.visible = false;
            //Resume();
            Timer = 0;

        }


    

        if (Input.GetKeyDown(KeyCode.U))
        {
           
            //Cursor.visible = true;
            UpgradeMenuToggle();
          
            

        }

        //if (UpgradeMenu.activeInHierarchy == true)
        //{
        //    Pause();
        //    //CrossHair.SetActive(false);

        //}
        //else if (UpgradeMenu.activeInHierarchy == false)
        //{
        //    Resume();
        //    //CrossHair.SetActive(true);
        //}

        //if (GameIsPaused == false)
        //{
        //   CrossHair.SetActive(true);
        //}
        //else if(GameIsPaused == true)
        //{
        //    CrossHair.SetActive(false);
        //}

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Cursor.visible = true;
            EscapeMenuToggle();


        }

        if(EscMenu.activeInHierarchy == true || UpgradeMenu.activeInHierarchy == true)
        {
            Pause();
            CrossHair.SetActive(false);
        }
        else if(EscMenu.activeInHierarchy == false || UpgradeMenu.activeInHierarchy == false)
        {
            Resume();
            CrossHair.SetActive(true);
        }



    }

    public void UpgradeMenuToggle()
    {
        UpgradeMenu.SetActive(!UpgradeMenu.activeSelf);
        OnToggleUpgradeMenu.Invoke(UpgradeMenu.activeSelf);
        
    }

    public void EscapeMenuToggle()
    {
        EscMenu.SetActive(!EscMenu.activeSelf);
        OnToggleUpgradeMenu.Invoke(EscMenu.activeSelf);
    }

    public void ToggleOffSkillMenu()
    {
        UpgradeMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
    }


    public void ResumeGame()
    {
        EscMenu.SetActive(false);
        Resume();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
        CrossHair.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
        CrossHair.SetActive(true);

    }

    //private IEnumerator ActivateDeadUI()
    //{
    //    yield return new WaitForSeconds(2f);
    //    //_trailRenderer.emitting = false;
    //    DeadUI.SetActive(true);


    //}

}
