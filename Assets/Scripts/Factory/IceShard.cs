using UnityEngine;

public class IceShard : MonoBehaviour, ISpell
{
    public int manaCost => 29;

    public float castTime => 0.1f;

    public void Cast()
    {
        GetComponent<Projectile>().enabled = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Projectile>().enabled = false ;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
