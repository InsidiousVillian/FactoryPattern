using UnityEngine;

public class Wizard : MonoBehaviour
{
    //wizard has a spelltimer
    private float _timer;
    public float spellTime = 1.5f;

    //if he is casting
    public bool casting = false;

    [SerializeField]
    private Transform spellLocation;

    ISpell currentSpell;
    //current spell
    

    private void Update()
    {
        if (!casting) //if not casting anything, cast something
        {
            casting = true;
            StartSpell();
        }
        else //casting
        {
            _timer -= Time.deltaTime;
            if(_timer <= 0)
            {
                //cast current spell
                currentSpell.Cast();
                casting = false;
            }
        }

    }
    void StartSpell()
    {
        Debug.Log("Cast Spell");
        //pick a spell to spawn


        //this is the spell i want to cast
        int i = Random.Range(0, (int)Enums.ESpell.Shield);
        Enums.ESpell randomSpell = (Enums.ESpell)i;

        ISpell spell = SpellFactory.instance.CreateSpell(randomSpell);

        Debug.Log(spell);
        currentSpell = spell;
        //spawn spell with our new factory class



        //set location/rotation
        ((MonoBehaviour)spell).gameObject.transform.position = spellLocation.position;
        ((MonoBehaviour)spell).gameObject.transform.rotation = spellLocation.rotation;


        //dynamic access to spell
        _timer = currentSpell.castTime;


    }
}
