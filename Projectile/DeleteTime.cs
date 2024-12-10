using UnityEngine;

public class DeleteTime : MonoBehaviour
{
    [SerializeField] private float _timeng;

    private float _time;

    public void Update()
    {
        _time += Time.deltaTime;
        if (_time >= _timeng)
        {
            Destroy(gameObject);
        }
    }
}
