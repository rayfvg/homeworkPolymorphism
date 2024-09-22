using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";

    private const string ItsWalking = "itsWalking";
    private const string DancingAnimation = "Dance";

    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private Animator _animator;
    private CharacterController _characterController;
    private float _deadZone = 0.1f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            _animator.SetTrigger(DancingAnimation);

        float inputX = Input.GetAxisRaw(HorizontalAxisName);
        float inputY = Input.GetAxisRaw(VerticalAxisName);

        Vector3 inputXY = new Vector3(inputX, 0, inputY);

        if(inputXY.magnitude <= _deadZone)
        {
            _animator.SetBool(ItsWalking, false);
            return;
        }
        else
        {
            _animator.SetBool(ItsWalking, true);
        }

        _characterController.Move(inputXY.normalized * Time.deltaTime * _speed);

        Quaternion lookRotation = Quaternion.LookRotation(inputXY.normalized);
        float step = _rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
    }

    public void SpeedUp() => _speed *= 2;
}