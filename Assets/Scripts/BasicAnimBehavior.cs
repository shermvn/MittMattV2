using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAnimBehavior : MonoBehaviour
{
    private Animator anim;
    private static BasicAnimBehavior Instance;
    //private bool hasTriggered = false;
    // Start is called before the first frame update
    private void Awake()
    {

        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        

        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space))
        {
            // code to execute when collision occurs for the first time
            //Debug.Log("move");
            anim.SetBool("isIdle", false);
            anim.SetBool("isMove", true);
            

            //hasTriggered = true;
        }
    }
}
