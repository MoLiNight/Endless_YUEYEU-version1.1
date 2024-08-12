using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HandCardEvent : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public GameObject thisCard;
    public GameObject CardArea;
    public GameObject CardPrefab;
    public GameObject BattleManagers;
    private Vector3 OriginPosition;

    // Start is called before the first frame update
    void Start()
    {
        OriginPosition = thisCard.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 300, 0);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 300, 0);
    }

    public void DragMethod()
    {
        transform.position=Input.mousePosition;
    }

    public void EndDragMethod()
    {
        if (transform.position.y - OriginPosition.y <= 500)
        {

            GameObject returnCard = GameObject.Instantiate(CardPrefab, CardArea.transform);
            returnCard.GetComponent<CardDisplay>().card = thisCard.GetComponent<CardDisplay>().card;
            Destroy(thisCard);
        }
        else
        {
            BattleManagers.GetComponent<BattleManager>().JudgeAndUseCard(thisCard.GetComponent<CardDisplay>().card, thisCard.GetComponent<CardDisplay>().card.Id);
            if (BattleManagers.GetComponent<BattleManager>().ProtectCard && thisCard.GetComponent<CardDisplay>().card.Id != 38)
            {
                GameObject returnCard = GameObject.Instantiate(CardPrefab, CardArea.transform);
                returnCard.GetComponent<CardDisplay>().card = thisCard.GetComponent<CardDisplay>().card;
                BattleManagers.GetComponent<BattleManager>().ProtectCard = false;
                BattleManagers.GetComponent<BattleManager>().playerData.PlayerDecks[thisCard.GetComponent<CardDisplay>().card.Id]++;
            }
            BattleManagers.GetComponent<BattleManager>().playerData.PlayerDecks[thisCard.GetComponent<CardDisplay>().card.Id]--;
            BattleManagers.GetComponent<BattleManager>().playerData.SavePlayerData();
            Destroy(thisCard);
        }
    }

}
