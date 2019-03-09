using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UtilMethods;
using System.Linq;

namespace UtilMethods {
  public static class MyUtils {

    public static T GetRandomValue<T>(this T[] array) {
      return array[Random.Range(0, array.Length)];
    }

    public static T GetRandomValue<T>(this List<T> list) {
      return list[Random.Range(0, list.Count)];
    }
  }
}

public class Rooms
{
    public List<string> LRB { get; set; }
    public List<string> LR { get; set; }
}

public class RoomController
{
    Rooms rooms { get; set; }

    public RoomController() {
        TextAsset serializeRoomData = Resources.Load("roomData") as TextAsset;
        rooms = JsonConvert.DeserializeObject<Rooms>(serializeRoomData.text);
        Debug.Log(rooms.LRB);
    }

    public List<string> GetRooms(string roomName) {
        switch(roomName) {
            case "LRB":
                return rooms.LRB;
            case "LR": 
                return rooms.LR;
            default:
                return new List<string>();
        }
    }

    public List<string> GetRoom(string roomName) {
        string room = GetRooms(roomName).GetRandomValue();
        return room.Split(',').ToList();
    }



}


