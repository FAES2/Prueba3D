using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventario
{
    [Tooltip("Cantidad por ID de ítem o bloque")]
    public Dictionary<string, int> cantidades = new();

    // Agrega cantidad al ID especificado
    public void Agregar(string id, int cantidad = 1)
    {
        if (string.IsNullOrEmpty(id)) return;
        if (!cantidades.ContainsKey(id)) cantidades[id] = 0;
        cantidades[id] += cantidad;
    }

    // Intenta consumir cantidad del ID especificado
    public bool Consumir(string id, int cantidad = 1)
    {
        if (!cantidades.ContainsKey(id)) return false;
        if (cantidades[id] < cantidad) return false;

        cantidades[id] -= cantidad;
        return true;
    }

    // Devuelve la cantidad actual del ID especificado
    public int ObtenerCantidad(string id)
    {
        if (!cantidades.ContainsKey(id)) return 0;
        return cantidades[id];
    }

    // Devuelve todos los IDs presentes
    public IEnumerable<string> ObtenerTodosIDs() => cantidades.Keys;
}
