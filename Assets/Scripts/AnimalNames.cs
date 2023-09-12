using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimalNames", menuName = "ScriptableObjects/AnimalNames", order = 1)]
public class AnimalNames : ScriptableObject
{
    public List<string> names = new List<string>
    {
        "Jerald", "Roland", "Tiffany", "Stella", "Miles", "Leo", "Bella",
        "Nora", "Oscar", "Lily", "Finn", "Zoe", "Charlie", "Ella",
        "Henry", "Sophia", "Max", "Ava", "Lucas", "Emma",
        "Liam", "Olivia", "Mason", "Aria", "Ethan", "Isabella",
        "Noah", "Mia", "Logan", "Amelia"
    };
}
