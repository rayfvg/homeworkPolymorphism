using UnityEngine;

public class HealthUpItem : Item
{
    private const string HealthUpAnimation = "Hp";

    [SerializeField] private GameObject _healthUpItemPrefab;

    public override GameObject CreateBonus()
    {
        GameObject createItem = Instantiate(_healthUpItemPrefab);
        return createItem;
    }

    public override void UseBonus(PlayerMovement player)
    {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        Animator animator = playerHealth.GetComponent<Animator>();
        animator.SetTrigger(HealthUpAnimation);

        Debug.Log("�� �� �� ��������� ������");
        playerHealth.ShowHealth();
        playerHealth.AddHealth();
        Debug.Log("�� �� ����� ��������� ������");
        playerHealth.ShowHealth();
    }
}