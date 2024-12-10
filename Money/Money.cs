using UnityEngine;

public class Money : MonoBehaviour
{
    public int Nagrad;
    
    private GameObject _player;

    private void Update()
    {
        if (_player)
        {
            Go();
        }
    }

    private void Go()
    {
        if (Vector2.Distance(_player.transform.position,transform.position) > 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, 5 * Time.deltaTime);
        }
        else
        {
            _player.GetComponent<Player>().Money += Nagrad;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            _player = collision.gameObject;
        }
    }
}
