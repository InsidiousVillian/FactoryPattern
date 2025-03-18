using UnityEngine;

public class Fireball : MonoBehaviour, ISpell
{
    [SerializeField]
    private Projectile projectile;
    public int manaCost => 10;

    public float castTime => 1.5f;

    public void Cast()
    {
        projectile.enabled = true;
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //spawn fireball
        gameObject.GetComponent<Projectile>().enabled = false;
        projectile.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
