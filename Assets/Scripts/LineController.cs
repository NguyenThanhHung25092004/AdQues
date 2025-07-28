using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer line;
    [SerializeField] private List<Transform> points;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = points.Count;
    }

    private void Update()
    {
        for(int i = 0; i < points.Count; i++)
        {
            line.SetPosition(i, points[i].position);
        }
    }


}
