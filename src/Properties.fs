namespace Feliz.Native

open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Feliz

[<Erase>] type IViewProp = interface end
[<Erase>] type IImageProp = interface end
[<Erase>] type IImageBackgroundProp = interface end
[<Erase>] type IKeyboardAvoidingViewProp = interface end
[<Erase>] type ISafeAreaViewProp = interface end
[<Erase>] type IScrollViewProp = interface end
[<Erase>] type ITextProp = interface end
[<Erase>] type ITextInputProp = interface end
[<Erase>] type ITouchableHighlightProp = interface end
[<Erase>] type ITouchableOpacityProp = interface end
[<Erase>] type IPressableProp = interface end
[<Erase>] type IActivityIndicatorProp = interface end
[<Erase>] type ISwitchProp = interface end

type length =
    inherit Feliz.length
    static member inline dip (value: double): Feliz.Styles.ICssUnit = unbox ((unbox<string>value))
    static member inline dip (value: int): Feliz.Styles.ICssUnit = unbox ((unbox<string>value))

type style =
    inherit Feliz.style
    static member inline borderTopLeftRadius (x:int): IStyleAttribute = Interop.mkStyle "borderTopLeftRadius" x
    static member inline borderTopRightRadius (x:int): IStyleAttribute = Interop.mkStyle "borderTopRightRadius" x
    static member inline borderBottomLeftRadius (x:int): IStyleAttribute = Interop.mkStyle "borderBottomLeftRadius" x
    static member inline borderBottomRightRadius (x:int): IStyleAttribute = Interop.mkStyle "borderBottomRightRadius" x
    
    static member inline flex (x:float): IStyleAttribute = Interop.mkStyle "flex" x
    static member inline shadowRadius (x:int): IStyleAttribute = Interop.mkStyle "shadowRadius" x
    static member inline shadowRadius (x:float): IStyleAttribute = Interop.mkStyle "shadowRadius" x
    static member inline shadowOpacity (x:float): IStyleAttribute = Interop.mkStyle "shadowOpacity" x
    static member inline shadowOffset (x:{|width:int; height:int|}): IStyleAttribute = Interop.mkStyle "shadowOffset" x
    static member inline shadowColor (x:string): IStyleAttribute = Interop.mkStyle "shadowColor" x
    
[<Erase>]
type Prop<'a> =
    static member inline attribution (value: string): 'a = unbox<'a> ("attribution", value)
    // static member inline ref (value: (obj -> unit)): 'a = unbox<'a> ("ref", value)
    static member inline key (value: string): 'a = unbox<'a> ("key", value)
    static member inline key (value: int): 'a = unbox<'a> ("key", value)
    static member inline custom (key: string, value: obj): 'a = unbox<'a> (key, value)
    static member inline style (x:seq<Feliz.IStyleAttribute>): 'a = unbox<'a> !!("style", keyValueList CaseRules.LowerFirst x)
    static member inline onLayout (x:obj -> unit): 'a = unbox<'a>("onLayout", x)
    static member inline children (elements: ReactElement list): 'a = unbox<'a> (Feliz.prop.children elements)

module Types =
    type PressEvent = {
        changedTouches: PressEvent []
        force : float option
        identifier: float
        locationX: float
        locationY: float
        pageX: float
        pageY: float
        target: float option
        timestamp: float
        touches: PressEvent []
    }

    type Layout = {
        width : float
        height : float
        x : float
        y : float
    }

    type LayoutEvent = {
        layout : Layout
        target : int
    }

    type Point = {x:float; y:float}

    type Rect = {
        bottom : float option
        left : float option
        right : float option
        top : float option
    }

[<Erase>]
type activityIndicator =
    inherit Prop<IActivityIndicatorProp>
    static member inline animating (x:bool): IActivityIndicatorProp = unbox ("animating", x)
    static member inline color (x:string): IActivityIndicatorProp = unbox ("color", x)
    static member inline small x: IActivityIndicatorProp = unbox ("size", "small")
    static member inline large x: IActivityIndicatorProp = unbox ("size", "large")
    static member inline size (x:string): IActivityIndicatorProp = unbox ("size", x)


