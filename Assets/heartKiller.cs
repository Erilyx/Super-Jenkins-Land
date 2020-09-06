using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartKiller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyHeart", 1);
    }

    public void DestroyHeart()
    {
        Destroy(gameObject);
    }
}
