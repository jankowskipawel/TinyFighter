using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float speed;

    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        if (x > 0)
        {
            MoveLeft();
        }
        
        if (x < 0)
        {
            MoveRight();
        }
        
        if (y > 0)
        {
            MoveUp();
        }
        
        if (y < 0)
        {
            MoveDown();
        }

        target = transform.GetComponent<Camera>()
            .ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
    }

    void MoveLeft()
    {
        transform.Translate(speed*Time.deltaTime, 0, 0);
    }
    
    void MoveRight()
    {
        transform.Translate(-speed*Time.deltaTime, 0, 0);
    }
    
    void MoveUp()
    {
        transform.Translate(0, speed*Time.deltaTime, 0);
    }
    
    void MoveDown()
    {
        transform.Translate(0, -speed*Time.deltaTime, 0);
    }
}