[<Erase>]
type image =
    inherit Prop<IImageProp>
    static member inline accessibilityLabel (x:string): IImageProp = unbox ("accessibilityLabel", x)
    static member inline alt (x:string): IImageProp = unbox ("alt", x)
    static member inline blurRadius (x:float): IImageProp = unbox ("blurRadius", x)
    static member inline blurRadius (x:int): IImageProp = unbox ("blurRadius", x)
    static member inline fadeDuration (x:float): IImageProp = unbox ("fadeDuration", x)
    static member inline fadeDuration (x:int): IImageProp = unbox ("fadeDuration", x)
    static member inline height (x:int): IImageProp = unbox ("height", x)
    static member inline onError (x:obj -> unit): IImageProp = unbox ("onError", x)
    static member inline onLayout (x:obj -> unit): IImageProp = unbox ("onLayout", x)
    static member inline onLayout (x:Types.LayoutEvent -> unit): IImageProp = unbox ("onLayout", x)
    static member inline onLoad (x:obj -> unit): IImageProp = unbox ("onLoad", x)
    static member inline onLoadEnd (x:unit -> unit): IImageProp = unbox ("onLoadEnd", x)
    static member inline onLoadStart (x:unit -> unit): IImageProp = unbox ("onLoadStart", x)
    static member inline onPartialLoad (x:unit -> unit): IImageProp = unbox ("onPartialLoad", x)
    static member inline onProgress (x:obj -> unit): IImageProp = unbox ("onProgress", x)
    static member inline onProgress (x:(int * int) -> unit): IImageProp = unbox ("onProgress", x)
    static member inline progressiveRenderingEnabled (x:bool): IImageProp = unbox ("progressiveRenderingEnabled", x)
    static member inline resizeMethod (x:string): IImageProp = unbox ("resizeMethod", x)
    static member inline referrerPolicy (x:string): IImageProp = unbox ("referrerPolicy", x)
    static member inline testID (x:string): IImageProp = unbox ("testID", x)
    static member inline tintColor (x:string): IImageProp = unbox ("tintColor", x)
    static member inline width (x:int): IImageProp = unbox ("width", x)
    static member inline uriSource (x:string): IImageProp = unbox ("source", {|uri = x|})
    [<Emit("require($0)")>]
    static member inline localImage (_path:string) : obj = jsNative 
    static member inline defaultSource (x:string): IImageProp = unbox ("defaultSource", image.localImage x)
    static member inline source (x:string): IImageProp = unbox ("source", image.localImage x)
    static member inline src (x:string): IImageProp = unbox ("src", x)
    static member inline resizeMode (x:string): IImageProp = unbox ("resizeMode", x)

[<Erase>]
type imageBackground =
    inherit Prop<IImageBackgroundProp>
    static member inline defaultSource (x:string): IImageBackgroundProp = unbox ("defaultSource", image.localImage x)
    static member inline source (x:string): IImageBackgroundProp = unbox ("source", image.localImage x)
    static member inline resizeMode (x:string): IImageBackgroundProp = unbox ("resizeMode", x)
    static member inline imageStyle (x:seq<Feliz.IStyleAttribute>): IImageBackgroundProp = unbox("imageStyle", keyValueList CaseRules.LowerFirst x)

[<Erase>]
type keyboardAvoidingView =
    inherit Prop<IKeyboardAvoidingViewProp>
    
    static member inline behavior (x:string): IKeyboardAvoidingViewProp = unbox ("behavior", x)
    static member inline behavior (x:obj): IKeyboardAvoidingViewProp = unbox ("behavior", x)
    static member inline enabled (x:bool): IKeyboardAvoidingViewProp = unbox ("enabled", x)
    static member inline keyboardVerticalOffset (x:float): IKeyboardAvoidingViewProp = unbox ("keyboardVerticalOffset", x)
    static member inline keyboardVerticalOffset (x:int): IKeyboardAvoidingViewProp = unbox ("keyboardVerticalOffset", x)

