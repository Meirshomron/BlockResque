using UnityEngine;
using System.Collections;

public class bonus : MonoBehaviour
{

    GameObject other;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        InvokeRepeating("Respawn", 10.0f, 10.0f);
    }
    private void OnCollisionStay(Collision other)
    {
        if ((other.gameObject.tag.Equals("Player")) || other.gameObject.tag.Equals("Enemy"))
            Respawn();
    }
    private void OnTriggerEnter(Collider other)
    {

        if ((other.gameObject.tag.Equals("Player")) || other.gameObject.tag.Equals("Enemy"))
            Respawn();      
    }
    void Respawn()
    {
        Vector3 position = new Vector3(Random.Range(-8.0f, 8.0f), 10, Random.Range(-8.0f, 8.0f));
        Instantiate(gameObject, position, Quaternion.identity);
            Destroy(gameObject);
    }
}
        
