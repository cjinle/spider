using UnityEngine;

public class MainCtrl : MonoBehaviour
{

    [SerializeField] GameObject CardPrefab;

    float startW = -640f;
    float startHeight = 280f;
    int num = 1;
    int suit = 0;

    public void AddCard()
    {
        if (num > 0xd)
        {
            num = 1;
            startHeight -= 50;
            suit++;
        }
        if (suit >= 4)
        {
            suit = 0;
        }

        GameObject go = Instantiate(CardPrefab, transform);
        Debug.Log("suit: " + suit + ", num: " + num);
        go.SendMessage("SetCard", (suit << 4) + num);
        go.transform.localPosition = new Vector3(startW + (num * 50), startHeight);       
        num++;
    }

}
