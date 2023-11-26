using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Buttons : MonoBehaviour
{
    private bool IsPaused = false;
    [Header ("Игровые панели")]
    [Tooltip ("Панель Следующий уровень")]
    [SerializeField] private GameObject _nextLVLpanel;
    [Tooltip ("Игровая панель")]
    [SerializeField] private GameObject _GamePanel;
    [Tooltip ("Панель Проигрыша")]
    [SerializeField] private GameObject _LoosePanel;
    [Tooltip ("Панель Паузы")]
    [SerializeField] private GameObject _PausePanel;

    [Header ("Следующий уровень")]
    [Tooltip ("Номер следующего уровня")]
    [SerializeField] private string _nextLevel;
    public void Pause()
    {
        if (!IsPaused)
        {
            _PausePanel.SetActive(true);
            _GamePanel.SetActive(false);
            Time.timeScale = 0;
            IsPaused = true;
        }
        else if (IsPaused)
        {
            Time.timeScale = 1;
            _PausePanel.SetActive(false);
            _GamePanel.SetActive(true);
            IsPaused = false;
        }
    }
    private void Uptade()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Restart();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }    
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void Next()
    {
        SceneManager.LoadScene(_nextLevel);
        Time.timeScale = 1;
    }
    public void Play()
    {
        SceneManager.LoadScene("lvl_1");
        Time.timeScale = 1;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Application.Quit();
    }
}