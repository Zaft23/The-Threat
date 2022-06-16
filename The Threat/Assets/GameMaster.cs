using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameMaster : MonoBehaviour
{
    public GameObject UpgradeMenu;
    public GameObject EscMenu;
    public GameObject CrossHair;

    //delegate
    public delegate void UpgradeMenuCallBack(bool active);
    public UpgradeMenuCallBack OnToggleUpgradeMenu;

    public static bool GameIsPaused = false;

    [SerializeField]

    public static int SkillPoints;
    public static int Level;
    public static float Exp;



    // Start is called before the first frame update
    void Start()
    {
        //GameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            
            UpgradeMenuToggle();
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
            

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
            
            EscapeMenuToggle();
            if (GameIsPaused == true)
            {
                Resume();
            }
            else
            {
                Pause();
            }


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

    public void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
        
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        
    }
}
