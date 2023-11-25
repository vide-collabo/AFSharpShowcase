
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


















let view = vide {
    TextBlock.Text("Hello World!")
}





let window = 
    Interactive.createWindow 300. 500.
    |> fun window -> window.Topmost <- true; window

Interactive.showView view window