[<Erase>]
type pressable =
    inherit Prop<IPressableProp>
    static member inline delayLongPress (x:float): IPressableProp = unbox ("delayLongPress", x)
    static member inline delayLongPress (x:int): IPressableProp = unbox ("delayLongPress", x)
    static member inline disabled (x:bool): IPressableProp = unbox ("disabled", x)
    static member inline hitSlop (x:Types.Rect): IPressableProp = unbox ("hitSlop", x)
    static member inline hitSlop (x:float): IPressableProp = unbox ("hitSlop", x)
    static member inline hitSlop (x:int): IPressableProp = unbox ("hitSlop", x)
    static member inline onLongPress (x:Types.PressEvent -> unit): IPressableProp = unbox ("onLongPress", x)
    static member inline onPress (x:Types.PressEvent -> unit): IPressableProp = unbox ("onPress", x)
    static member inline onPress (x:unit -> unit): IPressableProp = unbox ("onPress", x)
    static member inline onPressIn (x:Types.PressEvent -> unit): IPressableProp = unbox ("onPressIn", x)
    static member inline onPressOut (x:Types.PressEvent -> unit): IPressableProp = unbox ("onPressOut", x)
    static member inline pressRetentionOffset (x:Types.Rect): IPressableProp = unbox ("pressRetentionOffset", x)
    static member inline pressRetentionOffset (x:float): IPressableProp = unbox ("pressRetentionOffset", x)
    static member inline pressRetentionOffset (x:int): IPressableProp = unbox ("pressRetentionOffset", x)
    static member inline testOnlyPressed (x:bool): IPressableProp = unbox ("testOnly_pressed", x)
    static member inline unstablePressDelay (x:float): IPressableProp = unbox ("unstable_pressDelay", x)
    static member inline unstablePressDelay (x:int): IPressableProp = unbox ("unstable_pressDelay", x)
    

[<Erase>]
type safeAreaView =
    inherit Prop<ISafeAreaViewProp>
    static member inline emulateUnlessSupported (value:bool): ISafeAreaViewProp = unbox ("emulateUnlessSupported", value)

[<Erase>]
type scrollView =
    inherit Prop<IScrollViewProp>
    static member inline alwaysBounceHorizontal (x:bool): IScrollViewProp = unbox ("alwaysBounceHorizontal", x)
    static member inline alwaysBounceVertical (x:bool): IScrollViewProp = unbox ("alwaysBounceVertical", x)
    static member inline automaticallyAdjustContentInsets (x:bool): IScrollViewProp = unbox ("automaticallyAdjustContentInsets", x)
    static member inline automaticallyAdjustKeyboardInsets (x:bool): IScrollViewProp = unbox ("automaticallyAdjustKeyboardInsets", x)
    static member inline automaticallyAdjustsScrollIndicatorInsets (x:bool): IScrollViewProp = unbox ("automaticallyAdjustsScrollIndicatorInsets", x)
    static member inline bounces (x:bool): IScrollViewProp = unbox ("bounces", x)
    static member inline bouncesZoom (x:bool): IScrollViewProp = unbox ("bouncesZoom", x)
    static member inline contentOffset (x:Types.Point): IScrollViewProp = unbox ("contentOffset", x)
    static member inline contentOffset (x:obj): IScrollViewProp = unbox ("contentOffset", x)
    static member inline decelerationRate (x:string): IScrollViewProp = unbox ("decelerationRate", x)
    static member inline disableIntervalMomentum (x:bool): IScrollViewProp = unbox ("disableIntervalMomentum", x)
    static member inline disableScrollViewPanResponder (x:bool): IScrollViewProp = unbox ("disableScrollViewPanResponder", x)
    static member inline horizontal (value:bool): IScrollViewProp = unbox ("horizontal", value)
    static member inline invertStickyHeaders (x:bool): IScrollViewProp = unbox ("invertStickyHeaders", x)
    static member inline keyboardDismissMode (x:string): IScrollViewProp = unbox ("keyboardDismissMode", x)
    static member inline keyboardShouldPersistTaps (x:string): IScrollViewProp = unbox ("keyboardShouldPersistTaps", x)
    static member inline onScroll (x:obj -> unit): IScrollViewProp = unbox ("onScroll", x)
    static member inline onScrollBeginDrag (x:obj -> unit): IScrollViewProp = unbox ("onScrollBeginDrag", x)
    static member inline onScrollEndDrag (x:obj -> unit): IScrollViewProp = unbox ("onScrollEndDrag", x)
    static member inline onScrollToTop (x:obj -> unit): IScrollViewProp = unbox ("onScrollToTop", x)
    static member inline overScrollMode (x:string): IScrollViewProp = unbox ("overScrollMode", x)
    static member inline pagingEnabled (x:bool): IScrollViewProp = unbox ("pagingEnabled", x)
    static member inline persistentScrollbar (x:bool): IScrollViewProp = unbox ("persistentScrollbar", x)
    static member inline pinchGestureEnabled (x:bool): IScrollViewProp = unbox ("pinchGestureEnabled", x)
    static member inline removeClippedSubviews (x:bool): IScrollViewProp = unbox ("removeClippedSubviews", x)
    static member inline scrollEnabled (x:bool): IScrollViewProp = unbox ("scrollEnabled", x)
    static member inline showsHorizontalScrollIndicator (x:bool): IScrollViewProp = unbox ("showsHorizontalScrollIndicator", x)
    static member inline showsVerticalScrollIndicator (x:bool): IScrollViewProp = unbox ("showsVerticalScrollIndicator", x)
    static member inline snapToEnd (x:bool): IScrollViewProp = unbox ("snapToEnd", x)
    static member inline snapToInterval (x:float): IScrollViewProp = unbox ("snapToInterval", x)
    static member inline snapToInterval (x:int): IScrollViewProp = unbox ("snapToInterval", x)
    static member inline snapToOffsets (x:int []): IScrollViewProp = unbox ("snapToOffsets", x)
    static member inline snapToOffsets (x:float []): IScrollViewProp = unbox ("snapToOffsets", x)
    static member inline snapToStart (x:bool): IScrollViewProp = unbox ("snapToStart", x)
    static member inline stickyHeaderHiddenOnScroll (x:bool): IScrollViewProp = unbox ("stickyHeaderHiddenOnScroll", x)
    static member inline stickyHeaderIndices (x:float []): IScrollViewProp = unbox ("stickyHeaderIndices", x)
    static member inline stickyHeaderIndices (x:int []): IScrollViewProp = unbox ("stickyHeaderIndices", x)



