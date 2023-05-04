using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField roomNameInput;

    public void CreateRoom(){
        PhotonNetwork.CreateRoom(roomNameInput.text);
    }

    public void JoinRoom(){
        PhotonNetwork.JoinRoom(roomNameInput.text);
    }

    public override void OnJoinedRoom(){
        PhotonNetwork.LoadLevel("MainPlay");
    }
}
