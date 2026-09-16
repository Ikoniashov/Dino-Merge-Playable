using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Grid/CustomGridShape")]
public class CustomGridShape : ScriptableObject
{
    public List<Vector2Int> cells;  // пример: (0,0), (1,0), (1,1), (2,1)...
}