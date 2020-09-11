using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class StartGame : MonoBehaviourPunCallbacks
{
    public GameObject _prefab;

    public Camera maincamera;

    private void AwakePlayer()
    {
        Camera mc = Camera.main;
        GameObject forklift = null;
        if (PhotonNetwork.CurrentRoom.PlayerCount==1)
        {
            Vector3 position = new Vector3(-43f, 21.42103f, -0.75f);
            Quaternion q = new Quaternion(0, 30, 0, 20);
            forklift = MasterManager.NetworkInstantiate(_prefab, position, q);
        }
        else
        {
            Vector3 position = new Vector3(-11f, 21.42103f, -20f);
            Quaternion q = new Quaternion(0, -30, 0, 120);
            forklift = MasterManager.NetworkInstantiate(_prefab, position, q);
        }

        foreach (var cam in Camera.allCameras)
        {
            if (cam.tag != "MainCamera")
                cam.enabled = false;
        }
        maincamera.enabled = true;



        //GameObject cam1 = Application.find GameObject.fin .FindWithTag("MainCamera");


    }

    private void Start(){
        print ("Connecting to server.");
        PhotonNetwork.NickName = "Gracz-" + UnityEngine.Random.Range(0, 9999).ToString();
        PhotonNetwork.GameVersion = "1.0";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster(){
        print("Connected to server.");
        print(PhotonNetwork.LocalPlayer.NickName);
        PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(Photon.Realtime.DisconnectCause cause){
        print("Disconnected from server, for reason: " + cause.ToString());
        print(PhotonNetwork.LocalPlayer.NickName);
    }

    public override void OnJoinedLobby()
    {
        print("Joined lobby.");
        JoinOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        print("Joined room.");
        AwakePlayer();
    }

    public override void OnRoomListUpdate(List<Photon.Realtime.RoomInfo> roomList)
    {
        Debug.Log("  OnRoomListUpdate - number of rooms: " + PhotonNetwork.CountOfRooms);
        Debug.Log("  OnRoomListUpdate - list of rooms:");
        foreach(RoomInfo info in roomList){
            Debug.Log("  " + info.Name);
        }
    }


    public void JoinOrCreateRoom(){
        RoomOptions roomOptions = new RoomOptions{MaxPlayers = 14};
        Debug.Log("JoinOrCreateRoom: Pokój-1");
        PhotonNetwork.JoinOrCreateRoom("Pokój-1", roomOptions, TypedLobby.Default);
    }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            Debug.Log(" Create room failed: " + message);
        }

    private void GetCurrentRoomPlayers()
    {
        Debug.Log("List of players ");
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Debug.Log("  " + newPlayer.NickName + " has entered the room " + PhotonNetwork.CurrentRoom.Name);    
    }


    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
        Debug.Log("  " + otherPlayer.NickName + " has left the room " + PhotonNetwork.CurrentRoom.Name);        
        GetCurrentRoomPlayers();
    }



}
