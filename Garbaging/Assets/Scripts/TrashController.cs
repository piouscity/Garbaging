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

    void CreateTrash(GameObject trash)
    {
        GameObject newTrash = Instantiate(
            trash, 
            new Vector2(
                Random.Range(
                    -GameManager.instance.screenHeight / 2, 
                    GameManager.instance.screenHeight / 2
                ), 
                Random.Range(
                    GameManager.instance.minY, 
                    GameManager.instance.maxY
                )
            ), 
            Quaternion.identity
        );
        newTrash.GetComponent<Trash>().manager = GetComponent<TrashController>();
        listTrash.Add(newTrash);
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
    }
}
