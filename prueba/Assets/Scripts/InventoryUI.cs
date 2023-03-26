using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryObject;
    public GameObject buttonPrefab;
    public Transform buttonParent;
    public float buttonHeight;

    private Inventory inventory;

    void Start()
    {
        inventory = inventoryObject.GetComponent<Inventory>();
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        // Limpiar todos los botones existentes en el panel
        foreach (Transform child in buttonParent)
        {
            Destroy(child.gameObject);
        }
        int contador = 0;

        // Crear un botón para cada objeto en el inventario
        for (int i = 0; i < inventory.items.Count; i++)
        {
            GameObject buttonObject = Instantiate(buttonPrefab, buttonParent.transform);
            buttonObject.transform.localPosition = new Vector3(300, -i+ 1 * buttonHeight, 0);
            // Configurar el texto del botón con el nombre del objeto en el inventario
            buttonObject.GetComponentInChildren<Text>().text = inventory.items[contador].name;
            // Configurar el evento OnClick del botón para eliminar el objeto del inventario
            int index = i; // Crear una copia de i para que el valor no cambie dentro del evento
            buttonObject.GetComponent<Button>().onClick.AddListener(() => inventory.RemoveItem(inventory.items[index]));
        }
        contador += 1;
    }
}
