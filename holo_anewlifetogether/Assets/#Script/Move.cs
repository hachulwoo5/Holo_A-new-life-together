using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{

    public int movespeed =10;
    public int Story5count = 0;
    public float Timer;
    private float time_start;
    private float time_current;
    private float time_Max = 120f;
    private bool isEnded;
    public UnityEngine.UI.Text text_Timer;
    Animator ani;
    Rigidbody rigid;
    public int JumpPower;
    
    public bool isAte;
    public GameObject dogbowl;
    public GameObject Feed;
    public GameObject yam;
    public GameObject carrot;
    public GameObject cake;
    public GameObject grape;
    public GameObject onion;
    public GameObject kiwi;
    public GameObject bowl1;
    public GameObject bowl2;
    public GameObject SitButton;
    public GameObject DeathButton;
    public GameObject WaterButton;
    public GameObject SleepButton;
    public GameObject Water;
    public GameObject Chair;
    public GameObject[] gameobjectlist;
   
    public TextMeshPro text1;
    Renderer renderer;
    Renderer renderer2;
   

    public bool isZz = true; //파티클 제어 bool
    public ParticleSystem particleObject1; //파티클시스템
    public ParticleSystem particleObject2; //파티클시스템
    public bool isAnimating;

    public int BugCount =0;
    void Start()
    {
        Reset_Timer();
        ani = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
        renderer = dogbowl.GetComponent<Renderer>();
        renderer2 = Water.GetComponent<Renderer>();
        isAnimating = true;

        StartCoroutine(Story1());
    }


    // Update is called once per frame
    void Update()
    {
        if (isEnded)
            return;
        Check_Timer();
        Timer +=  Time.deltaTime;
        if (Timer >= 0 && Timer < 1.2f)
        {
            transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
        }
        if (Timer >= 1.2f && Timer < 5f)
        {
            ani.SetBool("1@Move", true);
            transform.Translate(Vector3.forward * movespeed * 1.5f * Time.deltaTime);
        }
        if (Timer>=5f && Timer<7.3f)
        {
            ani.SetBool("2@Jump", true);
            transform.Translate(Vector3.forward * movespeed * 1.2f * Time.deltaTime);
        }
        if (Timer >= 7.3f )
        {
            ani.SetBool("3@Idle", true);
            
        }
        if (Timer >= 8f)
        {
            ani.SetBool("4@Idle", true);
        }
        if(Timer >=12f && Timer<=12.2f)
        {
            Chair.gameObject.SetActive(false);
            ani.SetBool("6@Idle", true);
            GameObject.Find("BaseSound").GetComponent<AudioSource>().Play();
            // Feed.SetActive(true);
            // Duck.SetActive(true);
           // Menu.SetActive(true);
          //  for(int i=0; i<gameobjectlist.Length;i++)
          //  {
          //      gameobjectlist[i].SetActive(true);
           // }
            isAnimating = false;
        }

        
       
      
    }

    private void FixedUpdate()
    {
        if (Story5count == 6)
        {
            Story5count = 0;
            StartCoroutine(Story6());
        }
    }
    private void Check_Timer()
    {
        time_current = Time.time - time_start;
        if (time_current < time_Max)
        {
            text_Timer.text = $"{time_current:N2}";
        }
        else if (!isEnded)
        {
            End_Timer();
        }
    }

    private void End_Timer()
    {
        time_current = time_Max;
        text_Timer.text = $"{time_current:N2}";
        isEnded = true;
    }

    private void Reset_Timer()
    {
        time_start = Time.time;
        time_current = 0;
        text_Timer.text = $"{time_current:N2}";
        isEnded = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Feed"&& isAnimating == false)
        {
            text1.text = "";
            ani.SetBool("7@Eat", true);
            Destroy(other.gameObject);
            
            
            StartCoroutine(Story3());
        }

        if (other.gameObject.name == "kiwi" && isAnimating == false)
        {
            ani.SetBool("7@Eat", true);
            Destroy(other.gameObject);
            Story5count++;
            StartCoroutine(aEatK());
        }

        if (other.gameObject.name == "carrot" && isAnimating == false)
        {
            ani.SetBool("7@Eat", true);
            Destroy(other.gameObject);
            Story5count++;
            StartCoroutine(aEatC());
        }
        if (other.gameObject.name == "yam" && isAnimating == false)
        {
            ani.SetBool("7@Eat", true);
            Destroy(other.gameObject);
            Story5count++;
            StartCoroutine(aEatY());
        }
        if (other.gameObject.name=="grape" && isAnimating == false)
        {
            ani.SetBool("Attack", true);
            Destroy(other.gameObject);
            Story5count++;
            StartCoroutine(aAttackG());
        }
        if (other.gameObject.name == "onion" && isAnimating == false)
        {
            ani.SetBool("Attack", true);
            Destroy(other.gameObject);
            Story5count++;
            StartCoroutine(aAttackO());
        }
        if (other.gameObject.name == "cake" && isAnimating == false)
        {
            ani.SetBool("Attack", true);
            Destroy(other.gameObject);
            Story5count++;
            StartCoroutine(aAttackC());
        }


        if (other.gameObject.CompareTag("Hand") && isAnimating == false && BugCount==0)
        {
            BugCount++;
            ani.SetBool("Touch", true);
            StartCoroutine(Story2());


        }
    }

    public void Touch()
    {
        if (isAnimating == false)
        {
            ani.SetBool("Touch", true);
            StartCoroutine(Story2());
        }
    }

    public void Drink()
    {
        if (isAnimating == false)
        {
            ani.SetBool("Drink", true);
            dogbowl.SetActive(true);
            StartCoroutine(Story7());           
        }
    }

    public void Sit()
    {
        if (isAnimating == false)
        {
            
            StartCoroutine(Story4());
        }
    }

    public void Sleep()
    {
        if (isAnimating == false)
        {
            
            StartCoroutine(Story8());
        }
    }

    public void Death()
    {
        if (isAnimating == false)
        {
            ani.SetBool("8@Death", true);
            StartCoroutine(Story5());
        }
    }

    IEnumerator aEatC()
    {
        isAnimating = true;
        text1.text = "강아지의 코 건강과 시력,\n털 관리에 좋은 당근입니다 !";
        GameObject.Find("BaseSound").GetComponent<AudioSource>().Stop();
        GameObject.Find("SoundBox4").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(4f);
        text1.text = "";
        GameObject.Find("SoundBox4").GetComponent<AudioSource>().Stop();
        GameObject.Find("BaseSound").GetComponent<AudioSource>().Play();

        ani.SetBool("7@Eat", false);
        isAnimating = false;
    }
    IEnumerator aEatY()
    {
        isAnimating = true;
        text1.text = "식이섬유와 비타민이 풍부하고 \n 노화방지와 피로 해소에 좋은 고구마입니다 !";
        GameObject.Find("BaseSound").GetComponent<AudioSource>().Stop();
        GameObject.Find("SoundBox4").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(4f);
        text1.text = "";
        GameObject.Find("SoundBox4").GetComponent<AudioSource>().Stop();
        GameObject.Find("BaseSound").GetComponent<AudioSource>().Play();

        ani.SetBool("7@Eat", false);
        isAnimating = false;
    }

    IEnumerator aEatK()
    {
        isAnimating = true;
        text1.text = "비타민C와 칼륨이 풍부해\n 면역력 증가와 변비 개선에 좋은 키위입니다 !";
        GameObject.Find("BaseSound").GetComponent<AudioSource>().Stop();
        GameObject.Find("SoundBox4").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(4f);
        text1.text = "";
        GameObject.Find("SoundBox4").GetComponent<AudioSource>().Stop();
        GameObject.Find("BaseSound").GetComponent<AudioSource>().Play();

        ani.SetBool("7@Eat", false);
        isAnimating = false;
    }
    IEnumerator aAttackC()
    {
        isAnimating = true;
        text1.text = "강아지에게 초콜릿이 들어간 음식은 매우 위험합니다 !";
        GameObject.Find("BaseSound").GetComponent<AudioSource>().Stop();
        GameObject.Find("SoundBox3").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);
        
        GameObject.Find("SoundBox3").GetComponent<AudioSource>().Stop();
        GameObject.Find("BaseSound").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);
        text1.text = "";
        ani.SetBool("Attack", false);
        isAnimating = false;
    }
    IEnumerator aAttackO()
    {
        isAnimating = true;
        text1.text = "양파의 독성은 강아지에게 위협적입니다 !";
        GameObject.Find("BaseSound").GetComponent<AudioSource>().Stop();
        GameObject.Find("SoundBox3").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);

        GameObject.Find("SoundBox3").GetComponent<AudioSource>().Stop();
        GameObject.Find("BaseSound").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);
        text1.text = "";
        ani.SetBool("Attack", false);
        isAnimating = false;
    }
    IEnumerator aAttackG()
    {
        isAnimating = true;
        text1.text = "포도는 강아지의 심각한 신장 손상을 초래합니다 !";
        GameObject.Find("BaseSound").GetComponent<AudioSource>().Stop();
        GameObject.Find("SoundBox3").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);

        GameObject.Find("SoundBox3").GetComponent<AudioSource>().Stop();
        GameObject.Find("BaseSound").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2f);
        text1.text = "";
        ani.SetBool("Attack", false);
        isAnimating = false;
    }


    IEnumerator Story1()
    {
        yield return new WaitForSeconds(1f);
        text1.text = "조금 전 입양한 귀여운 강아지가 달려오고 있습니다 ! ";
        yield return new WaitForSeconds(5f);
        text1.text = "강아지와 상호작용을 시작해보세요 ";
        yield return new WaitForSeconds(6f);
        text1.text = "먼저 강아지의 이마에 손을 갖다대보고, \n 어떤 반응을 보이는지 확인해주세요";
        // 이마갖다대면 애니메이션 on  isAni1 =1;


    }

    // 터치 ~ 고기 on
    IEnumerator Story2()
    {
        isAnimating = true;
        text1.text = "";
        yield return new WaitForSeconds(3.5f);
        ani.SetBool("Touch", false);
        
        isAnimating = false;
        text1.text = "입양된지 얼마되지 않은 유기견이라, \n 아직은 낯설어 하고 있습니다 ";
       
       
        yield return new WaitForSeconds(4f);
        text1.text = "강아지가 좋아할만한 고기를 \n 강아지의 입에 가져다 주어 친밀도를 높여보세요 !\n (손에서 나오는 레이저를 물체에 갖다대 점을 만들어주세요)";
        Feed.gameObject.SetActive(true);
       
        
    }

    // 고기먹기 ~ 앉기버튼
    IEnumerator Story3()
    {
        isAnimating = true;
        GameObject.Find("BaseSound").GetComponent<AudioSource>().Stop();
        GameObject.Find("SoundBox4").GetComponent<AudioSource>().Play(); //4초간 재생해야함
        yield return new WaitForSeconds(1f);
        particleObject2.Play();
        text1.text = "강아지가 좋아합니다 !";



        yield return new WaitForSeconds(2f);
        
        particleObject2.Stop();
        yield return new WaitForSeconds(1f);
        
        //애니메이션 끝
        
        GameObject.Find("SoundBox4").GetComponent<AudioSource>().Stop();
        GameObject.Find("BaseSound").GetComponent<AudioSource>().Play();
        

        ani.SetBool("7@Eat", false);
        isAnimating = false;        // 애니메이션 마무리

        yield return new WaitForSeconds(2.5f);
        text1.text = "먹이를 주었으니 앉으라고 명령 해보세요 !\n (버튼에 가까이 가서 직접 누르거나 레이저로 점을 만들어보세요)";
        SitButton.gameObject.SetActive(true); //앉기 버튼 생성
    }

    // 앉기 ~ 빵야
    IEnumerator Story4()
    {
        isAnimating = true;

        SitButton.gameObject.SetActive(false);
        text1.text = "  " +"앉아 !"+ "  ";
        yield return new WaitForSeconds(1f);
        ani.SetBool("Sit", true);

        yield return new WaitForSeconds(4.5f);
        ani.SetBool("Sit", false);
        isAnimating = false;

        text1.text = "빵야를 통해 강아지의 재주도 길러주세요 !";
        DeathButton.gameObject.SetActive(true);
    }

    IEnumerator Story5()
    {
        isAnimating = true;
        DeathButton.gameObject.SetActive(false);
        GameObject.Find("BaseSound").GetComponent<AudioSource>().Stop();
        text1.text = "  " + "빵야 !" + "  ";
        yield return new WaitForSeconds(3.5f);
      

        ani.SetBool("8@Death", false);
        isAnimating = false;
        yield return new WaitForSeconds(1f);
        GameObject.Find("BaseSound").GetComponent<AudioSource>().Play();

        text1.text = "다음은 간식으로 줄만할 \n여러가지 음식들을 확인해보세요 ! ";
        grape.gameObject.SetActive(true);
        kiwi.gameObject.SetActive(true);
        cake.gameObject.SetActive(true);
        onion.gameObject.SetActive(true);
        yam.gameObject.SetActive(true);
        carrot.gameObject.SetActive(true);
        bowl1.gameObject.SetActive(true);
        bowl2.gameObject.SetActive(true);

    }
    //음식~ 물먹기 버튼
    IEnumerator Story6()
    {
        yield return new WaitForSeconds(4f);
        bowl1.gameObject.SetActive(false);
        bowl2.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        text1.text = "간식을 먹고 목이 마른 강아지입니다. \n강아지가 물을 먹도록 해주세요 !";
        WaterButton.gameObject.SetActive(true);
        
        
       
    }
    //음식~ 물먹기
    IEnumerator Story7()
    {
        WaterButton.gameObject.SetActive(false);
        text1.text = "";
        // 버튼 사라지고 물마심
        GameObject.Find("BaseSound").GetComponent<AudioSource>().Stop();
        GameObject.Find("SoundBox1").GetComponent<AudioSource>().Play();
        isAnimating = true;
        StartCoroutine("FadeIn");
        yield return new WaitForSeconds(0.5f);
        ani.SetBool("Drink", false);
        yield return new WaitForSeconds(4.5f);
        StartCoroutine("FadeOut");
        GameObject.Find("SoundBox1").GetComponent<AudioSource>().Stop();
        GameObject.Find("BaseSound").GetComponent<AudioSource>().Play();

        // 물마시기 끝
        isAnimating = false;

        // 대기 후 앉기
        yield return new WaitForSeconds(3f);
        ani.SetBool("Sleep", true);
        yield return new WaitForSeconds(2f);
        text1.text = "배가 부른 강아지가 졸려합니다 강아지를 재워주세요 \n 강아지가 잠에 들고나면 기기를 벗고 체험을 종료해주시면 됩니다.";
        yield return new WaitForSeconds(2f);
        SleepButton.gameObject.SetActive(true);
    }


   

    IEnumerator Story8()
    {
        SleepButton.gameObject.SetActive(false);
        text1.text = "";
        yield return new WaitForSeconds(1f);
        ani.SetBool("RealSleep", true);
        isAnimating = true;
        GameObject.Find("BaseSound").GetComponent<AudioSource>().Stop();

        // 소리도 꺼지고 버튼도 없어지고 텍스트도 없어짐. 잠에빠짐
        yield return new WaitForSeconds(2.5f);
        particleObject1.Play();
        
        
        yield return new WaitForSeconds(30f);

        SceneManager.LoadScene("start");
        

       
        
    }





    IEnumerator FadeOut()
    {
        int i = 10;
        while (i > 0)
        {
            i -= 1;
            float f = i / 10.0f;
            Color c = renderer.material.color;
            Color c2 = renderer2.material.color;
            c.a = f;
            c2.a = f;
            renderer.material.color = c;
            renderer2.material.color = c2;
            yield return new WaitForSeconds(0.02f);
        }
    }

    IEnumerator FadeIn()
    {
        int i = 0;
        while (i < 10)
        {
            i += 1;
            float f = i /10.0f;
            Color c = renderer.material.color;
            Color c2 = renderer2.material.color;
            c.a = f;
            c2.a = f;
            renderer.material.color = c;
            renderer2.material.color = c2;
            yield return new WaitForSeconds(0.02f);
        }
    }

   
   
}
