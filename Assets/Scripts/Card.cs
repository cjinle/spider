using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{

    [SerializeField] Sprite BackBg;
    [SerializeField] Sprite FrondBg;

    [SerializeField] Sprite[] BlackNums;
    [SerializeField] Sprite[] RedNums;
    [SerializeField] Sprite[] BigSuits;
    [SerializeField] Sprite[] SmallSuits;
    [SerializeField] Sprite[] BlackJQK;
    [SerializeField] Sprite[] RedJQK;

    Transform CurNum;
    Transform CurSmallSuit;
    Transform CurBigSuit;

    int num;
    int suit;
    bool isCover;

    void Awake()
    {
        Debug.Log("card awake.");
        foreach (Transform item in transform)
        {
            if (item.name.Equals("Num"))
            {
                CurNum = item;
            }
            else if (item.name.Equals("SmallSuit"))
            {
                CurSmallSuit = item;
            }
            else if (item.name.Equals("BigSuit"))
            {
                CurBigSuit = item;
            }
        }

        //SetCard(0x3d);
        //SetCover(true);
        //SetCover(false);
    }

    public void SetCover(bool flag)
    {
        //isCover = !isCover;
        isCover = flag;
        if (isCover)
        {
            GetComponent<Image>().sprite = BackBg;
        }
        else
        {
            GetComponent<Image>().sprite = FrondBg;
        }
        CurNum.gameObject.SetActive(!isCover);
        CurSmallSuit.gameObject.SetActive(!isCover);
        CurBigSuit.gameObject.SetActive(!isCover);

    }

    public void SetCard(int num)
    {
        this.num = num;
        suit = num >> 4;
        int realNum = num & 0xf;
        Debug.Log("num: " + num + ", real num: "+realNum+", suit: "+suit);
        Debug.Log(RedNums);
        Debug.Log(RedJQK);
        //Sprite[] nums = new Sprite[13];
        //Sprite[] jqk = new Sprite[3];
        //if (suit % 2 == 0)
        //{
        //    RedNums.CopyTo(nums, 0);
        //    RedJQK.CopyTo(jqk, 0);

        //}
        //else
        //{
        //    BlackNums.CopyTo(nums, 0);
        //    BlackJQK.CopyTo(jqk, 0);
        //}

        Sprite[] nums = suit % 2 == 0 ? RedNums : BlackNums;
        Sprite[]  jqk = suit % 2 == 0 ? RedJQK : BlackJQK;
        Debug.Log(nums);
        CurNum.GetComponent<Image>().sprite = nums[realNum - 1];
        CurSmallSuit.GetComponent<Image>().sprite = SmallSuits[suit];
        switch (realNum)
        {
            case 0xb:
                CurBigSuit.GetComponent<Image>().sprite = jqk[0];
                break;
            case 0xc:
                CurBigSuit.GetComponent<Image>().sprite = jqk[1];
                break;
            case 0xd:
                CurBigSuit.GetComponent<Image>().sprite = jqk[2];
                break;
            default:
                CurBigSuit.GetComponent<Image>().sprite = BigSuits[suit];
                break;
        }
        if (realNum >= 0xb && realNum <= 0xd)
        {
            CurBigSuit.localPosition = new Vector3(11f, -17f, 0);
            CurBigSuit.GetComponent<RectTransform>().sizeDelta = new Vector2(66f, 88f);
        }
    }
    
}
