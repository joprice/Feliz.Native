module Sample

open Feliz
open Feliz.Native

let x =
    Native.view
        [ view.children
              [ Native.keyboardAvoidingView [ keyboardAvoidingView.style [] ]
                Native.animatedView [ animatedView.style [] ]
                Native.animatedText [ animatedText.style [] ]
                Native.text [ text.style [ style.flex 1 ] ] ] ]
