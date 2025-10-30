using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Este método se ejecuta al presionar el botón "Play Game"
    public void PlayGame()
    {
        // Carga la escena del minijuego
        Debug.Log("PlayGame() llamado correctamente");
        UnityEngine.SceneManagement.SceneManager.LoadScene("MiniGame");
    }

    // (Opcional) Método para salir del juego si quieres añadir un botón Exit
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
