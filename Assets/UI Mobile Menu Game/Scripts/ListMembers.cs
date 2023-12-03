using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListMembers : MonoBehaviour
{
    public List<MembersList> membersList = new List<MembersList>();
    public GameObject NormalPrefab;
    public Transform Content;

    public enum Selection { Challenge, SendGift, ReceiveGift, Ranking}; //Will be used to keep track of what's selected
    

    [System.Serializable]
    public class MembersList
    {
        [HideInInspector] public int id;
        public string Login;
        public Sprite avatar;
        public int Level;
        public Selection type;
        public int rank;
        public int totalWins;
        public string Gain;
        [HideInInspector] public GameObject Prefab;
    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < membersList.Count; i++)
        {
            GameObject Member = Instantiate(NormalPrefab);
            Member.transform.SetParent(Content);
            Member.transform.localScale = Vector3.one;

            membersList[i].id = i;
            membersList[i].Prefab = Member;

            if (membersList[i].type == Selection.Challenge)
            {
                Member.GetComponent<InitMemberList>().PrefabForChallenge(membersList[i].Login, membersList[i].Level, membersList[i].avatar);
            }
            else if (membersList[i].type == Selection.SendGift)
            {
                Member.GetComponent<InitMemberList>().PrefabForSendGift(membersList[i].Login, "send free coins to your friend!", membersList[i].avatar);
            }
            else if (membersList[i].type == Selection.ReceiveGift)
            {
                Member.GetComponent<InitMemberList>().PrefabForAcceptGift(membersList[i].Login, "Send you 150<sprite=1>!", membersList[i].avatar);
            }
            else if (membersList[i].type == Selection.Ranking)
            {
                Member.GetComponent<InitMemberList>().PrefabForRanking(this, membersList[i].id, membersList[i].Login, membersList[i].Level, membersList[i].Gain, membersList[i].rank, membersList[i].avatar);
            }
        }
    }
}
