using UnityEngine;
using UnityEngine.InputSystem;

public class MoveControl : MonoBehaviour
{
    [Header("física")]
    [SerializeField] Rigidbody2D _rb;   // física

    #region movimentação
    [Header("movimento")]
    [SerializeField] Vector2 _move;
    [SerializeField] float _speed;  //movimentação
    #endregion

    [Header("checar chão")]
    [SerializeField] bool _checkGround;  //checar o chão



    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        _rb.linearVelocity = new Vector2(_move.x * _speed, _rb.linearVelocity.y); // velocidade horizontal
    }


    #region novo sistema de input
    public void SetMove(InputAction.CallbackContext value)
    {
        _move = value.ReadValue<Vector2>(); // novo sistema de input
    }
    #endregion


    #region checagem
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            _checkGround = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            _checkGround = false;
        }
    }
    #endregion
}

