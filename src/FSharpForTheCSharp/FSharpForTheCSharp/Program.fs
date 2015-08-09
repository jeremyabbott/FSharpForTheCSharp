open Owin

open System.Collections.Generic
open System.Net.Http
open System.Web.Http
open Microsoft.Owin.Hosting
open DisappointinglyAttributed

let formatUrl = sprintf "%s/%s" //function that accepts two strings...

[<``(╯°□°）╯︵┻━┻Attribute``>] // If you use the backtic you can use special characters...
type Startup() = // Start of class declaration
    member this.Configuration(appBuilder : IAppBuilder) = // type annotation
        let config = new  HttpConfiguration()
        let route = config.Routes.MapHttpRoute("DefaultApi","api/{controller}/{id}")
        route.Defaults.Add("id", RouteParameter.Optional)
        appBuilder.UseWebApi(config) |> ignore // what are we ignoring?

[<``┬──┬ノ(゜-゜ノ)Attribute``>]
type ValuesController() =
    inherit ApiController()
    member this.Get() = // this is an action
        [|"value1"; "value2"|] // string[]

[<``¯|_(ツ)_|¯``>]
[<EntryPoint>] // this is an attribute
let main argv = 
    let baseAddress = "http://localhost:9000"

    // the use binding will dispose of server when we go out of scope.
    use server = WebApp.Start<Startup>(baseAddress)
    use client = new HttpClient() // only need to use the new keyword with IDisposable types
    let response = // mixing a tupled method call with an F# function call
        client.GetAsync(formatUrl baseAddress "api/values").Result
    printfn "%A" response // response is some object so %A just formats any object
    // we're getting a string back so the format argument is %s
    printfn "%s" (response.Content.ReadAsStringAsync().Result)
    0 // return an integer exit code