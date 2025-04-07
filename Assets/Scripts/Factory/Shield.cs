using UnityEngine;
public class Shield : MonoBehaviour, ISpell
{
    [SerializeField]
    private GameObject shieldVisual;
    
    public int manaCost => 15;
    public float castTime => 0.2f;
    public float duration = 5.0f;
    
    public void Cast()
    {
        // Show the shield
        shieldVisual.SetActive(true);
        
        // Start the shield duration countdown
        StartCoroutine(DeactivateAfterDuration());
    }
    
    void Start()
    {
        Debug.Log("Shield ready");
        shieldVisual.SetActive(false);
        
        // Position the shield directly on the player when instantiated
        // Find the player and parent to it
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            transform.parent = player.transform;
            transform.localPosition = Vector3.zero; // Center on player
            transform.localRotation = Quaternion.identity;
        }
    }
    
    private System.Collections.IEnumerator DeactivateAfterDuration()
    {
        yield return new WaitForSeconds(duration);
        shieldVisual.SetActive(false);
    }
}