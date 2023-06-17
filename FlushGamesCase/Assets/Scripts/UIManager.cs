using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject popUpUI;
    public GameObject gemUI;
    public Transform canvas;

    public TextMeshProUGUI goldScore;
    [HideInInspector] public int gold;

    private void Awake()
    {
        instance = this;

        if (PlayerPrefs.HasKey(nameof(gold)))
        {
            gold = PlayerPrefs.GetInt(nameof(gold));
            goldScore.text = gold.ToString();
        }

        for (int i = 0; i < ObjectPool.instance.pools.Length; i++)
        {
            canvas.transform.GetChild(i).GetChild(2).GetComponent<TextMeshProUGUI>().text =
            "Collected Gem:" + ObjectPool.instance.pools[i].collectedGem;
        }
    }

    public void OpenUI()
    {
        popUpUI.SetActive(true);
    }

    public void CloseUI()
    {
        popUpUI.SetActive(false);
    }

    public void UpdateGoldScore(int score)
    {
        gold += score;
        PlayerPrefs.SetInt(nameof(gold), gold);
        goldScore.text = gold.ToString();
    }
}
