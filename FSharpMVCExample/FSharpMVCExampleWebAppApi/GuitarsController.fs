namespace FsWeb.Controllers

open System.Web.Mvc
open FsWeb.Models
open FsWeb.Repositories

//[<HandleError>]
//type GuitarsController() =
//    inherit Controller()
//    
//    member this.Index() =
//        seq {   yield Guitar(Name = "Gibson Les Paul")
//                yield Guitar(Name = "Martin D-28")
//        } |> this.View

[<HandleError>]
type GuitarsController(repository: GuitarsRepository) =
    inherit Controller()

    new() = new GuitarsController(GuitarsRepository())
    member this.Index() =
        repository.GetAll()
        |> this.View

    member this.GetByName name =
        repository.GetByName name
        |> this.View

    member this.GetAllAlphabetic() =
        repository.GetAllAlphabetic()
        |> this.View