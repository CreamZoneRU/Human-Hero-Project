using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 2f;

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER!");
            Invoke("Restart", restartDelay);
        }
    }

    public void Restart()
    {
        // Can be changed in future to load last checkpoint insted of restarting whole scene
        // https://www.youtube.com/watch?v=XOjd_qU2Ido
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteGame()
    {
        Debug.Log("You Win!");
    }

    

    public static void KillPlayer (Player player)
    {
        Destroy(player.gameObject);
    }

    public static void KillEnemy (Enemy enemy)
    {
        Destroy(enemy.gameObject);
    }
}
