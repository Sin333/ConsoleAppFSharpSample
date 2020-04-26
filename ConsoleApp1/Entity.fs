module EntityModule

open System

type User(name: string) =
    member this.Name = name

type Message(date: DateTime, text: string, userName: string) =
    member this.Date = date
    member this.Text = text
    member this.UserName = userName
    
type Chat() =
     let mutable users = ResizeArray<User>()
     let mutable messages = ResizeArray<Message>()
     member this.ConnectUser(user: User) =
         users.Add(user)
         Console.WriteLine("User {0} connected",user.Name)
     member this.DisconnectUser(user: User) =
         users.Remove(user)
         Console.WriteLine("User {0} disconnected",user.Name)
         
     member this.FindUserByName(userName: string) = users.Find(fun x -> x.Name = userName)
     member this.SendMessage(message: Message) =
         messages.Add(message)
         Console.WriteLine("User: " + message.UserName + Environment.NewLine + "Message: " + message.Text)
     
     member this.ShowAllMessages() =
         if (messages.Count > 0)
         then
         (
            Console.WriteLine("All Messages:")
            messages.ForEach (fun message -> Console.WriteLine("- Date: " + message.Date.ToShortDateString() + " Message: " + message.Text + " UserName: " + message.UserName))
         )