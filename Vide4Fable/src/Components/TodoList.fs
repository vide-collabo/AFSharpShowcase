module Components.TodoList

open System
open Vide
open type Vide.Html

type TodoList = { items: TodoItem list }
and TodoItem = { text: string; mutable isDone: bool; key: int }

let view = vide {
    let! todoList = ofMutable {
        { 
            items = 
                [
                    {| text = "Write Vide docu"; isDone = false |}
                    {| text = "Cook new ramen broth"; isDone = false |}
                    {| text = "Stuff that's already done"; isDone = true |}
                    {| text = "Auto-gen Vide Avalonia API"; isDone = true |}
                    {| text = "Fix a Trulla C# codegen bug"; isDone = false |}
                    {| text = "Make a Trulla version for node"; isDone = false |}
                    {| text = "Write a LSP for Trulla templates"; isDone = false |}
                ]
                |> List.mapi (fun i x -> { text = x.text; isDone = x.isDone; key = i })
        }
    }
    
    let setItems items = todoList.Value <- { todoList.Value with items = items }

    h1.class'("title") { "TODO List" }

    div.class'("flex-row") {
        let! itemName = ofMutable {""}

        input.bind(itemName)
        button
            .disabled(String.IsNullOrWhiteSpace(itemName.Value))
            .onclick(fun _ ->
                let nextId = 
                    match  todoList.Value.items |> List.map (fun x -> x.key) |> List.sortDescending with
                    | [] -> 0
                    | x::_ -> x + 1
                let newItem = { text = itemName.Value; isDone = false; key = nextId }
                do setItems (newItem :: todoList.Value.items)
                do itemName.Reset()
            ) 
            {
                "Add Item" 
            }
    }

    div {
        for item in todoList.Value.items |> For.selfKeyed do
            div.class'("flex-row todo-item") {
                input.bind(item.isDone, fun value -> item.isDone <- value)
                button
                    .disabled(not item.isDone)
                    .onclick(fun _ -> setItems (todoList.Value.items |> List.except [item]))
                    {
                        "Remove"
                    }
                p { item.text }
            }
    }
}
