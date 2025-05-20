using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    GameController _gameController;
    Rigidbody2D _rigidbody2d;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _gameController = Camera.main.GetComponent<GameController>();
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        _spriteRenderer.color = _gameController._corHit;
        _rigidbody2d.linearVelocity = new Vector3(_rigidbody2d.linearVelocity.x, 0f, 0f);

        _rigidbody2d.AddForce(new Vector2(0, 20), ForceMode2D.Impulse);
        Invoke("CorIni", 1);
    }

    void CorIni()
    {
        _spriteRenderer.color = _gameController._corDef;
    }
}


