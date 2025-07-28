using System.Collections;
using System.Timers;
using UnityEngine;

public class DeactiveActiveTiming : MonoBehaviour
{
    private GameObject platformChild;
    [SerializeField] private float activeTime = 3f;
    [SerializeField] private float deactiveTime = 1f;

    private void Awake()
    {
        platformChild = transform.GetChild(0).gameObject;
    }

    private IEnumerator toggle()
    {
        while (true)
        {
            yield return new WaitForSeconds(deactiveTime);
            platformChild.SetActive(true);

            yield return new WaitForSeconds(activeTime);
            platformChild.SetActive(false);
        }
    }

    private void Start()
    {
        StartCoroutine(toggle());
    }

}
