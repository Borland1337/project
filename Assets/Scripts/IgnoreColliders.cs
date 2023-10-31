using UnityEngine;

public class IgnoreColliders : MonoBehaviour
{
    public Collider2D[] Collider2D;
    public Collider2D player;
    void Start()
    {
        foreach (Collider2D item in Collider2D)
        {
            Physics2D.IgnoreCollision(item, player, true);
        }
    }
}