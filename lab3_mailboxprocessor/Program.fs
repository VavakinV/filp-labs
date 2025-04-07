open System

type AgentMessage =
    | Greet of string
    | Calculate of int * int
    | Shutdown

let agent = 
    MailboxProcessor.Start(fun inbox ->
        let rec loop () = 
            async {
                let! msg = inbox.Receive()
                
                match msg with
                | Greet name -> 
                    Console.WriteLine("Привет, {0}!", name)
                    return! loop()
                
                | Calculate (a, b) ->
                    Console.WriteLine("Результат умножения {0} на {1}: {2}", a, b, (a * b))
                    return! loop()
                
                | Shutdown ->
                    Console.WriteLine("Агент завершает работу.")
                    return ()
            }
        loop ()
    )

agent.Post(Greet "Мир")
agent.Post(Calculate(5, 7))
agent.Post(Shutdown)

Threading.Thread.Sleep(1000)