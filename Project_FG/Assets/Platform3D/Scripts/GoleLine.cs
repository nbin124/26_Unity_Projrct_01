using UnityEngine;

public class GoleLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {
            Debug.Log("게임을 클리어했습니다.");

        }

    }

}
