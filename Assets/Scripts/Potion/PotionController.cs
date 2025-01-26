using UnityEngine;

public class PotionController : MonoBehaviour
{
    [SerializeField] private Potion[] _listPotions;
    [SerializeField] private Cauldron _cauldron;

    public Potion[] ListPotions => _listPotions; 

    public void SetPersonalItems (int index)
    {
        _cauldron.SetPersonaItems (index);
    }
}

[System.Serializable]
public class Potion
{
    public string Name;
    public string[] ListIngredients; 
}
