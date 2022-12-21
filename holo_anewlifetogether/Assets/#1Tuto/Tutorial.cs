using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public TextMeshPro text1;
    public int Feeds = 0;
    public int Chat = 0;
    public int ButtonClicks = 0;

    public GameObject Menu;
    public GameObject[] gameobjectlist;
    public GameObject Image1;
    public GameObject Cube;
    
    public GameObject Image5;
    public GameObject Button;

    public bool isFeedOk;

    MeshRenderer meshRenderer;
    void Start()
    {
        isFeedOk = false;
        meshRenderer = GetComponent<MeshRenderer>();
        StartCoroutine(Story());
    }

    // Update is called once per frame
    void Update()
    {
       
        if(Feeds ==3 )
        {
           
            Feeds = 0;
            isFeedOk = true;
            text1.text = "검지와 엄지손가락을 이용해\n강아지의 먹이를 준비해봅니다 ! \n" + "3 / 3 ";
            StartCoroutine(ButtonClick());
           
        }

        if (ButtonClicks == 5)
        {
            ButtonClicks = 0;
            text1.text = "잠시 후 강아지를 맞이해주세요 !";
            Button.gameObject.SetActive(false);
            
            StartCoroutine(NextScene());

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Bob" && isFeedOk==false)
        {
            Feeds++;
            text1.text = "검지와 엄지손가락을 이용해\n강아지의 먹이를 준비해봅니다 ! \n" + Feeds + " / 3 ";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Bob" && isFeedOk == false)
        {
            Feeds--;
            text1.text = "검지와 엄지손가락을 이용해\n강아지의 먹이를 준비해봅니다 ! \n" + Feeds + " / 3 ";
        }
    }
    

    IEnumerator ButtonClick()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < gameobjectlist.Length; i++)
        {
            gameobjectlist[i].SetActive(false);
        }
        this.meshRenderer.enabled = false;


        text1.text = "다음은 버튼 클릭 테스트를 진행하겠습니다 ";
        yield return new WaitForSeconds(3f);

        text1.text = "아래와 같이 검지를 이용해 버튼 앞에서 살짝 눌러주세요\n 또는 물체를 잡을 때와 같이 엄지와 검지 클릭으로도 버튼을 누를 수 있습니다 ";
        Image5.gameObject.SetActive(true);
        yield return new WaitForSeconds(13f);
        Image5.gameObject.SetActive(false);

        text1.text = "5번을 클릭을 하게 되면 튜토리얼이 끝나게 됩니다 ";
        Button.gameObject.SetActive(true);



    }

    IEnumerator Story()
    {
        yield return new WaitForSeconds(2f);
        Menu.gameObject.SetActive(true);

        text1.text = "강아지와 상호작용 하기 전, \n오브젝트를 컨트롤 할 수 있도록 간단한 튜토리얼을 진행합니다";
        yield return new WaitForSeconds(7f);
        Cube.gameObject.SetActive(true);

        text1.text = "손바닥을 내어 펼쳐보세요 점선의 레이저 포인터가 활성화됩니다";
        Image1.gameObject.SetActive(true);
        yield return new WaitForSeconds(7.5f);
        

        text1.text = "레이저 포인터를 큐브에 갖다대면 작은 점이 생기게 됩니다";
        yield return new WaitForSeconds(7.5f);

        text1.text = "원하는 오브젝트에 점이 생기게 된다면 검지와 엄지를 살포시 맞대주세요";
        yield return new WaitForSeconds(7.5f);

        text1.text = "실선이 생기게 된다면 그 상태에서 손을 움직여 오브젝트를 움직일 수 있습니다 !";
        yield return new WaitForSeconds(7.5f);
        Image1.gameObject.SetActive(false);

        text1.text = "검지와 엄지손가락을 이용해\n강아지의 먹이를 준비해봅니다 !";
        this.meshRenderer.enabled = true;
        Cube.gameObject.SetActive(false);
        for (int i = 0; i < gameobjectlist.Length; i++)
        {
            gameobjectlist[i].SetActive(true);
        }
        yield return new WaitForSeconds(3.5f);
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("greet");
    }

        public void PressButton()
    {
        if(ButtonClicks<=4)
        {
            ButtonClicks++;
            text1.text = "5번을 클릭을 하게 되면 튜토리얼이 끝나게 됩니다" + "\n" + ButtonClicks + " / 5";

        }

    }
}
