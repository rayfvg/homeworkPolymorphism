using UnityEngine;

public class SpeedUpItem : Item
{
    private const string SpeedUpAnimation = "Speed";

    [SerializeField] private GameObject _speedUpItemPrefab;

    public override GameObject CreateBonus()
    {
        GameObject createItem = Instantiate(_speedUpItemPrefab);
        return createItem;
    }

    public override void UseBonus(PlayerMovement player)
    {
        Debug.Log("Я увеличил скорость");
        player.SpeedUp();
        Animator animator = player.GetComponent<Animator>();
        animator.SetTrigger(SpeedUpAnimation);
    }
}