using UnityEngine;

public class OneShotItem : Item
{
    private const string ShotAmation = "Shot";

    [SerializeField] private GameObject _oneShotItemPrefab;
    [SerializeField] private Bullet _bulletPrefab;

    private Vector3 offset = new Vector3(0, 1, 0);
    public override GameObject CreateBonus()
    {
        GameObject createItem = Instantiate(_oneShotItemPrefab);
        return createItem;
    }

    public override void UseBonus(PlayerMovement player)
    {
        Animator animator = player.GetComponent<Animator>();
        animator.SetTrigger("Shot");
        Instantiate(_bulletPrefab, player.transform.position + offset, player.transform.rotation);
        Debug.Log("Я произвел выстрел");
    }
}