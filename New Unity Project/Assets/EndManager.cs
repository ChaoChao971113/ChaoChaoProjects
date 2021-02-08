using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndManager : MonoBehaviour
{
    public GameObject endUI;
    public Text endMessage;
    private Spawner enemySpanwer;
    public Slider hp_slider;
    public static EndManager Instance;
    public int BaseHp = 5;
    void Awake()
    {
        Instance = this;
        enemySpanwer = GetComponent<Spawner>();
        hp_slider.value = BaseHp;
    }
    public void Win()
    {
        endUI.SetActive(true);
        endMessage.text = "WIN";
    }
    public void getHIt()
    {
        BaseHp--;
        hp_slider.value = BaseHp;
        if (BaseHp == 0)
        {
            Failed();
        }
    }

    public void Failed()
    {
        enemySpanwer.Stop();
        endUI.SetActive(true);
        endMessage.text = "Failed";
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
