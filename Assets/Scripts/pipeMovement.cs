using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeMovement : MonoBehaviour
{
    public float speed = 2.4f; // Velocidad de movimiento

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Multiplica la velocidad por Time.deltaTime para un movimiento consistente
        Vector2 targetPosition = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);

        // Interpolar hacia la nueva posición
        transform.position = Vector2.Lerp(transform.position, targetPosition, 0.8f);
    }
}
