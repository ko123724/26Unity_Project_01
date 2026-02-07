using UnityEngine;

public class Goalline : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)

    {


        if(other.CompareTag("Player"))

        Debug.Log("게임을 클리어함");

    }
}
