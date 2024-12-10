using UnityEngine;

public class JumpEffect : Effect 
{
    [SerializeField] private float _time;
    [SerializeField] private float _speed;
    public override void Efect(GameObject player)
    {
        player.GetComponent<Player>().Jerk(1, 1, _speed);
        player.GetComponent<Player>().TimeInJerk = _time;
    }
}
