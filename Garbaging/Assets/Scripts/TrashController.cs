using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    // Start is called before the first frame update
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


    void createTrash(GameObject trash)
    {
        GameManager.instance.listTrash.Add((GameObject)Instantiate(trash, new Vector2(Random.Range(-GameManager.instance.screenHeight / 2, GameManager.instance.screenHeight / 2), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)), Quaternion.identity));

    }

    void createListTrash()
    {
        createTrash(trashType1);
        createTrash(trashType2);
        createTrash(trashType3);
        createTrash(trashType4);
        createTrash(trashType5);
        createTrash(trashType6);
        createTrash(trashType7);
        createTrash(trashType8);
        createTrash(trashType9);
        createTrash(trashType10);
    }

    void Start()
    {
        createListTrash();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.listTrash.Count == 0)
        {
            createListTrash();
        }
    }
}
