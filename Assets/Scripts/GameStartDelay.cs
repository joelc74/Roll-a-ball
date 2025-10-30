using UnityEngine;
using System.Collections;
public class GameStartDelay : MonoBehaviour
{
    public float delayTime = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartGameAfterDelay());
    }

   IEnumerator StartGameAfterDelay()
    {
        // Pausa el tiempo (los enemigos no se mueven)
        Time.timeScale = 0f;

        // Espera unos segundos en tiempo real
        yield return new WaitForSecondsRealtime(delayTime);

        // Reanuda el juego
        Time.timeScale = 1f;
        Debug.Log("¡Comienza el juego!");
    }
}
