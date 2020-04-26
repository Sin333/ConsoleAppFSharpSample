module MenuModule

open System
open EntityModule
type MenuCommands =
    | GetListCommand = 0
    | ConnectUser = 1
    | DisconnectUser = 2
    | SendMessage = 3
    | GetMessages = 4

type Menu() =
    static member GetListCommands() =
            Console.WriteLine("List commands:")
            Console.WriteLine("-----------------------------------------------")
            for menu in Enum.GetNames(enumType = typeof<MenuCommands>) do
                Console.WriteLine(menu)
            Console.WriteLine("-----------------------------------------------")
                
    member this.RunCommand(command :MenuCommands, chat : Chat) =
            match command with
            | MenuCommands.ConnectUser -> this.ConnectUser(chat)
            | MenuCommands.DisconnectUser -> this.DisconnectUser(chat)
            | MenuCommands.SendMessage -> this.SendMessage(chat)
            | MenuCommands.GetMessages -> chat.ShowAllMessages()
            | MenuCommands.GetListCommand -> Menu.GetListCommands()
            
    member private this.ConnectUser(chat :Chat) =
                Console.WriteLine("Enter UserName")
                let userName = Console.ReadLine()
                let user = User(userName)
                chat.ConnectUser(user)
    member private this.DisconnectUser(chat :Chat) =
                Console.WriteLine("Enter UserName")
                let userName = Console.ReadLine()
                let user = chat.FindUserByName(userName)
                if (box<Object> user = null) then Console.WriteLine("User not found")
                else chat.DisconnectUser(user)
    member private this.SendMessage(chat :Chat) =
                Console.WriteLine("Enter UserName")
                let userName = Console.ReadLine()
                Console.WriteLine("Enter text")
                let text = Console.ReadLine()
                let user = chat.FindUserByName(userName)
                if (box<Object> user = null) then Console.WriteLine("User not found")
                else chat.SendMessage(Message(DateTime.Now, text, userName))