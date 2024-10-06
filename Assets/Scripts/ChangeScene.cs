using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    // Nombre de la escena a la que quieres cambiar
    public string nombreEscena;

    void Update()
    {
        // Si se presiona la barra espaciadora
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Cambiar a la escena especificada
            SceneManager.LoadScene(nombreEscena);
        }
    }
}
