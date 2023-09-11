using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleBehaviour : MonoBehaviour
{
 [Tooltip("restartdan olding qancha kutish")]
    public float waitTime = 2.0f;

    private void OnCollisionEnter(Collision collision)
    {
        //Avvalo, biz o'yinchi bilan to'qnashganimizni yoki to'qnashganimizni tekshiring
        if (collision.gameObject.GetComponent<ControlBall>())
        {

            //ballni destroy qilamiz

            Destroy(collision.gameObject);


        // ResetGame funksiyasini keyin chaqiring
             // kutish vaqti o'tdi

            Invoke("resetGame", waitTime);
        }
    }
    public void resetGame(){
        string scene = SceneManager.GetActiveScene().name;

        //shu levelni qaytadan ishga tushiramiz
        SceneManager.LoadScene(scene);
    }
}
