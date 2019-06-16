using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    private const string V = "TextScore";
    private readonly int count;

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //表示するテキスト
    private GameObject GameoverText;
    private GameObject TextScore;

    //得点を表示するテキスト
    private int Score;

    // Use this for initialization
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.GameoverText = GameObject.Find("GameOverText");

        //シーン中のTextScoreオブジェクトを取得
        this.TextScore = GameObject.Find("TextScore");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.GameoverText.GetComponent<Text>().text = "Game Over";

        }

    }

    void OnCollisionEnter(Collision collision)
    {
         //ボールが小さい星に衝突したら+10点、大きい星に衝突したら＋20点加算
        if (collision.gameObject.tag == "SmallStarTag")
        {
             Score += 10;
            this.TextScore.GetComponent<Text>().text = Score.ToString();
        }
        else if (collision.gameObject.tag == "LargeStarTag")
        {
            Score += 20;
            this.TextScore.GetComponent<Text>().text = Score.ToString();
        }
     }
 }
    