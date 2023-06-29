using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.Linq;

public class ButtonSwap : MonoBehaviour
{
    public GameObject layoutGroupObject;
    private VerticalLayoutGroup layoutGroup;
    public Button onClickButton;

    void Start()
    {
        layoutGroup = layoutGroupObject.GetComponent<VerticalLayoutGroup>();
    }

    void Update()
    {

    }


    static int[] GenerateRandomArray()
    {
        System.Random random = new System.Random();
        int[] array = new int[4] { 0, 1, 2, 3 };
        int[] shuffledArray = array.OrderBy(x => random.Next()).ToArray();
        return shuffledArray;
    }

    public void SwapButtons()
    {
        Transform[] children = new Transform[layoutGroup.transform.childCount];
        for (int i = 0; i < layoutGroup.transform.childCount; i++)
        {
            children[i] = layoutGroup.transform.GetChild(i);
        }

        
        int[] randArray = GenerateRandomArray();
        Debug.Log(randArray[0]);
        Debug.Log(randArray[1]);
        Debug.Log(randArray[2]);
        Debug.Log(randArray[3]);

        children[randArray[0]].SetSiblingIndex(0);
        children[randArray[1]].SetSiblingIndex(1);
        children[randArray[2]].SetSiblingIndex(2);
        children[randArray[3]].SetSiblingIndex(3);

    }

    void Awake()
    {
        onClickButton.onClick.AddListener(SwapButtons);
    }
}
