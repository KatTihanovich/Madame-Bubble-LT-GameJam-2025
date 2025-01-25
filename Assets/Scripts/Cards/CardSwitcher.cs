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
        foreach (var cardData in cards)
        {
            // Если карточка совпадает с нажатой
            if (cardData.card == clickedCard)
            {
                // Сделать Red Circle видимым
                redCircle.SetActive(true);

                // Оставить только выбранную карту видимой
                cardData.card.SetActive(true);
                cardData.cardButton.interactable = true; // Включить кнопку только для выбранной карты
            }
            else
            {
                // Остальные карты отключить
                cardData.card.SetActive(false);
                cardData.cardButton.interactable = false; // Отключить их кнопки
            }
        }
    }
}