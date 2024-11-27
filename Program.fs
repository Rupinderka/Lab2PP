type Coach = { Name: string; FormerPlayer: bool }
type Stats = { Wins: int; Losses: int }
type Team = { Name: string; Coach: Coach; Stats: Stats }

let teams = [
    { Name = "Celtics"; Coach = { Name = "Joe Mazzulla"; FormerPlayer = false }; Stats = { Wins = 15; Losses = 3 } }
    { Name = "Bulls"; Coach = { Name = "Billy Donovan"; FormerPlayer = false }; Stats = { Wins = 8; Losses = 11 } }
    { Name = "Cavaliers"; Coach = { Name = "Kenny Atkinson"; FormerPlayer = false }; Stats = { Wins = 17; Losses = 1 } }
    { Name = "Warriors"; Coach = { Name = "Steve Kerr"; FormerPlayer = true }; Stats = { Wins = 12; Losses = 5 } }
    { Name = "Knicks"; Coach = { Name = "Tom Thibodeau"; FormerPlayer = false }; Stats = { Wins = 10; Losses = 7 } }
]

let successfulTeams = 
    teams 
    |> List.filter (fun team -> team.Stats.Wins > team.Stats.Losses)

let teamsWithSuccessPercentage = 
    teams 
    |> List.map (fun team ->
        let totalGames = float (team.Stats.Wins + team.Stats.Losses)
        let successPercentage = (float team.Stats.Wins / totalGames) * 100.0
        (team.Name, successPercentage))

printfn "Successful Teams:"
successfulTeams |> List.iter (fun team -> printfn "%s" team.Name)

printfn "\nTeams with Success Percentage:"
teamsWithSuccessPercentage |> List.iter (fun (name, percentage) ->
    printfn "%s: %.2f%%" name percentage)
