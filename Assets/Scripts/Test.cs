// interface IRoom {
//     void OpenLight();
// }

// public class Room : IRoom {

//     Man man;

//     public void Init(Man man) => this.man = man;

//     public void OpenLight() {}
// }

// public class Man {

//     IRoom room;

//     public void Init(IRoom room) => this.room = room;

//     public void EnterRoom() => room.OpenLight();

// }

// public class App {

//     public static void Main(string[] args) {

//         Man man = new Man();
//         Room room = new Room();
//         room.Init(man);
//         man.Init(room);
//         man.EnterRoom();

//     }
// }