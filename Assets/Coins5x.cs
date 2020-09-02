using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins5x : MonoBehaviour
{
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.ScoreCoin(5);
        Invoke("Despawn", 1.3f);
    }

    void Despawn()
    {
        Destroy(gameObject);
    }
}
