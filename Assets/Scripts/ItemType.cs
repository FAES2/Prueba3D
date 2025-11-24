using UnityEngine;

[CreateAssetMenu(fileName = "NuevoItem", menuName = "Items/ItemType")]
public class ItemType : ScriptableObject
{
    [Tooltip("ID estilo Minecraft 1.13+ (ej: minecraft:grass_block)")]
    public string id;
    [Tooltip("Icono")]
    public Sprite iconoInventario;
    [Tooltip("Nombre")]
    public string Nombre;
}
