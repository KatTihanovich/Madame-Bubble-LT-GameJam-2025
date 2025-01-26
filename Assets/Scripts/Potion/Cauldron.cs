using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cauldron : MonoBehaviour
{
    [SerializeField] private Sprite[] _listCauldronSprite;
    [SerializeField] private Image[] _listImagesIngredients;
    [SerializeField] private GameObject _panelCaudron;
    [SerializeField] private GameObject[] _personalItems;

    private List<IngredientData> _currentIngredients = new List<IngredientData>();
    private PotionController _potionController;
    private ProgressBarTimer _progressBarTimer;
    private DropPotion _dropPotion;

    private bool _isPotionCreated;
    private string _potionName;

    private void Start()
    {
        _potionController = FindFirstObjectByType<PotionController>();
        _progressBarTimer = FindFirstObjectByType<ProgressBarTimer>();
        _dropPotion = FindFirstObjectByType<DropPotion>();

        if (_progressBarTimer != null)
        {
            _progressBarTimer.OnTimerCompleted += ShowPotionResult;
        }
    }

    private void OnEnable()
    {
        ResetCauldron();
    }

    private void OnDestroy()
    {
        if (_progressBarTimer != null)
        {
            _progressBarTimer.OnTimerCompleted -= ShowPotionResult;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ingredients"))
        {
            string ingredientName = collision.gameObject.name;
            Sprite ingredientSprite = collision.GetComponent<SpriteRenderer>()?.sprite;

            Ingredient ingredientComponent = collision.GetComponent<Ingredient>();
            if (ingredientComponent == null)
            {
                Debug.LogError($"Объект {ingredientName} не имеет компонента Ingredient!");
                return;
            }

            _currentIngredients.Add(new IngredientData
            {
                Name = ingredientName,
                Sprite = ingredientSprite,
                StartPosition = ingredientComponent.StartPosition,
                GameObject = collision.gameObject
            });

            collision.gameObject.SetActive(false);
            UpdateIngredientImages();

            Debug.Log($"Добавлен ингредиент: {ingredientName}");
        }
    }

    public void SetPersonaItems(int index) 
    {
        _personalItems[index].SetActive(true);
    }

    public void CheckPotion()
    {
        if (_currentIngredients.Count == 3)
        {
            foreach (var potion in _potionController.ListPotions)
            {
                if (IsMatchingRecipe(potion.ListIngredients))
                {
                    _potionName = potion.Name;

                    ChangeCauldronSprite(potion.Name);

                    _panelCaudron.SetActive(false);
                    StartPotionTimer(5f);
                    return;
                }
            }
            _panelCaudron.SetActive(false);
            _potionName = "0";
            StartPotionTimer(5f);
        }
    }

    private void StartPotionTimer(float duration)
    {
        if (_progressBarTimer != null)
        {
            _progressBarTimer.StartTimer(duration);
        }
    }

    private void ShowPotionResult()
    {
        Debug.Log("Результат создания зелья готов! " + _potionName);
        _dropPotion.Drop(Convert.ToInt32(_potionName));
    }

    private bool IsMatchingRecipe(string[] recipeIngredients)
    {
        if (recipeIngredients.Length != _currentIngredients.Count) return false;

        foreach (var ingredient in recipeIngredients)
        {
            if (!_currentIngredients.Exists(i => i.Name == ingredient)) return false;
        }

        return true;
    }

    private void ChangeCauldronSprite(string potionName)
    {
        // Реализуйте смену спрайта котла на основе имени зелья
    }

    private void UpdateIngredientImages()
    {
        foreach (var image in _listImagesIngredients)
        {
            image.sprite = null;
            image.enabled = false;
        }

        for (int i = 0; i < _currentIngredients.Count && i < _listImagesIngredients.Length; i++)
        {
            _listImagesIngredients[i].sprite = _currentIngredients[i].Sprite;
            _listImagesIngredients[i].enabled = true;
        }
    }

    public void RemoveIngredient(int ingredientNumber)
    {
        if (ingredientNumber < 0 || ingredientNumber >= _currentIngredients.Count) return;

        IngredientData ingredientData = _currentIngredients[ingredientNumber];

        ingredientData.GameObject.transform.localPosition = ingredientData.StartPosition;
        Debug.Log(ingredientData.GameObject.transform.localPosition);
        ingredientData.GameObject.SetActive(true);

        _currentIngredients.RemoveAt(ingredientNumber);
        UpdateIngredientImages();
    }

    public void ResetCauldron()
    {
        RemoveIngredient(0);
        RemoveIngredient(1);
        RemoveIngredient(2);

        RemoveAll();
        _currentIngredients.Clear();

        foreach (var image in _listImagesIngredients)
        {
            image.sprite = null;
            image.enabled = false;
        }

        if (_progressBarTimer != null)
        {
            _progressBarTimer.ResetTimer();
        }

        _potionName = string.Empty;

        Debug.Log("Котел был сброшен.");
    }

    private void RemoveAll() 
    {
        foreach (IngredientData ingredientData in _currentIngredients)  
        {
            ingredientData.GameObject.transform.localPosition = ingredientData.StartPosition;
            ingredientData.GameObject.SetActive(true);
        }    
    }

    private class IngredientData
    {
        public string Name;
        public Sprite Sprite;
        public Vector3 StartPosition;
        public GameObject GameObject;
    }
}
