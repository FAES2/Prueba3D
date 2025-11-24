using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventarioUI : MonoBehaviour
{
    public GameObject prefabSlot; // Prefab con Image + Text
    public Transform contenedorSlots; // Donde se instancian los slots
    public ItemType[] itemsDisponibles; // Lista de ítems registrados
    public Inventario inventario; // Referencia lógica

    void Start()
    {
        GenerarUI();
    }

    public void GenerarUI()
    {
        foreach (var item in itemsDisponibles)
        {
            GameObject slot = Instantiate(prefabSlot, contenedorSlots);
            Image icono = slot.transform.Find("Icono").GetComponent<Image>();
            TextMeshProUGUI texto = slot.transform.Find("Cantidad").GetComponent<TextMeshProUGUI>();

            icono.sprite = item.iconoInventario;
            texto.text = inventario.ObtenerCantidad(item.id).ToString();
        }
    }

    public void ActualizarUI()
    {
        for (int i = 0; i < contenedorSlots.childCount; i++)
        {
            Transform slot = contenedorSlots.GetChild(i);
            TextMeshProUGUI texto = slot.Find("Cantidad").GetComponent<TextMeshProUGUI>();

            string id = itemsDisponibles[i].id;
            texto.text = inventario.ObtenerCantidad(id).ToString();
        }
    }
}
