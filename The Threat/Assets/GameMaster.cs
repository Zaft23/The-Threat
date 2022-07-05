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

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        saveAndLoad = GetComponent<TestSaveAndLoad>();
        GameStart = true;



    audioSource.PlayOneShot(BGM);
    }

    // Start is called before the first frame update
    void Start()
    {

        
        GameIsPaused = false;
    }

    [SerializeField] float DeadTimer = 2f;
    [SerializeField] float Timer = 0;

    // Update is called once per frame
    void Update()
    {
        
        if(GameStart == true)
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


        if (Player.activeInHierarchy == false)
        {
            Timer += Time.deltaTime;
            if(Timer >= DeadTimer)
            {
                CrossHair.SetActive(false);
                Time.timeScale = 0f;
                DeadUI.SetActive(true);
                Cursor.visible = true;

            }
        
        }

        if(Player.activeInHierarchy == true)
        {

            Time.timeScale = 1f;
            DeadUI.SetActive(false);
            CrossHair.SetActive(true);
            //Cursor.visible = false;
            Resume();
            Timer = 0;

        }


        if(UpgradeMenu.activeInHierarchy == true)
        {
            Pause();

        }
        else if(UpgradeMenu.activeInHierarchy == false)
        {
            Resume();
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
           
            //Cursor.visible = true;
            UpgradeMenuToggle();
          
            

        }

        if (GameIsPaused == false)
        {
           CrossHair.SetActive(true);
        }
        else if(GameIsPaused == true)
        {
            CrossHair.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Cursor.visible = true;
            EscapeMenuToggle();


        }

        if(EscMenu.activeInHierarchy == true)
        {
            Pause();
        }
        else if(EscMenu.activeInHierarchy == false)
        {
            Resume();
        }



    }

    private void UpgradeMenuToggle()
    {
        UpgradeMenu.SetActive(!UpgradeMenu.activeSelf);
        OnToggleUpgradeMenu.Invoke(UpgradeMenu.activeSelf);
        
    }

    private void EscapeMenuToggle()
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

    }

    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;


    }

    //private IEnumerator ActivateDeadUI()
    //{
    //    yield return new WaitForSeconds(2f);
    //    //_trailRenderer.emitting = false;
    //    DeadUI.SetActive(true);


    //}

}
