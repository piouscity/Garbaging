using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    private List<GameObject> fishList;
    public GameObject fishType1;
	public GameObject fishType2;
	public GameObject fishType3;


    void CreateFish(GameObject fish, Vector2 position)
    {
        GameObject newFish = Instantiate(fish, position, Quaternion.identity);
        newFish.GetComponent<Fish>().manager = gameObject.GetComponent<FishController>();
        fishList.Add(newFish);
    }
    public void RemoveFish(GameObject fish)
    {
        fishList.Remove(fish);
    }

    void Start()
    {
        fishList = new List<GameObject>();
        CreateFish(fishType1, new Vector2(Random.Range(-GameManager.instance.maxX, -GameManager.instance.minX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)));
        CreateFish(fishType2, new Vector2(Random.Range(GameManager.instance.minX, GameManager.instance.maxX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)));
        CreateFish(fishType1, new Vector2(Random.Range(-GameManager.instance.maxX, -GameManager.instance.minX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)));
        CreateFish(fishType2, new Vector2(Random.Range(GameManager.instance.minX, GameManager.instance.maxX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)));
        CreateFish(fishType3, new Vector2(Random.Range(GameManager.instance.minX, GameManager.instance.maxX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)));
        CreateFish(fishType1, new Vector2(Random.Range(-GameManager.instance.maxX, -GameManager.instance.minX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)));
        CreateFish(fishType2, new Vector2(Random.Range(-GameManager.instance.maxX, -GameManager.instance.minX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)));

    }

    // Update is called once per frame
    void Update()
    {
        if (fishList.Count <= 4)
        {
            CreateFish(fishType1, new Vector2(Random.Range(-GameManager.instance.maxX, -GameManager.instance.minX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)));
            CreateFish(fishType3, new Vector2(Random.Range(GameManager.instance.minX, GameManager.instance.maxX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)));
            CreateFish(fishType2, new Vector2(Random.Range(-GameManager.instance.maxX, -GameManager.instance.minX), Random.Range(GameManager.instance.minY, GameManager.instance.maxY)));
        }
    }
}
