using UnityEngine;

public class Wizard : MonoBehaviour
{
    //wizard has a spelltimer
    private float _timer;
    public float spellTime = 1.5f;
    public bool casting;
    [SerializeField]
    private Transform spellLocation;

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
                casting = false;
            }
        }

    }
    void StartSpell()
    {
        Debug.Log("Cast Spell");
        //pick a spell to spawn
        //spawn spell with our new factory class


        //set location/rotation


        //dynamic access to spell



    }
}