type TrackColor = {``false``:string; ``true``:string}

[<Erase>]
type switch =
    inherit Prop<ISwitchProp>
    static member inline disabled (x:bool): ISwitchProp = unbox ("disabled", x)
    static member inline onChange (x:obj -> unit): ISwitchProp = unbox ("onChange", x)
    static member inline onValueChange (x:bool -> unit): ISwitchProp = unbox ("onValueChange", x)
    static member inline thumbColor (x:string) : ISwitchProp = unbox ("thumbColor", x)
    static member inline trackColor (x:TrackColor): ISwitchProp = unbox ("trackColor", x)
    static member inline value (x:bool): ISwitchProp = unbox ("value", x)
    static member inline value (x:string): ISwitchProp = unbox ("value", x)

[<Erase>]
type text =
    inherit Prop<ITextProp>
    static member inline accessibilityHint (x:string): ITextProp = unbox ("accessibilityHint", x)
    static member inline accessibilityLabel (x:string): ITextProp = unbox ("accessibilityLabel", x)
    static member inline accessible (x:bool): ITextProp = unbox ("accessible", x)
    static member inline adjustsFontSizeToFit (x:bool): ITextProp = unbox ("adjustsFontSizeToFit", x)
    static member inline allowFontScaling (x:bool): ITextProp = unbox ("allowFontScaling", x)
    static member inline ellipsizeMode (x:string): ITextProp = unbox ("ellipsizeMode", x)
    static member inline maxFontSizeMultiplier (x:int): ITextProp = unbox ("maxFontSizeMultiplier", x)
    static member inline maxFontSizeMultiplier (x:float): ITextProp = unbox ("maxFontSizeMultiplier", x)
    static member inline minFontSizeMultiplier (x:int): ITextProp = unbox ("minFontSizeMultiplier", x)
    static member inline minFontSizeMultiplier (x:float): ITextProp = unbox ("minFontSizeMultiplier", x)
    static member inline nativeId (x:string): ITextProp = unbox ("nativeID", x)
    static member inline numberOfLines (x:int): ITextProp = unbox ("numberOfLines", x)
    static member inline onLayout (x:Types.LayoutEvent -> unit): ITextProp = unbox ("onLayout", x)
    static member inline onLongPress (x:Types.PressEvent -> unit): ITextProp = unbox ("onLongPress", x)
    static member inline onMoveShouldSetResponder (x:Types.PressEvent -> unit): ITextProp = unbox("onMoveShouldSetResponder", x)
    static member inline onPress (x:Types.PressEvent -> unit): ITextProp = unbox ("onPress", x)
    static member inline onPressIn (x:Types.PressEvent -> unit): ITextProp = unbox ("onPressIn", x)
    static member inline onPressOut (x:Types.PressEvent -> unit): ITextProp = unbox ("onPressOut", x)
    static member inline onResponderGrant (x:Types.PressEvent -> unit): ITextProp = unbox ("onResponderGrant", x)
    static member inline onResponderGrant (x:obj -> unit): ITextProp = unbox ("onResponderGrant", x)
    static member inline onResponderMove (x:Types.PressEvent -> unit): ITextProp = unbox ("onResponderMove", x)
    static member inline selectable (x:bool): ITextProp = unbox ("selectable", x)
    static member inline testID (x:string): ITextProp = unbox ("testID", x)
    static member inline text (x:string): ITextProp = unbox ("children", unbox (x))
    static member inline text (x:int): ITextProp = unbox ("children", unbox(string x))
    static member inline userSelect (x:string): ITextProp = unbox ("userSelect", x)

