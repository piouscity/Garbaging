using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    private List<GameObject> listTrash;
    public GameObject trashType1;
    public GameObject trashType2;
    public GameObject trashType3;
    public GameObject trashType4;
    public GameObject trashType5;
    public GameObject trashType6;
    public GameObject trashType7;
    public GameObject trashType8;
    public GameObject trashType9;
    public GameObject trashType10;
    public GameObject plusAni;
    public GameManager gameManager;
    public bool isHideAniPlus = true;
    int temp = 0;

    void CreateTrash(GameObject trash)
    {
        float paddingHorizon = (gameManager.maxX - gameManager.minX) / 6;
        GameObject newTrash = Instantiate(
            trash, 
            new Vector2(
                Random.Range(gameManager.minX + paddingHorizon, gameManager.maxX - paddingHorizon), 
                Random.Range(
                    gameManager.minY, 
                    (gameManager.minY + gameManager.maxY) / 2
                )
            ), 
            Quaternion.identity
        );
        newTrash.GetComponent<Trash>().manager = GetComponent<TrashController>();
        listTrash.Add(newTrash);
    }

    public GameObject newPlusAni;

    public void CreatePlusAni(Vector2 position)
    {

        RemovePlusAni();
        newPlusAni = Instantiate(
            plusAni,
            new Vector2(position.x , position.y - 0.5f),
            Quaternion.identity
        );
    }

    public void setHidePlusAni(bool isHide)
    {
        print("Hoang");
        isHideAniPlus = isHide;
    }

    public void RemovePlusAni()
    {
        Destroy(newPlusAni);
    }

    public void RemoveTrash(GameObject trash)
    {
        listTrash.Remove(trash);
    }

    void CreateListTrash()
    {
        CreateTrash(trashType1);
        CreateTrash(trashType2);
        CreateTrash(trashType3);
        CreateTrash(trashType4);
        CreateTrash(trashType5);
        CreateTrash(trashType6);
        CreateTrash(trashType7);
        CreateTrash(trashType8);
        CreateTrash(trashType9);
        CreateTrash(trashType10);
    }

    void Start()
    {
        gameManager = GameManager.instance;
        listTrash = new List<GameObject>();
        CreateListTrash();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (listTrash.Count == 0)
        {
            CreateListTrash();
        }
        if (!isHideAniPlus)
        {
            print(temp);
            temp += 1;
            if (temp == 30)
            {
                RemovePlusAni();
                isHideAniPlus = true;
                temp = 0;
            }
        }
    }

    public void UpdateLevel(int level)
    {

    }
}
