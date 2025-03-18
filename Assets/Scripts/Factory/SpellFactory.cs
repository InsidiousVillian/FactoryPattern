using UnityEngine;

public class SpellFactory : MonoBehaviour
{
    //instance
    public static SpellFactory instance;

    public GameObject[] spells;
    private void Awake()
    {
        //singleton code
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }
    public ISpell CreateSpell(Enums.ESpell spellToSpawn)
    {
        var go = Instantiate(spells[(int)spellToSpawn]);
        Debug.Log(go.name + "Help");
        return go.GetComponent<ISpell>();

        //return null;
    }
}
