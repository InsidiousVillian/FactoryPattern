using UnityEngine;
using System.Collections;

public class Wizard : MonoBehaviour
{
    private float _timer;
    public float spellTime = 1.5f;
    public bool casting = false;
    [SerializeField]
    private Transform spellLocation;
    private ISpell currentSpell;
    
    // Add a cooldown between spell casts to prevent massive amount of errors
    private float castCooldown = 0.5f;
    private bool onCooldown = false;
    
    private void Update()
    {
        if (onCooldown)
            return;
            
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
                if (currentSpell != null) // Check if currentSpell is not null
                {
                    currentSpell.Cast();
                }
                else
                {
                    Debug.LogError("Tried to cast a null spell!");
                }
                
                casting = false;
                
                // Added a small cooldown to prevent immediate recast
                StartCoroutine(SpellCooldown());
            }
        }
    }
    
    private IEnumerator SpellCooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(castCooldown);
        onCooldown = false;
    }
    
    void StartSpell()
    {
        Debug.Log("Attempting to cast spell");
        
        // Loop through multiple attempts if needed to find a valid spell
        for (int attempt = 0; attempt < 5; attempt++)
        {
            // Pick a random spell excluding None
            int i = Random.Range(0, (int)Enums.ESpell.None);
            Enums.ESpell randomSpell = (Enums.ESpell)i;
            
            Debug.Log("Attempting to create spell: " + randomSpell.ToString());
            
            // Create the spell and check if it's valid
            ISpell spell = SpellFactory.instance.CreateSpell(randomSpell);
            
            if (spell != null)
            {
                Debug.Log("Successfully created spell: " + randomSpell.ToString());
                
                // Set the current spell
                currentSpell = spell;
                
                // Get the MonoBehaviour component
                MonoBehaviour spellBehaviour = currentSpell as MonoBehaviour;
                
                if (spellBehaviour != null && spellBehaviour.gameObject != null)
                {
                    // Set position and rotation
                    spellBehaviour.gameObject.transform.position = spellLocation.position;
                    spellBehaviour.gameObject.transform.rotation = spellLocation.rotation;
                    
                    // Set timer
                    _timer = currentSpell.castTime;
                    return; // Successfully created a spell, exit the method
                }
                else
                {
                    Debug.LogError("Spell is not a valid MonoBehaviour: " + randomSpell.ToString());
                }
            }
            else
            {
                Debug.LogError("Failed to create spell: " + randomSpell.ToString());
            }
        }
        
        // If we got here, we couldn't create a valid spell after multiple attempts
        Debug.LogError("Failed to create any valid spell after multiple attempts");
        casting = false; // Reset casting state
    }
}