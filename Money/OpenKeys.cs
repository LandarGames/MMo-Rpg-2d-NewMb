using UnityEngine;

public class OpenKeys : MonoBehaviour
{
    [SerializeField] private Sprite _openKeys;
    [SerializeField] private int minCol;
    [SerializeField] private int maxCol;
    [SerializeField] private int minNag;
    [SerializeField] private int maxNag;
    private int nagrad => Random.Range(minNag, maxNag); 
    private int Col => Random.Range(minCol,maxCol);
    private bool _open = false;

    [SerializeField] private GameObject _money;

    private void Update()
    {
        if (_open == true)
        {
            KeysDestroy();
        }
    }

    private void KeysDestroy()
    {
        GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 1 * Time.deltaTime);
    }
    public void Open()
    {
        for (int i = 0; i < Col; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-2, 2), Random.Range(-2, 2),0);
            _money.GetComponent<Money>().Nagrad = nagrad;
            Instantiate(_money, transform.position + pos, Quaternion.identity);
            _open = true;
        }
        Destroy(gameObject, 3);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_open == true)
            return;

        if (collision.gameObject.GetComponent<Player>())
        {
            GetComponent<SpriteRenderer>().sprite = _openKeys;
            Open();
        }
    }
}
