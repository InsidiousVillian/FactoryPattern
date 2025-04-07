using UnityEngine;

public class Pulse : MonoBehaviour, ISpell
{
   
    [SerializeField]
    private Projectile projectile;

    public int manaCost => 29;
    public float castTime => 0.1f;

    public void Cast()
    {
        projectile.enabled = true;
    }

    void Start()
    {
        Debug.Log("casted Pulse");
        projectile.enabled = false;
    }
}
