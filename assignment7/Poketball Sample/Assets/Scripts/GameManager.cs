using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    UIManager MyUIManager;

    public GameObject BallPrefab;   // prefab of Ball

    // Constants for SetupBalls
    public static Vector3 StartPosition = new Vector3(0, 0, -6.35f);
    public static Quaternion StartRotation = Quaternion.Euler(0, 90, 90);
    const float BallRadius = 0.286f;
    const float RowSpacing = 0.02f;

    GameObject PlayerBall;
    GameObject CamObj;

    const float CamSpeed = 3f;

    const float MinPower = 15f;
    const float PowerCoef = 1f;

    void Awake()
    {
        // PlayerBall, CamObj, MyUIManager를 얻어온다.
        // ---------- TODO ---------- 
        PlayerBall = GameObject.Find("PlayerBall");
        CamObj = GameObject.Find("Main Camera");
        MyUIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        // -------------------- 
    }

    void Start()
    {
        SetupBalls();
    }

    // Update is called once per frame
    void Update()
    {
        // 좌클릭시 raycast하여 클릭 위치로 ShootBallTo 한다.
        // ---------- TODO ---------- 
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100f))
            {
                ShootBallTo(hit.point);
            }
        }
        // -------------------- 
    }

    void LateUpdate()
    {
        CamMove();
    }

    void SetupBalls()
    {
        // 15개의 공을 삼각형 형태로 배치한다.
        // 가장 앞쪽 공의 위치는 StartPosition이며, 공의 Rotation은 StartRotation이다.
        // 각 공은 RowSpacing만큼의 간격을 가진다.
        // 각 공의 이름은 {index}이며, 아래 함수로 index에 맞는 Material을 적용시킨다.
        // Obj.GetComponent<MeshRenderer>().material = Resources.Load<Material>("Materials/ball_1");
        // ---------- TODO ----------
        int index = 1;
        Vector3 vari = new Vector3((2f * BallRadius + RowSpacing) / 2f, 0, 0);
        Vector3 vari_2 = new Vector3(0, 0, (2f * BallRadius + RowSpacing) * Mathf.Sin(Mathf.PI / 3f));
        for(int i=0; i < 5; i++)
        {
            for (int j = 0; j < i+1; j++)
            {
                GameObject ball = Instantiate(BallPrefab, StartPosition - (vari * i) + (2f * j * vari), StartRotation);
                ball.name = index.ToString();
                ball.GetComponent<MeshRenderer>().material = Resources.Load<Material>($"Materials/ball_{index}");
                
                index++;
            }
            StartPosition -= vari_2;
        }
            
        // -------------------- 
    }
    void CamMove()
    {
        // CamObj는 PlayerBall을 CamSpeed의 속도로 따라간다.
        // ---------- TODO ---------- 
        Vector3 tarPos = new Vector3(PlayerBall.transform.position.x + 0.0f, PlayerBall.transform.position.y + 15.0f, PlayerBall.transform.position.z + 0.0f);
        CamObj.transform.position = Vector3.Lerp(CamObj.transform.position, tarPos, Time.deltaTime * CamSpeed);
        // -------------------- 
    }

    float CalcPower(Vector3 displacement)
    {
        return MinPower + displacement.magnitude * PowerCoef;
    }

    void ShootBallTo(Vector3 targetPos)
    {
        // targetPos의 위치로 공을 발사한다.
        // 힘은 CalcPower 함수로 계산하고, y축 방향 힘은 0으로 한다.
        // ForceMode.Impulse를 사용한다.
        // ---------- TODO ---------- 
        float power;
        Vector3 direction = targetPos - PlayerBall.transform.position;
        Rigidbody rb = PlayerBall.GetComponent<Rigidbody>();
        if (rb == null) return;

        direction.y = 0;

        Vector3 normalizedDirection = direction.normalized;
        power = CalcPower(direction);

        Vector3 mforce = normalizedDirection * power;

        rb.AddForce(mforce, ForceMode.Impulse);
        
        // -------------------- 
    }
    
    // When ball falls
    public void Fall(string ballName)
    {
        // "{ballName} falls"을 1초간 띄운다.
        // ---------- TODO ---------- 
        MyUIManager.DisplayText($"{ballName} falls", 1);
        // -------------------- 
    }
}
