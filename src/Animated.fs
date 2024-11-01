namespace Feliz.Native

open Fable.Core

// see node_modules/react-native/Libraries/Animated/Animated.d.ts
module Animated =

    type AnimatedValue = Animated

    and AnimatedValueXY = ValueXY

    and Base = Animated

    and [<Import("Animated.Animated", "react-native")>] Animated() = class end

    and [<Import("Animated.AnimatedWithChildren", "react-native")>] AnimatedWithChildren() =
        inherit Animated()


    and [<Import("Animated.AnimatedInterpolation", "react-native")>] AnimatedInterpolation() =
        inherit AnimatedWithChildren()
        member __.interpolate(config: InterpolationConfigType) : AnimatedInterpolation = jsNative

    and [<StringEnum>] ExtrapolateType =
        | Extend
        | Identity
        | Clamp

    //TODO: convert to abstract jsOptions obj
    and InterpolationConfigType
        [<ParamObject; Emit("$0")>]
        (
            ?easing: float,
            ?extrapolate: ExtrapolateType,
            ?extrapolateLeft: ExtrapolateType,
            ?extrapolateRight: ExtrapolateType,
            ?inputRange: ResizeArray<float>,
            ?outputRange: U2<ResizeArray<float>, ResizeArray<string>>
        ) =
        member val easing: float = jsNative
        member val extrapolate = jsNative with get, set
        member val extrapolateLeft: ExtrapolateType = jsNative with get, set
        member val extrapolateRight: ExtrapolateType = jsNative with get, set
        member val inputRange: ResizeArray<float> = jsNative with get, set
        member val outputRange: U2<ResizeArray<float>, ResizeArray<string>> = jsNative with get, set

    and ValueListenerCallback = (obj -> unit)

    and [<Import("Animated.Value", "react-native")>] Value(value: float) =
        inherit AnimatedWithChildren()
        member __.setValue(value: float) : unit = jsNative
        member __.setOffset(offset: float) : unit = jsNative
        member __.flattenOffset() : unit = jsNative
        member __.addListener(callback: ValueListenerCallback) : string = jsNative
        member __.removeListener(id: string) : unit = jsNative
        member __.removeAllListeners() : unit = jsNative
        member __.stopAnimation(?callback: (float -> unit)) : unit = jsNative
        member __.interpolate(config: InterpolationConfigType) : AnimatedInterpolation = jsNative

    and ValueXYListenerCallback = (obj -> unit)

    and [<Import("Animated.ValueXY", "react-native")>] ValueXY(?valueIn: obj) =
        inherit AnimatedWithChildren()

        member __.x
            with get (): AnimatedValue = jsNative
            and set (v: AnimatedValue): unit = jsNative

        member __.y
            with get (): AnimatedValue = jsNative
            and set (v: AnimatedValue): unit = jsNative

        member __.setValue(value: obj) : unit = jsNative
        member __.setOffset(offset: obj) : unit = jsNative
        member __.flattenOffset() : unit = jsNative
        member __.stopAnimation(?callback: (float -> unit)) : unit = jsNative
        member __.addListener(callback: ValueXYListenerCallback) : string = jsNative
        member __.removeListener(id: string) : unit = jsNative
        member __.getLayout() : obj = jsNative
        member __.getTranslateTransform() : ResizeArray<obj> = jsNative

    and EndResult = obj

    and EndCallback = (EndResult -> unit)

    and CompositeAnimation =
        abstract start: ?onEnd: EndCallback -> unit
        abstract stop: (unit -> unit)

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

    and [<Import("Animated.AnimatedAddition", "react-native")>] AnimatedAddition() =
        inherit AnimatedInterpolation()


    and [<Import("Animated.AnimatedMultiplication", "react-native")>] AnimatedMultiplication() =
        inherit AnimatedInterpolation()


    and [<Import("Animated.AnimatedModulo", "react-native")>] AnimatedModulo() =
        inherit AnimatedInterpolation()

    and ParallelConfig = obj

    and Mapping = obj //U2<obj, AnimatedValue>

    and EventConfig =
        abstract listener: obj option with get, set
        abstract useNativeDriver: bool option with get, set

    [<Import("Animated", "react-native")>]
    type Globals =
        static member timing
            (value: U2<AnimatedValue, AnimatedValueXY>, config: TimingAnimationConfig)
            : CompositeAnimation =
            jsNative

        static member timing(value: AnimatedValue, config: TimingAnimationConfig) : CompositeAnimation = jsNative

        static member spring
            (value: U2<AnimatedValue, AnimatedValueXY>, config: SpringAnimationConfig)
            : CompositeAnimation =
            jsNative

        static member ``parallel``
            (animations: ResizeArray<CompositeAnimation>, config: ParallelConfig)
            : CompositeAnimation =
            jsNative

        static member ``event``(argMapping: ResizeArray<Mapping>, ?config: EventConfig) : (obj -> unit) = jsNative

        static member decay
            (value: U2<AnimatedValue, AnimatedValueXY>, config: DecayAnimationConfig)
            : CompositeAnimation =
            jsNative

        static member add(a: Animated, b: Animated) : AnimatedAddition = jsNative
        static member multiply(a: Animated, b: Animated) : AnimatedMultiplication = jsNative
        static member modulo(a: Animated, modulus: float) : AnimatedModulo = jsNative
        static member delay(time: float) : CompositeAnimation = jsNative
        static member sequence(animations: ResizeArray<CompositeAnimation>) : CompositeAnimation = jsNative
        static member stagger(time: float, animations: ResizeArray<CompositeAnimation>) : CompositeAnimation = jsNative
