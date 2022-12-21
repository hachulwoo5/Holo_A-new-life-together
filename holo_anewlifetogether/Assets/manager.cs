using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System. Runtime. InteropServices;
using UnityEngine. SceneManagement;

public class manager : MonoBehaviour
{
    //public GameObject ment;
    public GameObject drawing;
    // public GameObject moonshin;
    // public GameObject table;
    //public GameObject chair;
    public Animator animator;

    private float fDestroyTime = 9f;
    private float fTickTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fTickTime += Time. deltaTime;
        if ( fTickTime >= fDestroyTime )
        {
           // ment. SetActive ( true );
        }

        if( fTickTime >= 19.5f )
        {
            //drawing. SetActive ( true );   // 그림
           // ment. SetActive ( false );
          //  moonshin. SetActive ( false );
           //  table. SetActive ( true ); // 연필
          //  chair. SetActive ( false );
        }
       /* if ( fTickTime >= 25 )
        {
            SceneManager. LoadScene ( "ending" );
        }*/
        
      
    }


    public void OnAnimation()
    {
        animator.SetTrigger("ani2");
    }

    public void OffAnimation()
    {
        animator.SetTrigger("ani3");
    }
}