type textInput =
    inherit Prop<ITextInputProp>
    static member inline autoCapitalize (x:string): ITextInputProp = unbox ("autoCapitalize", x)
    static member inline autoCorrect (x:bool): ITextInputProp = unbox ("autoCorrect", x)
    static member inline autoFocus (x:bool): ITextInputProp = unbox ("autoFocus", x)
    static member inline blurOnSubmit (x:bool): ITextInputProp = unbox ("blurOnSubmit", x)
    static member inline caretHidden (x:bool): ITextInputProp = unbox ("caretHidden", x)
    static member inline editable (x:bool): ITextInputProp = unbox ("editable", x)
    static member inline defaultValue (x:string): ITextInputProp = unbox ("defaultValue", x)
    static member inline keyboardType (x:string): ITextInputProp = unbox ("keyboardType", x)
    static member inline maxLength (x:int): ITextInputProp = unbox ("maxLength", x)
    static member inline multiline (x:bool): ITextInputProp = unbox ("multiline", x)
    static member inline onChange (x:obj -> unit): ITextInputProp = unbox ("onChange", x)
    static member inline onChangeText (x:string -> unit): ITextInputProp = unbox ("onChangeText", x)
    static member inline onPressIn (x:Types.PressEvent -> unit): ITextInputProp = unbox ("onPressIn", x)
    static member inline onPressOut (x:Types.PressEvent -> unit): ITextInputProp = unbox ("onPressOut", x)
    static member inline onSubmitEditing (x:obj -> unit): ITextInputProp = unbox ("onSubmitEditing", x)
    static member inline placeholder (x:string): ITextInputProp = unbox ("placeholder", x)
    static member inline placeholderTextColor (x:string): ITextInputProp = unbox ("placeholderTextColor", x)
    static member inline returnKeyType (x:string): ITextInputProp = unbox ("returnKeyType", x)
    static member inline secureTextEntry (x:bool): ITextInputProp = unbox ("secureTextEntry", x)
    static member inline textAlign (x:string): ITextInputProp = unbox ("textAlign", x)
    static member inline value (x:string): ITextInputProp = unbox ("value", x)

