using UnityEngine;

public class PotionController : MonoBehaviour
{
    [SerializeField] private Potion[] _listPotions;

    public Potion[] ListPotions => _listPotions; 
}

[System.Serializable]
public class Potion
{
    public string Name;
    public string[] ListIngredients; 
}
