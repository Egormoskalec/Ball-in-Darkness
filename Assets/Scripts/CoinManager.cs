using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public GameObject CoinPrefab;
    public List<Coin> CoinsList = new List<Coin>();
    public TMP_Text CoinsText;
    public GameObject bloodMarkPrefab;
    private AudioController audioController;
    public float initialCoins = 50;

    private void Start()
    {
        audioController = FindObjectOfType<AudioController>();

        for (int i = 0; i < initialCoins; i++)
        {
            Vector3 position = new Vector3(Random.Range(-20f, 20f), 0.5f, Random.Range(-20f, 20f));
            GameObject newCoin = Instantiate(CoinPrefab, position, Quaternion.identity);
            CoinsList.Add(newCoin.GetComponent<Coin>());
        }

        UpdateText();
    }

    public void CollectCoin(Coin coin)
    {
        CoinsList.Remove(coin);
        Destroy(coin.gameObject);
        Vector3 bloodPosition = new Vector3(coin.transform.position.x, 0, coin.transform.position.z);
        Instantiate(bloodMarkPrefab, bloodPosition, coin.transform.rotation);
        
        UpdateText();
        audioController.PlayDeathSound();
    }

    private void UpdateText() {
        CoinsText.text = "Залишилось зібрати " + CoinsList.Count.ToString();
    }

    public Coin GetClosest(Vector3 point)
    {
        float minDistance = Mathf.Infinity;
        Coin closestCoin = null;
        for (int i = 0; i < CoinsList.Count; i++)
        {
            float distance = Vector3.Distance(point, CoinsList[i].transform.position);

            if(distance < minDistance)
            {
                minDistance = distance;
                closestCoin = CoinsList[i];
            }
        }

        return closestCoin;
    }
}
