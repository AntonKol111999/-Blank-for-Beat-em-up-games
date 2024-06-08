using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public int Top_Hero_Level;
    public int Top_Room_Level;

    public Text Top_Text;

    public Player_Characteristics player;
    public Room room;

    public GameObject Credits_Panel;

    private void Start()
    {
        LoadVariables();
    }

    public void SaveVariables()
    {
        if (player.Level > Top_Hero_Level)
        {
            Top_Hero_Level = player.Level;
        }
        if (room.Room_Lvl > Top_Room_Level)
        {
            Top_Room_Level = room.Room_Lvl;
        }

        PlayerPrefs.SetInt("Top_Hero_Level", Top_Hero_Level);
        PlayerPrefs.SetInt("Top_Room_Level", Top_Room_Level);

    }

    public void LoadVariables()
    {
        if (PlayerPrefs.HasKey("Top_Hero_Level"))
        {
            Top_Hero_Level = PlayerPrefs.GetInt("Top_Hero_Level");
        }

        if (PlayerPrefs.HasKey("Top_Room_Level"))
        {
            Top_Room_Level = PlayerPrefs.GetInt("Top_Room_Level");
        }

        Top_Text.text = $"Highest hero level: {Top_Hero_Level}\nHighest room level: {Top_Room_Level}";
    }

    public void Play()
    {
        ChangeScene("Battler");
    }
    public void Return_to_menu()
    {
        ChangeScene("Menu");
        LoadVariables();
    }
    public void Credits()
    {
        Credits_Panel.SetActive(true);
    }
    public void Exit_Credits()
    {
        Credits_Panel.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
