using UnityEngine;
using UnityEngine.UI;

public class CardSwitcher : MonoBehaviour
{
    // Структура для хранения карточки, её позиции и связанного объекта
    [System.Serializable]
    public class CardData
    {
        public GameObject card;       // Карточка
        public Button cardButton;    // Кнопка на карточке
    }

    // Массив карточек
    public CardData[] cards;

    // Объект Red Circle, который должен появляться
    public GameObject redCircle;

    // Метод, вызываемый при клике на карточку
    public void OnCardClick(GameObject clickedCard)
{
    // Сначала сбросьте все карты и кнопки
    foreach (var cardData in cards)
    {
        cardData.card.SetActive(false);             // Скрыть карту
        cardData.cardButton.interactable = false;  // Сделать кнопку неактивной
    }

    // Теперь активируйте только выбранную карту и кнопку
    foreach (var cardData in cards)
    {
        if (cardData.card == clickedCard)
        {
            cardData.card.SetActive(true);              // Показать выбранную карту
            cardData.cardButton.interactable = true;    // Сделать кнопку активной
        }
    }

    // Сделать Red Circle видимым
    redCircle.SetActive(true);
}
}