using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    public GameObject ground1;
    public GameObject ground2;
    public float speed = 2.4f;
    private float groundWidth;
    private float groundYPosition;

    void Start()
    {

        groundWidth = ground1.GetComponent<SpriteRenderer>().bounds.size.x;//Ancho del sprite, para calcular cuando sale vista de la camara

        groundYPosition = ground1.transform.position.y;


        ground1.transform.position = new Vector2(0, groundYPosition);
        ground2.transform.position = new Vector2(groundWidth, groundYPosition);
    }

    void Update()
    {
        // Calcula la nueva posición para ambos suelos usando Vector2
        Vector2 targetPosition1 = (Vector2)ground1.transform.position + Vector2.left * speed * Time.deltaTime;
        Vector2 targetPosition2 = (Vector2)ground2.transform.position + Vector2.left * speed * Time.deltaTime;

        //Movimiento Interpolado para que sea smooth
        ground1.transform.position = Vector2.Lerp(ground1.transform.position, targetPosition1, 0.8f);
        ground2.transform.position = Vector2.Lerp(ground2.transform.position, targetPosition2, 0.8f);

        //Si la posicion x de ground1 es menor que -(grosor del suelo) , ground1 ha salido del area visible por la izquierda
        if (ground1.transform.position.x < -groundWidth)
        {
            // Reposicionamos  ground1 , detrás de ground2 + groundWidth para que este al final
            ground1.transform.position = new Vector2(ground2.transform.position.x + groundWidth, groundYPosition);
        }

        //Viceversa
        if (ground2.transform.position.x < -groundWidth)
        {

            ground2.transform.position = new Vector2(ground1.transform.position.x + groundWidth, groundYPosition);
        }
    }
}
