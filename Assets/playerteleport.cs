using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerteleport : MonoBehaviour
{
    public GameObject currentTeleport;
    public Collider2D coll;
    void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("teleport"))
        {
            currentTeleport = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("teleport"))
        {
            if(collision.gameObject == currentTeleport)
            {
                currentTeleport = null;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if(currentTeleport != null)
            {
                transform.position = currentTeleport.GetComponent<Teleport>().GetDestination().position;
            }
        }
    }
}
