using System.Collections.Generic;
using UnityEngine;

public class Cauldron : MonoBehaviour
{
    [SerializeField] private Sprite[] _listCauldronSprite;
    private List<string> _currentIngredients = new List<string>();
    private PotionController _potionController; 

    private void Start()
    {
        _potionController = _potionController = FindFirstObjectByType<PotionController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Ingredients"))
        {
            string ingredientName = collision.gameObject.name;
            _currentIngredients.Add(ingredientName); 
            Destroy(collision.gameObject);

            Debug.Log($"Добавлен ингредиент: {ingredientName}");
            CheckPotion();
        }
    }

    private void CheckPotion()
    {

        foreach (var potion in _potionController.ListPotions)
        {
            if (IsMatchingRecipe(potion.ListIngredients))
            {
                Debug.Log($"Создано зелье: {potion.Name}");
                _currentIngredients.Clear(); 
                ChangeCauldronSprite(potion.Name);
                return;
            }
        }

        Debug.Log("Не удалось создать зелье, недостаточно ингредиентов.");
    }

    private bool IsMatchingRecipe(string[] recipeIngredients)
    {

        if (recipeIngredients.Length != _currentIngredients.Count) return false;

        foreach (var ingredient in recipeIngredients)
        {
            if (!_currentIngredients.Contains(ingredient)) return false;
        }

        return true;
    }

    private void ChangeCauldronSprite(string potionName)
    {
        
    }
}
