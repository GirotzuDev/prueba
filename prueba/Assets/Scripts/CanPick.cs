using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanPick : MonoBehaviour
{
    public bool canSelect = false;
    /*
    public string msg = "Esta es la observacion de mi objeto";
    public bool canSelect = false;

    private void Update(){
        if(canSelect){
            if (Input.GetKeyDown("space"))
            {
                print(msg);
            }    
        }
    }
*/
    private void OnTriggerEnter2D(Collider2D other){
        canSelect = true;
    }
    private void OnTriggerExit2D(Collider2D other){
        canSelect = false;
    }
    /*
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.GetComponent<Collider2D>().CompareTag("Object"))
        {
            if (Input.GetKeyDown("space"))
            {
                print("space key was pressed");
            }       
        }
    }
    */
}
