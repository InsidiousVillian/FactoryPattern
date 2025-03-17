using UnityEngine;

public class ModifiedProperty : MonoBehaviour
{
    //Health property
    private int health;
    private int maxHealth;

    public int Health
    {
        get { return health; }
        set {
            //we can do simple logic to make properties simpler to use
            //for example when setting health we can make sure its not below or
            //above a certain amount
            if (value < 0) {
                health = value; 
            }
            else if (value > maxHealth)
            {
                health = maxHealth;
            }
            else
            {
                health = value;
            }

        }
    }
    public int HealthLost
    {
        get { return maxHealth - health;}
    }
}
