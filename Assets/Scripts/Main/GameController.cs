using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    
    private Transform Setting;
    private Transform ButtonController;
    private Transform ContinueGame;
    private Transform RecessGame;
    private Transform OverGame;
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        Setting = transform.GetChild(0);
        ButtonController = Setting.GetChild(0);
        ContinueGame = ButtonController.GetChild(0);
        RecessGame = ButtonController.GetChild(1);
        OverGame = ButtonController.GetChild(2);

        ContinueGame.GetComponent<Button>().onClick.AddListener(GameContinue);
        RecessGame.GetComponent<Button>().onClick.AddListener(GameRecess);
        OverGame.GetComponent<Button>().onClick.AddListener(GameOver);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Time.timeScale = 0;
            Setting.gameObject.SetActive(true);
            
        }
       
    }


    private void GameContinue()
    {
        Time.timeScale = 1;
        Setting.gameObject.SetActive(false);
    }

    private void GameRecess()
    {
        MonsterManager.waveIndex = 0;
        MonsterManager.monsterwaves = 10;
        MonsterManager.monsterCount = 0;
        SceneManager.LoadScene("Main");
        Time.timeScale = 1;
        //Setting.gameObject.SetActive(false);
    }
    private void GameOver()
    {
#if UNITY_EDITOR //如果是在编辑器环境下
        UnityEditor.EditorApplication.isPlaying = false;
#else//在打包出来的环境下
    Application.Quit();
#endif
    }
}
