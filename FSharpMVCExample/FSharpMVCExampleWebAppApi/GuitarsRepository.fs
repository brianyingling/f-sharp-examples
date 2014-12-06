namespace FsWeb.Repositories

open FsWeb.Models

type GuitarsRepository() =
    member x.GetAll() =
        use context = new FsMvcAppEntities()
        query { for g in context.Guitars do  
                select g }
        |> Seq.toList

    member x.GetByName name =
        use context = new FsMvcAppEntities()
        query {for g in context.Guitars do
               where(g.Name = name)}
        |> Seq.toList

    member x.GetAllAlphabetic() =
        use context = new FsMvcAppEntities() 
        query {for g in context.Guitars do
                sortBy g.Name}
        |> Seq.toList
       
    member x.GetTop rowCount =
        use context = new FsMvcAppEntities()
        query {for g in context.Guitars do 
               take rowCount}


