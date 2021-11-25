using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public TMP_Text mainText;
    public int gameState;

    public Color leftColOld;
    public Color rightColOld;

    public Color leftColNew;
    public Color rightColNew;

    public Image leftBut;
    public Image rightBut;

    public Button leftButton;
    public Button rightButton;
    public Button shakeButton;
    public GameObject backButton;

    public TMP_Text leftText;
    public TMP_Text rightText;

    public int leftScore;
    public int rightScore;

    public int leftTie;  // เช็คว่าทายถูก หรือผิด
    public int rightTie;  // เช็คว่าทายถูก หรือผิด

    // state 0 = ก่อนเริ่มเกม กด ไป 1
    // state 1 = กำลังสุมเลข พอสุมเสร็จจะไป 2 เอง
    // state 2 = สุ่มเลขเสร็จ รอหาคนกด ต้อง กด 2 รอบถึงจะนับดังนั้น กดรอบแรก ไป 3
    // state 3 = ถ้ากดที่เดิมซ้ำ คือคนนั้นได้แต้ม และไป 4 แต่ถ้ากดอีกที่จะกลับไป 2
    // state 4 = แสดงผู้ชนะ-กดอีกทีเพื่อไป 0
    // state 0 = ก่อนเริ่มเกม 

    public int nowScore;
    [SerializeField] GameObject imgPoint;

    public RectTransform PanelTran;
    public Ease tweenStyle;

    [SerializeField] GameObject leftPref;
    [SerializeField] GameObject rightPref;
    [SerializeField] Transform[] allSpawnPoint;

    private void Start() 
    {
        PanelTran.DOAnchorPos(Vector2.zero, 0.75f).SetEase(tweenStyle);
    }

    public void leftPress()
    {
        if (gameState == 0)
        {
            gameState = 1;
            StartCoroutine(startRandom());

        }
        else if (gameState == 2)
        {
            backButton.SetActive(false);
            leftTie = 1;
            leftBut.color = leftColNew;
            leftText.SetText("O");
            rightText.SetText("X");
            gameState = 3;
        }
        else if (gameState == 3)
        {
            if (leftTie == 1)
            {
                StartCoroutine(LeftGetScore());
            }
            else  // reset
            {
                leftTie = 0;
                rightTie = 0;
                gameState = 2;
            }
            resetButColor();
        }
 

    }

    public void rightPress()
    {
        if (gameState == 0)
        {
            gameState = 1;
            StartCoroutine(startRandom());

        }
        else if (gameState == 2)
        {
            backButton.SetActive(false);
            rightTie = 1;
            rightBut.color = rightColNew;
            leftText.SetText("X");
            rightText.SetText("O");
            gameState = 3;
        }
        else if (gameState == 3)
        {
            if (rightTie == 1)
            {
                StartCoroutine(RightGetScore());
            }
            else  // reset
            {
                leftTie = 0;
                rightTie = 0;
                gameState = 2;
            }
            resetButColor();
        }

    }

    public void backBtn()
    {
        restartgame();
        enableAllButton();
        backButton.SetActive(false);
    }

    void restartgame()
    {
        mainText.SetText("<size=15>PRESS BUTTON</size> \n<size=30>TO START</size>");
        gameState = 0;
        leftTie = 0;
        rightTie = 0;
    }

    void resetButColor()
    {
        backButton.SetActive(true);
        leftBut.color = leftColOld;
        rightBut.color = rightColOld;
        leftText.SetText("LEFT");
        rightText.SetText("RIGHT");
    }

    IEnumerator LeftGetScore()
    {
        FindObjectOfType<AudioManager>().Play("win");
        disableAllButton();
        
        yield return new WaitForSeconds(1f);
        mainText.SetText("LEFT++!");
        leftScore += nowScore;
        
        mainText.SetText($"<size=31>LEFT:{leftScore} / RIGHT:{rightScore}");
        yield return new WaitForSeconds(1f);
        PanelTran.DOAnchorPos(new Vector2(0, 558), 1.2f).SetEase(tweenStyle);

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < nowScore; i++)
        {
            int randomIndex = Random.Range(0, allSpawnPoint.Length);
            FindObjectOfType<AudioManager>().Play("spawn");
            Instantiate(leftPref, allSpawnPoint[randomIndex].position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(2f);
        mainText.SetText($"<size=15>PRESS</size> \n<size=30>TO CONTINUE</size>");

        PanelTran.DOAnchorPos(Vector2.zero, 1.2f).SetEase(tweenStyle);
        restartgame();
        enableAllButton();
    }

    IEnumerator RightGetScore()
    {
        FindObjectOfType<AudioManager>().Play("win");
        disableAllButton();
        
        yield return new WaitForSeconds(1f);
        mainText.SetText("RIGHT++!");
        rightScore += nowScore;

        mainText.SetText($"<size=31>LEFT:{leftScore} || RIGHT:{rightScore}");
        yield return new WaitForSeconds(1f);
        PanelTran.DOAnchorPos(new Vector2(0, 558), 1.2f).SetEase(tweenStyle);

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < nowScore; i++)
        {
            int randomIndex = Random.Range(0, allSpawnPoint.Length);
            FindObjectOfType<AudioManager>().Play("spawn");
            Instantiate(rightPref, allSpawnPoint[randomIndex].position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
        

        yield return new WaitForSeconds(2f);
        mainText.SetText($"<size=15>PRESS</size> \n<size=30>TO CONTINUE</size>");

        PanelTran.DOAnchorPos(Vector2.zero, 1.2f).SetEase(tweenStyle);
        restartgame();
        enableAllButton();
    }

    void showNowScore()
    {
        imgPoint.SetActive(true);
        imgPointShow imgpointScpt = imgPoint.GetComponent<imgPointShow>();
        nowScore = Random.Range(1, 4);
        imgpointScpt.set(nowScore);
        mainText.SetText($"<size=15>THIS QUESTION WORTH</size> \n<size=30>{nowScore} POINT</size>");
    }


    IEnumerator startRandom()
    {
        float timeWait = 0.85f;
        float timeRell = 0.15f;

        disableAllButton();

        showNowScore();
        yield return new WaitForSeconds(2.8f);
        imgPoint.SetActive(false);

        mainText.SetText("<size=15>REMEMBER THESE</size> \n<size=30>4 NUMBERS</size>");
        yield return new WaitForSeconds(1.2f);
        mainText.SetText(" ");
        yield return new WaitForSeconds(timeRell);
        FindObjectOfType<AudioManager>().PlayAddPitch("number", -0.1f);
        mainText.SetText(Random.Range(1, 10).ToString());

        yield return new WaitForSeconds(timeWait);
        mainText.SetText(" ");
        yield return new WaitForSeconds(timeRell);
        FindObjectOfType<AudioManager>().PlayAddPitch("number", -0.1f);
        mainText.SetText(Random.Range(1, 10).ToString());

        yield return new WaitForSeconds(timeWait);
        mainText.SetText(" ");
        yield return new WaitForSeconds(timeRell);
        FindObjectOfType<AudioManager>().PlayAddPitch("number", -0.1f);
        mainText.SetText(Random.Range(1, 10).ToString());

        yield return new WaitForSeconds(timeWait);
        mainText.SetText(" ");
        yield return new WaitForSeconds(timeRell);
        FindObjectOfType<AudioManager>().PlayAddPitch("number", -0.1f);
        mainText.SetText(Random.Range(1, 10).ToString());

        yield return new WaitForSeconds(timeWait);
        FindObjectOfType<AudioManager>().PlayAddPitch("number", -0.1f);
        mainText.SetText(Random.Range(11, 99).ToString());

        yield return new WaitForSeconds(1.5f);
        FindObjectOfType<AudioManager>().PlayAddPitch("number", .5f);
        mainText.SetText("<size=15>PRESS WHEN</size> \n<size=30>GOT ANSWER</size>");

        enableAllButton();
        backButton.SetActive(true);

        gameState = 2;

    }

    void disableAllButton()
    {
        leftButton.interactable = false;
        rightButton.interactable = false;
        shakeButton.interactable = false;
        backButton.SetActive(false);
    }

    void enableAllButton()
    {
        leftButton.interactable = true;
        rightButton.interactable = true;
        shakeButton.interactable = true;

    }

    public void shakeAllCoin()
    {
        GameObject[] AllCoin = GameObject.FindGameObjectsWithTag("Coin");
        foreach (var coin in AllCoin)
        {
            hitSound coinScpt = coin.GetComponent<hitSound>();
            coinScpt.rb.AddForce(new Vector2(Random.Range(-15, 15), Random.Range(-15, 15)), ForceMode2D.Impulse);
        }


    }





}
