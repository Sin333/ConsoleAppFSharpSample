module ConsoleApp1

open System
open EntityModule
open MenuModule

[<EntryPoint>]
let main argv =
    let chat = Chat()
    let menu = Menu()
    let isRunProgram = true
    while isRunProgram do
        (
            Menu.GetListCommands()
            Console.Write("Enter you command: ")
            let enterText = Console.ReadLine()
            let isParsed, menuCommand = Enum.TryParse(enterText, true)
            if not(isParsed) then menuCommand = MenuCommands.GetListCommand |> ignore
            menu.RunCommand(menuCommand, chat)
            
//            uncomment next code block if u don't want use this fuctionality 
//            let isRepeatCommand = true
//            while isRepeatCommand do
//                (
//                 Console.WriteLine("Do u want run other command and continue program? (Y/N)")
//                 let keyInfo = Console.ReadKey()
//                 Console.WriteLine()
//                 match keyInfo.Key with
//                 | ConsoleKey.Y ->
//                     isRepeatCommand = false
//                     Console.WriteLine("Ok, let's go!")
//                 | ConsoleKey.N ->
//                     isRepeatCommand = false
//                     isRunProgram = false
//                     |> ignore
//                 | _ ->
//                     Console.WriteLine("Try again")
//                )
        )
    0 // return an integer exit code