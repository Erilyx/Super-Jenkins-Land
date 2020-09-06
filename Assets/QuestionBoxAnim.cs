using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class QuestionBoxAnim : MonoBehaviour
{

    public Animator animController;
    public GameObject coin;

    // Start is called before the first frame update
    void Start()
    {
        animController = GetComponent<Animator>();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
            if (other.gameObject.CompareTag("Player"))
            {
                animController.Play("QuestionBox_anim");
                Vector3 temp = new Vector3(transform.position.x + 0.49f, transform.position.y + 1.1f, 0);
                Instantiate(coin, temp, quaternion.identity);
            }
           
    }
}
