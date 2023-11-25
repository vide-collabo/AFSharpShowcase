
#r "nuget: Avalonia, 11.0.0"
#r "nuget: Avalonia.Desktop, 11.0.0"
#r "nuget: Avalonia.Themes.Fluent, 11.0.0"

#r "nuget: Vide.UI.Avalonia.Interactive"
#r "nuget: Vide.UI.Avalonia"

open System
open Vide
open Vide.UI.Avalonia
open type Vide.UI.Avalonia.Controls
open type Vide.UI.Avalonia.AvaloniaControlsDefaults

Interactive.guardInit ()
// ^ -------------------------------------------------------------
// |_ This is the boilerplate to make the sample work in fsi.
//    Evaluate this _once and separate_ from the rest of the sample.
// ---------------------------------------------------------------


let window = Interactive.createWindow 300. 500.



let view = vide {
    let! count = ofMutable {0}
    
    let add value = count.Value <- count.Value + value
    
    StackPanel
        .VerticalAlignment(VA.Top)
        .Orientation(Orientation.Horizontal)
        .Margin(10)
        {
            Button
                .Click(fun _ -> add -1) { "-" }
            Button
                .Click(fun _ -> add 1) { "+" }

            TextBlock
                .Margin(Thickness(10., 0., 0., 0.))
                .VerticalAlignment(VA.Center)
                .Text($"Count: {count.Value}")
    }
}

Interactive.showView view window
