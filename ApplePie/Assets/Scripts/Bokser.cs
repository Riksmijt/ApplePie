using UnityEngine;

public class Bokser : MonoBehaviour
{
    [SerializeField] private GameObject ab1;
    [SerializeField] private GameObject ab2;
    void Start()
    {
        ab1.SetActive(false);
        ab2.SetActive(false);
    }   
}
