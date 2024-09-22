using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private ParticleSystem _particleSystem;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Wall>() != null)
        {
           Instantiate(_particleSystem, transform.position, Quaternion.identity);
           Destroy(gameObject);
        }
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}