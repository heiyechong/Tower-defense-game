using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FToM : MonoBehaviour
{
    private Button startGame;
    private Button quitGame;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        startGame = transform.GetChild(0).GetComponent<Button>();
        quitGame = transform.GetChild(1).GetComponent<Button>();
        startGame.onClick.AddListener(StartGame);
        quitGame.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    private void QuitGame()
    {
#if UNITY_EDITOR //������ڱ༭��������
        UnityEditor.EditorApplication.isPlaying = false;
#else//�ڴ�������Ļ�����
    Application.Quit();
#endif
    }

}
