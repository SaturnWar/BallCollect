using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    [Header ("Скорость передвижения")]
    [Tooltip ("Изменяется в диапазоне от 1 до 10")]
    [Range (1, 10)]
    [SerializeField] private float _speed;

    [Space(15)]
    [Header ("Поле для вывода очков")]
    [Tooltip ("Текстовое поле")]

    [SerializeField] private Text _countText;
    [Space(15)]
    [Header ("Цель уровня")]
    [Tooltip ("Сколько собрать кубов перед финишем")]
    [Min (3)]
    [SerializeField] private int _goal;

    [Header ("Игровые панели")]
    [Tooltip ("Панель паузы и т.д")]
    [SerializeField] private GameObject _NextLevel;
    [Tooltip ("Игровая Панель")]
    [SerializeField] private GameObject _GamePanel;
    [Tooltip ("Панель Проигрыша")]
    [SerializeField] private GameObject _LoosePanel;

    private Rigidbody _theRB;
    public int _count;
    private AudioSource _audioSource;
    // Войд Старт выполняется при запуске проекта
    void Start()
    {
        _countText.text = ((int)_count).ToString() + "/" + ((int)_goal).ToString();
        _theRB = GetComponent<Rigidbody>();
    }

    // Войд Апдейт выполняется каждый кадр
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        Vector3 _movement = new Vector3(Horizontal, 0.0f, Vertical);
        _theRB.AddForce(_movement * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
        
        other.gameObject.SetActive(false);
         _count += 1;
        _countText.text = ((int)_count).ToString() + "/" + ((int)_goal).ToString();

        if (other.gameObject.CompareTag("Danger"))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 0;
            _GamePanel.SetActive(false);
            _LoosePanel.SetActive(true);
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            if(_count >= _goal)
            {
                Time.timeScale = 0;
                _NextLevel.SetActive(true);
                _GamePanel.SetActive(false);
            }
        }
    }
}
