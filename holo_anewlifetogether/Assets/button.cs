using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangeFirstScene()
    {
        SceneManager. LoadScene ( "start" );
    }

    public void ChangeSecondScene ( )
    {
        //SceneManager. LoadScene ( "SampleScene" );
        //SceneManager.LoadScene("outsidesitting");
       //SceneManager.LoadScene("windowstanding");
        SceneManager.LoadScene("greet");
    }
}
