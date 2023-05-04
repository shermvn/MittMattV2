using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAnimBehavior : MonoBehaviour
{
    private Animator anim;
    private static BasicAnimBehavior Instance;
    private bool hasTriggered = false;
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
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !hasTriggered)
        {
            // code to execute when collision occurs for the first time
            anim.SetBool("isIdle", false);
            anim.SetBool("isMove", true);
            Debug.Log("button");
            PlayerBehavior.Instance.ArcadeButton();
            hasTriggered = true;
        }
    }
}
