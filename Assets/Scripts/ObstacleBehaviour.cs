using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleBehaviour : MonoBehaviour
{
 [Tooltip("restartdan olding qancha kutish")]
    public float waitTime = 2.0f;

    private void OnCollisionEnter(Collision collision)
    {
        //Сначала проверьте, не столкнулись(collide OR collision) ли мы с игроком
        if (collision.gameObject.GetComponent<ControlBall>())
        {

            //ballni destroy qilamiz

            Destroy(collision.gameObject);


            // Вызов функции ResetGame после
            // время ожидания прошло

            Invoke("resetGame", waitTime);
        }
    }
    public void resetGame(){
        string scene = SceneManager.GetActiveScene().name;

        //shu levelni qaytadan ishga tushiramiz
        SceneManager.LoadScene(scene);
    }
}
