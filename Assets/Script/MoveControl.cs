using UnityEngine;
using UnityEngine.InputSystem;

public class MoveControl : MonoBehaviour
{
    [Header("f�sica")]
    [SerializeField] Rigidbody2D _rb;   // f�sica

    #region movimenta��o
    [Header("movimento")]
    [SerializeField] Vector2 _move;
    [SerializeField] float _speed;  //movimenta��o
    #endregion

    [Header("checar ch�o")]
    [SerializeField] bool _checkGround;  //checar o ch�o



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
        _move = value.ReadValue<Vector2>(); // novo sistema de input (movimenta��o)
    }
    #endregion

    void Jump()
    {
        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, 0);
        _rb.AddForce(new Vector2(0, 500));
    }


    #region checagem
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground"))
        {
            Jump();
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

