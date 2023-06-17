using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Market : MonoBehaviour
{
    public static Market instance;

    private void Awake()
    {
        instance = this;
    }

    public void Sale(GameObject gem)
    {
        UIManager.instance.UpdateGoldScore((int)(gem.GetComponent<Gem>().price + gem.transform.localScale.x * 100));
        ObjectPool.instance.pools[gem.GetComponent<Gem>().type].collectedGem++;
        UIManager.instance.canvas.transform.GetChild(gem.GetComponent<Gem>().type).GetChild(2).GetComponent<TextMeshProUGUI>().text =
            "Collected Gem:" + ObjectPool.instance.pools[gem.GetComponent<Gem>().type].collectedGem;
        ObjectPool.instance.SendPooledObject(gem.GetComponent<Gem>().type, gem);
    }
}