[<Erase>]
type touchableHighligh =
    inherit Prop<ITouchableHighlightProp>
    static member inline activeOpacity (x:float): ITouchableHighlightProp = unbox ("activeOpacity", x)
    static member inline disabled (x:bool): ITouchableHighlightProp = unbox ("disabled", x)
    static member inline onLongPress (x:Types.PressEvent -> unit): ITouchableHighlightProp = unbox ("onLongPress", x)
    static member inline onPress (x:Types.PressEvent -> unit): ITouchableHighlightProp = unbox ("onPress", x)
    static member inline onPress (x:unit -> unit): ITouchableHighlightProp = unbox ("onPress", x)
    static member inline nativeId (x:string): ITouchableHighlightProp = unbox ("nativeID", x)
    static member inline underlayColor (x:string): ITouchableHighlightProp = unbox ("underlayColor", x)
    static member inline children (x:'a): ITouchableHighlightProp = unbox ("children", x)

[<Erase>]
type touchableOpacity =
    inherit Prop<ITouchableOpacityProp>
    static member inline activeOpacity (x:float): ITouchableOpacityProp = unbox ("activeOpacity", x)
    static member inline disabled (x:bool): ITouchableOpacityProp = unbox ("disabled", x)
    static member inline onLongPress (x:Types.PressEvent -> unit): ITouchableOpacityProp = unbox ("onLongPress", x)
    static member inline onPress (x:Types.PressEvent -> unit): ITouchableOpacityProp = unbox ("onPress", x)
    static member inline onPress (x:unit -> unit): ITouchableOpacityProp = unbox ("onPress", x)
    static member inline nativeId (x:string): ITouchableOpacityProp = unbox ("nativeID", x)
    static member inline children (x:'a): ITouchableOpacityProp = unbox ("children", x)

[<Erase>]
type view =
    inherit Prop<IViewProp>
    static member inline accessibilityElementsHidden (x:bool): IViewProp = unbox ("accessibilityElementsHidden", x)
    static member inline accessibilityHint (x:string): IViewProp = unbox ("accessibilityHint", x)
    static member inline accessibilityLanguage (x:string): IViewProp = unbox ("accessibilityLanguage", x)
    static member inline accessibilityIgnoresInvertColors (x:bool): IViewProp = unbox ("accessibilityIgnoresInvertColors", x)
    static member inline accessibilityLabel (x:string): IViewProp = unbox ("accessibilityLabel", x)
    static member inline accessible (x:bool): IViewProp = unbox ("accessible", x)
    static member inline ariaBusy (x:bool): IViewProp = unbox ("aria-busy", x)
    static member inline ariaChecked (x:bool): IViewProp = unbox ("aria-checked", x)
    static member inline ariaDisabled (x:bool): IViewProp = unbox ("aria-disabled", x)
    static member inline ariaLabel (x:string): IViewProp = unbox ("aria-label", x)
    static member inline ariaLabelledBy (x:string): IViewProp = unbox ("aria-labelledby", x)
    static member inline nativeID (x:string): IViewProp = unbox ("nativeID", x)
    static member inline needsOffscreenAlphaCompositing (x:string): IViewProp = unbox ("needsOffscreenAlphaCompositing", x)
    static member inline onAccessibilityAction (x:obj -> unit): IViewProp = unbox ("onAccessibilityAction", x)
    static member inline onAccessibilityTap (x:obj -> unit): IViewProp = unbox ("onAccessibilityTap", x)
    static member inline onLayout (x:obj -> unit): IViewProp = unbox ("onLayout", x)
    static member inline onLayout (x:Types.LayoutEvent -> unit): IViewProp = unbox ("onLayout", x)
    static member inline onMoveShouldSetResponder (x:Types.PressEvent -> bool): IViewProp = unbox ("onMoveShouldSetResponder", x)
    static member inline onMoveShouldSetResponder (x:obj -> bool): IViewProp = unbox ("onMoveShouldSetResponder", x)
    static member inline onMoveShouldSetResponderCapture (x:Types.PressEvent -> bool): IViewProp = unbox ("onMoveShouldSetResponderCapture", x)
    static member inline onMoveShouldSetResponderCapture (x:obj -> bool): IViewProp = unbox ("onMoveShouldSetResponderCapture", x)
    static member inline onResponderGrant (x:Types.PressEvent -> unit): IViewProp = unbox ("onResponderGrant", x)
    static member inline onResponderGrant (x:obj -> unit): IViewProp = unbox ("onResponderGrant", x)
    static member inline onResponderMove (x:Types.PressEvent -> unit): IViewProp = unbox ("onResponderMove", x)
    static member inline onResponderReject (x:Types.PressEvent -> unit): IViewProp = unbox ("onResponderReject", x)
    static member inline onResponderRelease (x:Types.PressEvent -> unit): IViewProp = unbox ("onResponderRelease", x)
    static member inline onResponderTerminate (x:Types.PressEvent -> unit): IViewProp = unbox ("onResponderTerminate", x)
    static member inline onResponderTerminationRequest (x:Types.PressEvent -> unit): IViewProp = unbox ("onResponderTerminationRequest", x)
    static member inline onStartShouldSetResponder (x:Types.PressEvent -> bool): IViewProp = unbox ("onStartShouldSetResponder", x)
    static member inline onStartShouldSetResponderCapture (x:Types.PressEvent -> bool): IViewProp = unbox ("onStartShouldSetResponderCapture", x)
    static member inline removeClippedSubviews (x:bool): IViewProp = unbox ("removeClippedSubviews", x)
    static member inline testID (x:string): IViewProp = unbox ("testID", x)
    static member inline source (value : {|uri : string|}): IViewProp = unbox ("source", value)
