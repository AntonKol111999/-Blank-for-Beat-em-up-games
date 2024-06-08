using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Characteristics : MonoBehaviour
{
    public int Max_XP;
    public int XP;

    public int Level_Up_Point;
    public int Level = 1;
    public Text Level_Up_Point_Text;
    public Text Level_Text;

    public GameObject Level_Up_Button;
    public GameObject Level_Up_Panel;

    public PlayerAttack playerAttack;

    public int Max_HP;
    public int HP;

    public int Max_Stamina;
    public int Stamina;

    public Slider XP_Slider;
    public Text XP_Text;

    public Slider HP_Slider;
    public Text HP_Text;

    public Slider SP_Slider;
    public Text SP_Text;

    private void Start()
    {
        XP = 0;
        XP_Slider.maxValue = Max_XP;
        XP_Text.text = $"{XP}/{Max_XP}";

        HP = Max_HP;
        HP_Slider.maxValue = Max_HP;

        Stamina = Max_Stamina;
        SP_Slider.maxValue = Max_Stamina;

        StartCoroutine(TestCoroutine());
    }

    IEnumerator TestCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.25f);
            if (Stamina < Max_Stamina)
            {
                //yield return new WaitForSeconds(0.1f);
                Stamina++;
            }
        }
    }

    public void Update_XP(int inPutXP)
    {
        XP += inPutXP;
        XP_Slider.value = XP;

        if (XP >= Max_XP)
        {
            XP = 0;

            Max_XP = Mathf.FloorToInt(Max_XP + Max_XP * 0.05f);

            Level_Up_Point++;

            Level++;

            if (Level_Up_Point >= 1)
            {
                Level_Up_Button.SetActive(true);
            }
        }

        XP_Text.text = $"{XP}/{Max_XP}";

        if (Level_Up_Point >= 1)
        {
            Level_Up_Button.SetActive(true);
        }
        else
        {
            Level_Up_Button.SetActive(false);
        }
    }

    public void Level_Up_Panel_Show()
    {
        Level_Up_Panel.SetActive(true);
    }
    public void Level_Up_HP()
    {
        Max_HP = Max_HP + 10;
        HP = Max_HP;
        Level_Up_Point--;
        Level_Up_Panel.SetActive(false);
        Level_Up_Button.SetActive(false);
    }
    public void Level_Up_Stamina()
    {
        Max_Stamina = Max_Stamina + 5;
        Level_Up_Point--;
        Level_Up_Panel.SetActive(false);
        Level_Up_Button.SetActive(false);
    }
    public void Level_Up_Damage()
    {
        playerAttack.attackDamage = playerAttack.attackDamage + 10;
        Level_Up_Point--;
        Level_Up_Panel.SetActive(false);
        Level_Up_Button.SetActive(false);
    }

    private void Update()
    {
        HP_Slider.value = HP;
        HP_Text.text = $"{HP}/{Max_HP}";

        SP_Slider.value = Stamina;
        SP_Text.text = $"{Stamina}/{Max_Stamina}";

        Level_Up_Point_Text.text = Level_Up_Point + " level points available.";

        Level_Text.text = "Level " + Level;
                
    }
}
