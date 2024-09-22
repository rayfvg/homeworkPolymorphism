using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int _health = 10;

    public void AddHealth() => _health += 5;

    public void ShowHealth() => Debug.Log(_health);
}