using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float movSpeedFactor = 9f;       // 변수 앞에 public을 붙이면 component 목록에 뜸. 소스코드에서 바꿔도 되고 유니티 프로그램에서 바꿔도 됨
    Transform transComp;

    // Start is called before the first frame update
    void Start()
    {
        transComp = GetComponent<Transform>();      // Transform을 가져옴
    }

    // Update is called once per frame
    void Update()
    {
        float verti = Input.GetAxis("Vertical");        // 수평(Vertical)입력. 기본키 W,S. 키보드 입력값에 대해서 -1에서 1까지의 값을 가짐
        Debug.Log(verti);

        //transComp.Translate(0, 0, verti * Time.deltaTime);       // 위치에 접근. 1초에 1 움직임
        transComp.Translate(0, 0, verti * Time.deltaTime * movSpeedFactor);       // 위치에 접근. 1초에 9 움직임

    }
}
