using UnityEngine;

public class MovementLoot : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private float _speedFluctuations = 5f;
    private float _amplitude = 5f;

    private Vector3 _defaultPosotion;
    private float _time;

    private void Start()
    {
        _defaultPosotion = transform.position;
    }
    private void Update()
    {
        transform.Rotate(Vector3.up, Time.deltaTime * _rotateSpeed);

        _time += Time.deltaTime * _speedFluctuations;

        transform.position = _defaultPosotion + Vector3.up * Mathf.Sin(_time) / _amplitude;
    }
}