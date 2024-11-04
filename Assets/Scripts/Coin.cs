using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    public GameObject dollarSpite;
    public Button button;
    public Camera cam;
    public Transform targetObject;
    private void Start()
    {
        button.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        Vector3 spawnPosition = Input.mousePosition;
        SpawnDollar(spawnPosition);
    }

    private void SpawnDollar(Vector3 spawnPosition)
    {
        Vector3 worldPosition=cam.ScreenToWorldPoint(spawnPosition);
        worldPosition.z = 0;
        Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(0f,360f));
        if (dollarSpite != null)
        {
            GameObject dollar = Instantiate(dollarSpite, worldPosition, rotation);
            Dollar dollarScript= dollar.GetComponent<Dollar>();
            if(dollarScript != null)
                dollarScript.LaunchInRandomDirection(targetObject,cam);
        }
    }

    void Update()
    {
    }
}
