using UnityEngine;

public class TakingBonus : MonoBehaviour
{
    [SerializeField] private Transform _conteinerForItem;
    [SerializeField] private ParticleSystem _particleSystem;

    private GameObject _createdItem;
    private Item _item;
    private PlayerMovement _player;
    private bool _isObjectInHand = false;
    private float _delayToDestroyItem = 1.3f;

    private void Start()
    {
        _player = GetComponent<PlayerMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_isObjectInHand == false)
        {
            _item = other.gameObject.GetComponent<Item>();
            if (_item != null)
            {
                _createdItem = _item.CreateBonus();

                TakeBonusInHand(_createdItem);

                Destroy(_item.gameObject);
            }
        }
    }

    private void TakeBonusInHand(GameObject item)
    {
        item.transform.position = _conteinerForItem.transform.position;
        item.transform.parent = _conteinerForItem;
        _isObjectInHand = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_createdItem != null)
            {
                _item.UseBonus(_player);
                Destroy(_createdItem, _delayToDestroyItem);
                _particleSystem.Play();
                _isObjectInHand = false;
            }
            else
            {
                Debug.Log("У вас нет предметов");
            }
        }
    }
}