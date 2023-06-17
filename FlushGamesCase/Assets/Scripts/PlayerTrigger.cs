using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerTrigger : MonoBehaviour
{
    private List<GameObject> gems = new List<GameObject>();
    public Transform firstStack;
    private float time;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gem"))
        {
            other.gameObject.tag = "Stacked";
            gems.Add(other.gameObject);
            int currentGemsCount = gems.Count;
            other.gameObject.transform.SetParent(firstStack);
            other.gameObject.transform.DOLocalJump(Vector3.up * (currentGemsCount), 2, 1, 0.5f).OnComplete(
                () => other.transform.DOLocalMove(Vector3.up * (currentGemsCount), 0.1f));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        time += Time.deltaTime;

        if (other.gameObject.CompareTag("Finish") && gems.Count != 0 && time > 0.1f)
        {
            GameObject lastGem = gems[gems.Count - 1];
            gems[gems.Count - 1].transform.DOLocalJump(other.transform.position, 3, 1, 1).OnComplete(() =>
            Market.instance.Sale(lastGem));
            gems[gems.Count - 1].transform.parent = null;
            gems.RemoveAt(gems.Count - 1);
            time = 0;
        }
    }
}
