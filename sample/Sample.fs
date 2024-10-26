module Sample

open Feliz
open Feliz.Native

let x =
  Native.view [
    view.children [
      Native.keyboardAvoidingView [ keyboardAvoidingView.style [] ]
      Native.animatedView [ animatedView.style [] ]
      Native.animatedText [ animatedText.style [] ]
      Native.text [
        text.style [
          style.flex 1
          style.transform [ transform.translateY (20) ]
          style.transform [|
            transforms.rotate (length.deg 45)
            transforms.rotateX (length.deg 45)
            transforms.rotateY (length.deg 45)
            transforms.rotateZ (length.rad 0.785)
            transforms.scale (45)
            transforms.scaleX (45)
            transforms.scaleY (45)
            transforms.translateX (20)
            transforms.translateY (20)
            transforms.skewX (20)
            transforms.skewY (20)
          |]
        ]
      ]
    ]
  ]
