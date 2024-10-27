module Sample

open Feliz
open Feliz.Native
open Fable.Core
open JsInterop

let value = new Animated.Value(0)

let interpolated =
  value.interpolate (
    Animated.InterpolationConfigType(
      inputRange = ResizeArray [| 0.0; 1.0 |],
      outputRange = !^(ResizeArray [| 1.0; 0.99 |])
    )
  )

let x =
  let anim =
    Animated.Globals.timing (
      value,
      jsOptions<Animated.TimingAnimationConfig> (fun o ->
        o.toValue <- !^(1)
        o.duration <- Some 100
        o.isInteraction <- Some true
        o.useNativeDriver <- Some false)
    )

  anim.start ()

  Native.view [
    view.style [ style.paddingTop 10 ]
    view.children [
      Native.keyboardAvoidingView [ keyboardAvoidingView.style [] ]
      Native.animatedView [ animatedView.style [] ]
      Native.animatedText [ animatedText.style [] ]
      Native.text [
        text.style [
          style.flex 1
          style.transform [ transform.translateY (20) ]
          style.transform [|
            transforms.perspective (45)
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

            transforms.scale interpolated
            transforms.scaleX interpolated
            transforms.scaleY interpolated
            transforms.translateX interpolated
            transforms.translateY interpolated
            transforms.skewX interpolated
            transforms.skewY interpolated
          |]
        ]
      ]
    ]
  ]
