using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public float movSpeedFactor = 9f;
    public float rotSpeedFactor = 50f;
    public float jumpPowerFactor = 5f;


    public GameObject doorToOpen;
    public GameObject CoinPrefab;
    
    Animator doorAni;

    int coinCount = 0;

    Transform transComp;
    Rigidbody rigidBD;

    public Text scoreText;

    // sound 
    private AudioSource audio;
    public AudioClip coinSound;


    // Start is called before the first frame update
    void Start()
    {
        transComp = GetComponent<Transform>();
        rigidBD = GetComponent<Rigidbody>();

        doorAni = doorToOpen.GetComponent<Animator>();

        // audio 추가 
        this.audio = this.gameObject.AddComponent<AudioSource>();
        this.audio.clip = coinSound;
        this.audio.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (coinCount >= 5)
        {
            GameObject.Find("Canvas").transform.Find("gameWinText").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("restartButton").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("quitButton").gameObject.SetActive(true);
            return;
        }

        float horiz = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");

        //Debug.Log(verti);

        // 전후진, W,S 키
        transComp.Translate(0, 0, verti * Time.deltaTime * movSpeedFactor);
        // 회전, A,D 키
        transComp.Rotate(new Vector3(0, horiz, 0) * rotSpeedFactor * Time.deltaTime);

        // Jump 하기 , 위로 힘을 가한다.
        if (Input.GetMouseButtonDown(0))
        {
            rigidBD.AddForce(Vector3.up * jumpPowerFactor, ForceMode.Impulse);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            Debug.Log("동전에 충돌했음");

            // 동전을 제거 한다.
            Destroy(other.gameObject);

            coinCount++;

            scoreText.text = "Score : " + coinCount.ToString();

            this.audio.Play();
        }
        else if (other.gameObject.tag == "key")
        {
            // 문 열기 
            if (coinCount == 3)
            {
                doorAni.SetTrigger("open");
                // switch 색 초록으로 바꾸기 
                other.gameObject.GetComponent<Renderer>().material.color = Color.green;
            }
        }
        else if (other.gameObject.tag == "sphere")
        {
            // test .. 문 닫기 
            doorAni.SetTrigger("close");

            // 뿅 하고 동전 나오기
            Instantiate(CoinPrefab, new Vector3(-2.7f, 0.5f, 4.5f), Quaternion.identity);
            Instantiate(CoinPrefab, new Vector3(-0.88f, 0.5f, 9.6f), Quaternion.identity);
        }
    }
}
