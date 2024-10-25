namespace Feliz.Native


open Fable.React
open Fable.Core
open Fable.Core.JsInterop

[<Erase>]
type Native =
    
    static member inline animatedView (props: IAnimatedViewProperties list): ReactElement =
          Feliz.Interop.reactApi.createElement(import "Animated.View" "react-native", createObj !!props)

    static member inline animatedScrollView (props: IAnimatedScrollViewProperties list): ReactElement =
          Feliz.Interop.reactApi.createElement(import "Animated.ScrollView" "react-native", createObj !!props)

    static member inline animatedImage (props: IAnimatedImageProperties list): ReactElement =
          Feliz.Interop.reactApi.createElement(import "Animated.Image" "react-native", createObj !!props)

    static member inline animatedText (props: IAnimatedTextProperties list): ReactElement =
          Feliz.Interop.reactApi.createElement(import "Animated.Text" "react-native", createObj !!props)

    static member inline view (props: seq<IViewProp>) =
        Feliz.Interop.reactApi.createElement (import "View" "react-native", createObj !!props)
        
    static member inline view (x:#seq<ReactElement>) =
        Feliz.Interop.reactApi.createElement (import "View" "react-native", (createObj [ "children" ==> Feliz.Interop.reactApi.Children.toArray (Array.ofSeq x) ]))
        
    static member inline safeAreaView (props: seq<ISafeAreaViewProp>) =
        Feliz.Interop.reactApi.createElement (import "SafeAreaView" "react-native", createObj !!props)
    
    static member inline keyboardAvoidingView (props: seq<IKeyboardAvoidingViewProp>) =
        Feliz.Interop.reactApi.createElement (import "KeyboardAvoidingView" "react-native", (createObj !!props))

    static member inline stylesheet : obj = (import "StyleSheet" "react-native")
    
    static member inline scrollView (props: seq<IScrollViewProp>) =
        Feliz.Interop.reactApi.createElement (import "ScrollView" "react-native", createObj !!props)
    
    static member inline text (props:seq<ITextProp>) =
        Feliz.Interop.reactApi.createElement (import "Text" "react-native", createObj !!props)
        
    static member inline rawText (x:string): ReactElement = unbox x

    static member inline touchableHighlight (props:seq<ITouchableHighlightProp>) =
        Feliz.Interop.reactApi.createElement (import "TouchableHighlight" "react-native", createObj !!props)
    
    static member inline touchableOpacity (props:seq<ITouchableOpacityProp>) =
        Feliz.Interop.reactApi.createElement (import "TouchableOpacity" "react-native", createObj !!props)
    
    static member inline textInput (props:seq<ITextInputProp>) =
        Feliz.Interop.reactApi.createElement (import "TextInput" "react-native", createObj !!props)
    
    static member inline pressable (props:seq<IPressableProp>) =
        Feliz.Interop.reactApi.createElement (import "Pressable" "react-native", createObj !!props)

    static member inline image (props:seq<IImageProp>) =
        Feliz.Interop.reactApi.createElement (import "Image" "react-native", createObj !!props)
    
    static member inline imageBackground (props:seq<IImageBackgroundProp>) =
        Feliz.Interop.reactApi.createElement (import "ImageBackground" "react-native", createObj !!props)
    
    static member inline activityIndicator (props:seq<IActivityIndicatorProp>) =
        Feliz.Interop.reactApi.createElement (import "ActivityIndicator" "react-native", createObj !!props)
    
    static member inline switch (props:seq<ISwitchProp>) =
        Feliz.Interop.reactApi.createElement (import "Switch" "react-native", createObj !!props)

module Alert =
    type IAlert =
        abstract ``alert`` : (string * string) -> unit
    
    let Alert : IAlert = import "Alert" "react-native"

module Animated =
    type AnimatedValue =
        Animated

    and AnimatedValueXY =
        ValueXY

    and Base =
        Animated

    and [<Import("Animated.Animated","react-native")>] Animated() =
        class end

    and [<Import("Animated.AnimatedWithChildren","react-native")>] AnimatedWithChildren() =
        inherit Animated()


    and [<Import("Animated.AnimatedInterpolation","react-native")>] AnimatedInterpolation() =
        inherit AnimatedWithChildren()
        member __.interpolate(config: InterpolationConfigType): AnimatedInterpolation = jsNative

    and [<StringEnum>] ExtrapolateType =
            | Extend | Identity | Clamp

    and InterpolationConfigType =
        member __.easing(value: float): float = jsNative
        member __.extrapolate with get(): ExtrapolateType = jsNative and set(v: ExtrapolateType): unit = jsNative
        member __.extrapolateLeft with get(): ExtrapolateType = jsNative and set(v: ExtrapolateType): unit = jsNative
        member __.extrapolateRight with get(): ExtrapolateType = jsNative and set(v: ExtrapolateType): unit = jsNative
        member __.inputRange with get() : ResizeArray<float> = jsNative and set(v: ResizeArray<float>): unit = jsNative
        member __.outputRange with get() : U2<ResizeArray<float>, ResizeArray<string>> = jsNative and set(v: U2<ResizeArray<float>, ResizeArray<string>>): unit = jsNative

    and ValueListenerCallback =
        (obj -> unit)

    and [<Import("Animated.Value","react-native")>] Value(value: float) =
        inherit AnimatedWithChildren()
        member __.setValue(value: float): unit = jsNative
        member __.setOffset(offset: float): unit = jsNative
        member __.flattenOffset(): unit = jsNative
        member __.addListener(callback: ValueListenerCallback): string = jsNative
        member __.removeListener(id: string): unit = jsNative
        member __.removeAllListeners(): unit = jsNative
        member __.stopAnimation(?callback: (float -> unit)): unit = jsNative
        member __.interpolate(config: InterpolationConfigType): AnimatedInterpolation = jsNative

    and ValueXYListenerCallback =
        (obj -> unit)

    and [<Import("Animated.ValueXY","react-native")>] ValueXY(?valueIn: obj) =
        inherit AnimatedWithChildren()
        member __.x with get(): AnimatedValue = jsNative and set(v: AnimatedValue): unit = jsNative
        member __.y with get(): AnimatedValue = jsNative and set(v: AnimatedValue): unit = jsNative
        member __.setValue(value: obj): unit = jsNative
        member __.setOffset(offset: obj): unit = jsNative
        member __.flattenOffset(): unit = jsNative
        member __.stopAnimation(?callback: (float -> unit)): unit = jsNative
        member __.addListener(callback: ValueXYListenerCallback): string = jsNative
        member __.removeListener(id: string): unit = jsNative
        member __.getLayout(): obj = jsNative
        member __.getTranslateTransform(): ResizeArray<obj> = jsNative

    and EndResult =
        obj

    and EndCallback =
        (EndResult -> unit)

    and CompositeAnimation =
        abstract start: (EndCallback -> unit) with get, set
        abstract stop: (unit -> unit) with get, set

    and AnimationConfig =
        abstract isInteraction: bool option with get, set
        abstract useNativeDriver: bool option with get, set

    and DecayAnimationConfig =
        inherit AnimationConfig
        abstract velocity: obj with get, set
        abstract deceleration: float option with get, set

    and TimingAnimationConfig =
        inherit AnimationConfig
        abstract toValue: U4<float, AnimatedValue, obj, AnimatedValueXY> with get, set
        abstract easing: (float -> float) option with get, set
        abstract duration: float option with get, set
        abstract delay: float option with get, set

    and SpringAnimationConfig =
        inherit AnimationConfig
        abstract toValue: U4<float, AnimatedValue, obj, AnimatedValueXY> with get, set
        abstract overshootClamping: bool option with get, set
        abstract restDisplacementThreshold: float option with get, set
        abstract restSpeedThreshold: float option with get, set
        abstract velocity: obj option with get, set
        abstract bounciness: float option with get, set
        abstract speed: float option with get, set
        abstract tension: float option with get, set
        abstract friction: float option with get, set

    and [<Import("Animated.AnimatedAddition","react-native")>] AnimatedAddition() =
        inherit AnimatedInterpolation()


    and [<Import("Animated.AnimatedMultiplication","react-native")>] AnimatedMultiplication() =
        inherit AnimatedInterpolation()


    and [<Import("Animated.AnimatedModulo","react-native")>] AnimatedModulo() =
        inherit AnimatedInterpolation()

    and ParallelConfig =
        obj

    and Mapping =
        obj //U2<obj, AnimatedValue>

    and EventConfig =
        abstract listener: obj option with get, set

    // and AnimatedViewStatic =
    //     inherit ViewStatic
    //
    // and AnimatedScrollViewStatic =
    //     inherit ScrollViewStatic
    //
    // and AnimatedImageStatic =
    //     inherit ImageStatic
    //
    // and AnimatedTextStatic =
    //     inherit TextStatic

    type [<Import("Animated","react-native")>] Globals =
        static member timing with get(): (U2<AnimatedValue, AnimatedValueXY> -> TimingAnimationConfig -> CompositeAnimation) = jsNative and set(v: (U2<AnimatedValue, AnimatedValueXY> -> TimingAnimationConfig -> CompositeAnimation)): unit = jsNative
        static member spring with get(): (U2<AnimatedValue, AnimatedValueXY> -> SpringAnimationConfig -> CompositeAnimation) = jsNative and set(v: (U2<AnimatedValue, AnimatedValueXY> -> SpringAnimationConfig -> CompositeAnimation)): unit = jsNative
        static member ``parallel`` with get(): (ResizeArray<CompositeAnimation> -> ParallelConfig -> CompositeAnimation) = jsNative and set(v: (ResizeArray<CompositeAnimation> -> ParallelConfig -> CompositeAnimation)): unit = jsNative
        static member ``event`` with get(): (ResizeArray<Mapping> -> EventConfig -> (obj -> unit)) = jsNative and set(v: (ResizeArray<Mapping> -> EventConfig -> (obj -> unit))): unit = jsNative
        // static member View with get(): AnimatedViewStatic = jsNative and set(v: AnimatedViewStatic): unit = jsNative
        // static member ScrollView with get(): AnimatedScrollViewStatic = jsNative and set(v: AnimatedScrollViewStatic): unit = jsNative
        // static member Image with get(): AnimatedImageStatic = jsNative and set(v: AnimatedImageStatic): unit = jsNative
        // static member Text with get(): AnimatedTextStatic = jsNative and set(v: AnimatedTextStatic): unit = jsNative
        static member decay(value: U2<AnimatedValue, AnimatedValueXY>, config: DecayAnimationConfig): CompositeAnimation = jsNative
        static member add(a: Animated, b: Animated): AnimatedAddition = jsNative
        static member multiply(a: Animated, b: Animated): AnimatedMultiplication = jsNative
        static member modulo(a: Animated, modulus: float): AnimatedModulo = jsNative
        static member delay(time: float): CompositeAnimation = jsNative
        static member sequence(animations: ResizeArray<CompositeAnimation>): CompositeAnimation = jsNative
        static member stagger(time: float, animations: ResizeArray<CompositeAnimation>): CompositeAnimation = jsNative

module AppState =
    type IEventSubscription =
        abstract ``remove`` : unit -> unit

    type IAppState =
        abstract ``currentState`` : string option with get, set
        abstract ``addEventListener`` : string * (string -> unit) -> IEventSubscription

    let AppState : IAppState = import "AppState" "react-native"

module Dimensions =
    type DimensionsInfo = {
        ``fontScale`` : int 
        ``height`` : int
        ``scale`` : int
        ``width`` : int
    }

    let useWindowDimensions : unit -> DimensionsInfo = import "useWindowDimensions" "react-native"

    type IDimensions =
        abstract ``get`` : string -> DimensionsInfo
    
    let Dimensions : IDimensions = import "Dimensions" "react-native"

module Keyboard =
    type IKeyboard = 
        abstract ``dismiss`` : unit -> unit
        abstract ``isVisible`` : unit -> bool

    let Keyboard : IKeyboard = import "Keyboard" "react-native"

module Linking =

    type ILinking =
        abstract member canOpenURL : string -> JS.Promise<bool>
        abstract member getInitialURL : unit -> JS.Promise<string option>
        abstract member openSettings : unit -> unit
        abstract member openURL<'a> : string -> JS.Promise<'a>

    let Linking : ILinking = import "Linking" "react-native"

module PanResponder =
    type IPanResponder =
        [<Emit("Object.entries($0.panHandlers)")>]
        abstract member panHandlers : IViewProp seq

    type IPanResponderStatic =
        abstract ``create`` : obj -> IPanResponder

    let PanResponder : IPanResponderStatic = import "PanResponder" "react-native"

module PermissionsAndroid =

    module Permissions =
        [<Literal>]
        let READ_CALENDAR = "android.permission.READ_CALENDAR"
        [<Literal>]
        let WRITE_CALENDAR = "android.permission.WRITE_CALENDAR"
        [<Literal>]
        let CAMERA = "android.permission.CAMERA"
        [<Literal>]
        let READ_CONTACTS = "android.permission.READ_CONTACTS"
        [<Literal>]
        let WRITE_CONTACTS = "android.permission.WRITE_CONTACTS"
        [<Literal>]
        let GET_ACCOUNTS = "android.permission.GET_ACCOUNTS"
        [<Literal>]
        let ACCESS_FINE_LOCATION = "android.permission.ACCESS_FINE_LOCATION"
        [<Literal>]
        let ACCESS_COARSE_LOCATION = "android.permission.ACCESS_COARSE_LOCATION"
        [<Literal>]
        let ACCESS_BACKGROUND_LOCATION = "android.permission.ACCESS_BACKGROUND_LOCATION"
        [<Literal>]
        let RECORD_AUDIO = "android.permission.RECORD_AUDIO"
        [<Literal>]
        let READ_PHONE_STATE = "android.permission.READ_PHONE_STATE"
        [<Literal>]
        let READ_EXTERNAL_STORAGE = "android.permission.READ_EXTERNAL_STORAGE"
        [<Literal>]
        let WRITE_EXTERNAL_STORAGE = "android.permission.WRITE_EXTERNAL_STORAGE"
        [<Literal>]
        let POST_NOTIFICATIONS = "android.permission.POST_NOTIFICATIONS"
        [<Literal>]
        let NEARBY_WIFI_DEVICES = "android.permission.NEARBY_WIFI_DEVICES"
    
    module Results =
        [<Literal>]
        let GRANTED = "granted"

        [<Literal>]
        let DENIED = "denied"

        [<Literal>]
        let NEVER_ASK_AGAIN = "never_ask_again"

    type IPermissionsAndroid =
        abstract member check : string -> JS.Promise<bool>
        abstract member request : string * obj -> JS.Promise<string>
        abstract member request : string -> JS.Promise<string>
    
    let PermissionsAndroid : IPermissionsAndroid = import "PermissionsAndroid" "react-native"

module Platform =
    type IPlatform =
        abstract ``select``<'a> : obj -> 'a
    
    let Platform : IPlatform = import "Platform" "react-native"

