using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SceneController : MonoBehaviour
{
    public AudioClip basari;
    public AudioClip basarisiz;
    public AudioSource sound;
    public Text point;
    public Text state;
    public Text badstate;
    int puan = 0;
    public  int gridRows = 2;
    public  int gridCols = 5;
    public const float offsetX = 2f;
    public const float offsetY = 2.5f;
    
    [SerializeField] private MemoryCard originalCard;
    [SerializeField] public Sprite[] images;
    
    private void Start()
    {
        Vector3 startPos = originalCard.transform.position;  //urettigi yer burası 


        if (gridRows == 2 && gridCols == 5)
        {
         int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4};
            numbers = ShuffleArray(numbers);
            for (int i = 0; i < gridCols; i++)
            {
                for (int j = 0; j < gridRows; j++)
                {
                    MemoryCard card;
                    if (i == 0 && j == 0) { card = originalCard; }
                    else { card = Instantiate(originalCard) as MemoryCard; }

                    int index = j * gridCols + i;
                    int id = numbers[index];
                    card.SetCard(id, images[id]);

                    float posX = (offsetX * i) + startPos.x;
                    float posY = -(offsetY * j) + startPos.y;
                    card.transform.position = new Vector3(posX, posY, startPos.z);
                }
            }
        }
        else if (gridRows == 3 && gridCols == 6)
        {
            int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8};
            numbers = ShuffleArray(numbers);
            for (int i = 0; i < gridCols; i++)
            {
                for (int j = 0; j < gridRows; j++)
                {
                    MemoryCard card;
                    if (i == 0 && j == 0) { card = originalCard; }
                    else { card = Instantiate(originalCard) as MemoryCard; }

                    int index = j * gridCols + i;
                    int id = numbers[index];
                    card.SetCard(id, images[id]);

                    float posX = (offsetX * i) + startPos.x;
                    float posY = -(offsetY * j) + startPos.y;
                    card.transform.position = new Vector3(posX, posY, startPos.z);
                }
            }
        }
       else if (gridRows == 2 && gridCols == 6)
        {
            int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5};
            numbers = ShuffleArray(numbers);
            for (int i = 0; i < gridCols; i++)
            {
                for (int j = 0; j < gridRows; j++)
                {
                    MemoryCard card;
                    if (i == 0 && j == 0) { card = originalCard; }
                    else { card = Instantiate(originalCard) as MemoryCard; }

                    int index = j * gridCols + i;
                    int id = numbers[index];
                    card.SetCard(id, images[id]);

                    float posX = (offsetX * i) + startPos.x;
                    float posY = -(offsetY * j) + startPos.y;
                    card.transform.position = new Vector3(posX, posY, startPos.z);
                }
            }
        }


    }

    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for (int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    private MemoryCard _firstRevealed;
    private MemoryCard _secondRevealed;
    private MemoryCard secondCard;

    public bool canReveal
    {
        get { return _secondRevealed == null; }
    }
    public int sayacTıklama = 0;
    public int tahmin = 0;
    public void CardRevealed(MemoryCard card)
    {

       

     if (sayacTıklama % 2 == 0)
        {
            _firstRevealed = card;
            tahmin++;
        }
        else
        {
            secondCard = card;
            tahmin++;
        }


        if ((tahmin) % 2 == 0)
        {
            if (secondCard.id == _firstRevealed.id)
             {
                badstate.gameObject.SetActive(false);
                puan = puan +10;
                point.GetComponent<Text>().text ="Puanınız:" + puan.ToString();
                state.gameObject.SetActive(true);
                sound.PlayOneShot(basari);
                // başarılı oldugunda yapılacak kısım ses puan vs vs burdan tetiklenecek
           

                StartCoroutine(waiter(true, false));
               
            }
            else
            {
                puan = puan -5;
                point.GetComponent<Text>().text = "Puanınız:" + puan.ToString();
                sound.PlayOneShot(basarisiz);
                state.gameObject.SetActive(false);
                badstate.gameObject.SetActive(true);
                // başarısız oldugunda gidilecek fonksyon
                StartCoroutine(waiter(false,true)); 

            }
        }

        sayacTıklama++;//tıklama artışı 

    }
    IEnumerator waiter(bool durum,bool deger)
    {
        //Rotate 90 deg
        //transform.Rotate(new Vector3(90, 0, 0), Space.World);


        //Wait for 4 seconds
        if (!durum)//yanlış ise calışacak yer 
        {
         yield return new WaitForSeconds(1);
        _firstRevealed.cardBack.SetActive(deger);

        secondCard.cardBack.SetActive(deger);

        }
        else
        {

            yield return new WaitForSeconds(1);
            Destroy(_firstRevealed.cardBack.transform.parent.gameObject);
            Destroy(secondCard.cardBack.transform.parent.gameObject); 
           
            //_firstRevealed.cardBack.enablet(deger);

           // secondCard.cardBack.SetActive(deger);

        }
        

    }
}
