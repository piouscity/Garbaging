using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public GameManager gameManager;
    public AudioSource soundHookMoved;
    public AudioSource soundHookVsGarbage;
    public AudioSource soundHookVsFish;
    public GameObject bingoEffect;

    public const float MAX_SPEED = 0.065f;
    public const float SPEED_UP = 1.05f;
    public const float BASE_SPEED = 0.04f;
    public const float PULL_SPEED = 3f;
    public const float DROP_SPEED = 2f;
    public float speedHook = BASE_SPEED;
    public bool isDie = false;

    bool isMove = true;
    bool isUp = false;
    GameObject clonedBingoEffect = null;
    int temp = 1;
    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        gameManager = GameManager.instance;
        GetComponent<Rigidbody2D>().fixedAngle = true;
    }

    public void SetBorder()
    {
        Vector3 initPosition = new Vector3(1, GameManager.instance.maxY, 0);
        GetComponent<Transform>().position = initPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isPause) return;
        if (!isDie)
        {
            if (clonedBingoEffect != null)
            {
                temp += 1;
                if (temp >= 50)
                {
                    Destroy(clonedBingoEffect);
                    clonedBingoEffect = null;
                    temp = 1;
                }
            }
            Vector2 posTemp = GetComponent<Transform>().position;
            if (isMove)
            {
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    if (posTemp.x > gameManager.minX)
                        posTemp.x -= speedHook;
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {

                    if (posTemp.x < gameManager.maxX)
                    {
                        posTemp.x += speedHook;
                    }
                }
                GetComponent<Transform>().position = posTemp;
            }
            else
            {
                if (!isUp)
                {
                    GetComponent<Rigidbody2D>().isKinematic = false;
                    posTemp.y -= DROP_SPEED * speedHook;
                    GetComponent<Transform>().position = posTemp;
                    if (GetComponent<Transform>().position.y <= gameManager.minY)
                    {
                        GetComponent<Rigidbody2D>().isKinematic = true;
                        isUp = true;
                    }
                }
                else
                {
                    posTemp.y += PULL_SPEED * speedHook;
                    GetComponent<Transform>().position = posTemp;
                    if (GetComponent<Transform>().position.y >= gameManager.maxY)
                    {
                        isUp = false;
                        isMove = true;
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (isMove)
                    soundHookMoved.Play();
                isMove = false;
            }
        } else if (isDie)
        {
            temp += 1;
            if (temp == 30)
            {
                GameManager.instance.SetGameOver();
            }
        }

    }

    public void UpdateLevel(int level)
    {
        speedHook = BASE_SPEED * Mathf.Pow(SPEED_UP, level);
    }
    public float GetPullSpeed()
    {
        return PULL_SPEED * speedHook;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fish")) 
        {
            if (!isUp)
            {
                soundHookVsFish.Play();
                isDie = true;
                return;
            }
        }

        if (collision.gameObject.CompareTag("Trash"))
        {
            clonedBingoEffect = Instantiate(bingoEffect, GetComponent<Transform>().position, Quaternion.identity);
            temp = 1;
            soundHookVsGarbage.Play();
            GetComponent<Rigidbody2D>().isKinematic = true;
            isUp = true;
        }
    }
}
