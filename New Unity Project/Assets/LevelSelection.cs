using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class LevelSelection : MonoBehaviour
{
    private string[] LevelList;
    private int current;
    public TextMeshProUGUI LevelName;
    public Image selected;
    public Sprite level1_img;
    public Sprite level2_img;
    public Sprite level3_img;
    public Sprite level4_img;
    public Sprite level5_img;
    public Sprite level6_img;
    private Sprite[] LevelImage;


    // Start is called before the first frame update
    void Start()
    {
        LevelList = new string[6];
        for (int i = 0; i < 6; i++)
        {
            int j = i + 1;
            string name = "Level" + j.ToString();
            LevelList[i] = name;
        }

        current = 0;
        LevelName.text = LevelList[0];
        LevelImage = new Sprite[6];
        LevelImage[0] = level1_img;
        LevelImage[1] = level2_img;
        LevelImage[2] = level3_img;
        LevelImage[3] = level4_img;
        LevelImage[4] = level5_img;
        LevelImage[5] = level6_img;
        selected.sprite = LevelImage[0];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickRight()
    {
        if (current == 5)
        {
            current = 0;
        }
        else
        {
            current++;
           
        }
        LevelName.text = LevelList[current];
        selected.sprite = LevelImage[current];
    }

    public void OnClickLeft()
    {
        if (current == 0)
        {
            current = 5;
        }
        else
        {
            current--;
        }
        LevelName.text = LevelList[current];
        selected.sprite = LevelImage[current];
    }

    public void onClickStart()
    {
        SceneManager.LoadScene(LevelName.text);
    }
}
