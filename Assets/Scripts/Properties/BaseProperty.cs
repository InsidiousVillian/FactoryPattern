using UnityEngine;

public class BaseProperty : MonoBehaviour
{

    //this is an automatic get/setter
    public float AutoGetNumber { get; set; }


    //some modifications
    //write only number
    public float WriteOnlyNumber { private get; set; }
    public float ReadOnlyNumber { get; private set; }


    //this is a manual get/setter, this is just how the base structure looks like
    //we have our private variable (lowercase)
    [SerializeField]
    private float numberValue;

    //and we create a public property (Start with caps)
    public float NumberValue
    {
        get { return numberValue; }
        //by default get means the value is readable, if we want the value to
        // also be writable we add a setter.
        set { numberValue = value; }
    }




}
