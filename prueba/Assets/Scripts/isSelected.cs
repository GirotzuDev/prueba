using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isSelected : MonoBehaviour
{
    public bool pista = false;
    private bool playerIn = false;
    [SerializeField] private GameObject dialog;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines; 
    private void Update(){
        if(playerIn){
            if (Input.GetKeyDown("space"))
            {
                print("msg");
            }    
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<Collider2D>().CompareTag("Player"))
        {
            playerIn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.GetComponent<Collider2D>().CompareTag("Player"))
        {
            playerIn = false;
        }
    }
}
