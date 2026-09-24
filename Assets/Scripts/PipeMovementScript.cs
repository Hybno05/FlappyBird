using UnityEngine;

public class PipeMovementScript : MonoBehaviour
{
    
    public float pipeSpeed = 2;

    public float deadZone = -15;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x - pipeSpeed * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
        if (transform.position.x <= deadZone)
        {
            Destroy(gameObject);
        }
        
        
    }
}
