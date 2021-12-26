using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCoin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.deltaTime);      // 한 프레임이 완료될때까지 걸리는 시간
        // 0.0037이면 1초당 약 270 프레임

        Debug.Log(Time.frameCount);     // 누적 프레임
        // 1 2 3 4.... 220 221 222...

        transform.Rotate(0, 1, 0);      // 한 번 돌때마다 1도. 호출될때마다 누적
    }
}
