using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// O'yinchi oxiriga yetganda yangi plitka yaratilishini va uni yo'q qilishni nazorat qiladi.
/// </summary>
public class TileEndBehaviour : MonoBehaviour
{
    [Tooltip("Oxirigacha etib borganidan keyin plitkani yoq qilishdan oldin qancha kutish kerak")]
    public float destroyTime = 1.5f;

    private void onTriggerEnter(Collider collider){
        //1-tekshirib olishim garak ball oxirina bordimi
        if(collider.gameObject.GetComponent<ControlBall>()){
            
            //agarda ha bo'lsa yangi plitka yaratamiz
            var gm = GameObject.FindObjectOfType<GameManager>();
            gm.spawnNextTile();
            
            //va ma'lum sekundan song plitkani o'chiramiz.
            Destroy(transform.parent.gameObject,destroyTime); 
        }

    }




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
