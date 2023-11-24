
#r "nuget: Avalonia, 11.0.0"
#r "nuget: Avalonia.Desktop, 11.0.0"
#r "nuget: Avalonia.Themes.Fluent, 11.0.0"

#r "nuget: Vide.UI.Avalonia.Interactive"
#r "nuget: Vide.UI.Avalonia"


open System
open Vide
open Vide.UI.Avalonia
open Vide.UI.Avalonia.Interactive.Dynamic
open type Vide.UI.Avalonia.Controls
open type Vide.UI.Avalonia.AvaloniaControlsDefaults

Interactive.guardInit ()
// ^ -------------------------------------------------------------
// |_ This is the boilerplate to make the sample work in fsi.
//    Evaluate this _once and separate_ from the rest of the sample.
// ---------------------------------------------------------------




let view = vide {
    let! count = ofMutable {0}
    
    StackPanel
        .VerticalAlignment(VA.Top)
        .Orientation(Orientation.Horizontal)
        .Margin(10)
        {
            Button
                .Click(fun _ -> count.Value <- count.Value - 1) { "-" }
            Button
                .Click(fun _ -> count.Value <- count.Value + 1) { "+" }

            TextBlock
                .Margin(Thickness(10., 0., 0., 0.))
                .Text("Count: ")
            TextBlock
                .Text(count.Value.ToString())
    }
}


let window = Interactive.createWindow 300. 500.
Interactive.showView view window
