using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoors : MonoBehaviour
{
    public GameObject closedDoor;
    public CharacterController characterController;

    

    // Start is called before the first frame update
    void Start()
    {
        characterController = FindObjectOfType<CharacterController>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            closedDoor.SetActive(false);
            Debug.Log(characterController.moveSpeed);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            closedDoor.SetActive(true);
        }
    }

}
