using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public abstract void UseBonus(PlayerMovement player);

    public abstract GameObject CreateBonus();
}