using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += transform.forward * speed * Time.deltaTime;
    }



}
