using UnityEngine;
using UnityEngine.UI;

public class DropPotion : MonoBehaviour
{
    [SerializeField] private Sprite[] _listPotionSprites;
    [SerializeField] private GameObject _dropPotion;

    public void Drop(int number) 
    {
        _dropPotion.GetComponent<Image>().sprite = _listPotionSprites[number];
        _dropPotion.SetActive(true);
    }

    public void ResetDrop() 
    {
        _dropPotion.SetActive(false);
    }

}
