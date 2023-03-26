using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GetItem : MonoBehaviour
{
    public string variable = "object";
    public string nameObject;
    public int contador = 0;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("object" + contador))
        {
            Inventory inventory = this.gameObject.GetComponent<Inventory>(); // obtiene la instancia del inventario del jugador
            if (inventory != null)
            {
                nameObject = variable + contador;
                GameObject objectSearch = GameObject.Find(nameObject);
                contador += 1;
                if (objectSearch != null) 
                {
                    inventory.AddItem(objectSearch); // agrega el objeto al inventario
                    Destroy(objectSearch); // elimina el objeto recolectable de la escena
                }
                else 
                {
                    UnityEngine.Debug.Log("nombre no valido");
                    UnityEngine.Debug.Log(objectSearch);
                    UnityEngine.Debug.Log(nameObject);
                    UnityEngine.Debug.Log(variable);
                }
            }
        }
    }
}
