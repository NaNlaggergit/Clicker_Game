using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagerGame : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text incomeText;
    public TMP_Text upgradeText;
    public TMP_Text lvlText;
    public Button upgradeButton;
    private int score = 0;
    private int income = 1;
    private int upgrade = 10;
    private int lvl = 0;
    void Start()
    {
        UpdateUI();
    }
    public void IncreasedScore()
    {
        score += income;
        UpdateUI();
    }
    public void OnUpgradeButtonClick()
    {
        if (score >= upgrade)
        {
            score -= upgrade;
            income += 1;
            lvl += 1;
            upgrade = upgrade * 2;
            UpdateUI();
        }
    }
    private void UpdateUI()
    {
        scoreText.text = score.ToString();
        incomeText.text = "+" + income.ToString();
        lvlText.text = "Lvl:" + lvl.ToString();
        upgradeText.text = "Upgrade:" + upgrade.ToString();
    }
    private void Update()
    {
        if (score >= upgrade)
            upgradeButton.interactable = true;
        else
            upgradeButton.interactable = false;
    }
}
