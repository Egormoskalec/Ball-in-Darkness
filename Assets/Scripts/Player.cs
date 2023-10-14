using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CoinManager CoinManager;

    private void Update()
    {
        if (!GameManager.instance.isLose && transform.position.y < -1)
        {
            GameManager.instance.Lose();
        }
        if (GameManager.instance.isLose)
        {
            if (transform.position.y < -7)
            {
                transform.position = new Vector3(0f, 25f, 0f);
            }
            else if (transform.position.y > 0f && transform.position.y < 10f)
            {
                Debug.LogWarning("kek");
                GameManager.instance.RestartGame();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Coin>())
        {
            CoinManager.CollectCoin(other.GetComponent<Coin>());
        }
    }
}
