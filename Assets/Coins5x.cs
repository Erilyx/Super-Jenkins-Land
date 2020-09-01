using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins5x : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Despawn", 1.3f);
    }

    void Despawn()
    {
        Destroy(gameObject);
    }
}
