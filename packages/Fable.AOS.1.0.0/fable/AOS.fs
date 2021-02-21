module Fable.AOS

open Fable.Core.JsInterop
open Fable.React.Props
open Microsoft.FSharp.Reflection


[<RequireQualifiedAccess>]
type AnchorPlacementOpitions =
    | [<CompiledName("top-bottom")>] TopBottom
    | [<CompiledName("top-center")>] TopCenter
    | [<CompiledName("top-top")>] TopTop
    | [<CompiledName("center-bottom")>] CenterBottom
    | [<CompiledName("center-center")>] CenterCenter
    | [<CompiledName("center-tops")>] CenterTops
    | [<CompiledName("bottom-bottom")>] BottomBottom
    | [<CompiledName("bottom-center")>] BottomCenter
    | [<CompiledName("bottom-top")>] BottomTop

[<RequireQualifiedAccess>]
type EasingOptions =
    | [<CompiledName("linear")>] Linear
    | [<CompiledName("ease")>] Ease
    | [<CompiledName("ease-in")>] EaseIn
    | [<CompiledName("ease-out")>] EaseOut
    | [<CompiledName("ease-in-out")>] EaseInOut
    | [<CompiledName("ease-in-back")>] EaseInBack
    | [<CompiledName("ease-out-back")>] EaseOutBack
    | [<CompiledName("ease-in-out-back")>] EaseInOutBack
    | [<CompiledName("ease-in-sine")>] EaseInSine
    | [<CompiledName("ease-out-sine")>] EaseOutSine
    | [<CompiledName("ease-in-out-sine")>] EaseInOutSine
    | [<CompiledName("ease-in-quad")>] EaseInQuad
    | [<CompiledName("ease-out-quad")>] EaseOutQuad
    | [<CompiledName("ease-in-out-quad")>] EaseInOutQuad
    | [<CompiledName("ease-in-cubic")>] EaseInCubic
    | [<CompiledName("ease-out-cubic")>] EaseOutCubic
    | [<CompiledName("ease-in-out-cubic")>] EaseInOutCubic
    | [<CompiledName("ease-in-quart")>] EaseInQuart
    | [<CompiledName("ease-out-quart")>] EaseOutQuart
    | [<CompiledName("ease-in-out-quart")>] EaseInOutQuart

[<RequireQualifiedAccess>]
type AnimationOptions =
    | [<CompiledName("fade")>] Fade
    | [<CompiledName("fade-up")>] FadeUp
    | [<CompiledName("fade-down")>] FadeDown
    | [<CompiledName("fade-left")>] FadeLeft
    | [<CompiledName("fade-right")>] FadeRight
    | [<CompiledName("fade-up-right")>] FadeUpRight
    | [<CompiledName("fade-up-left")>] FadeUpLeft
    | [<CompiledName("fade-down-right")>] FadeDownRight
    | [<CompiledName("fade-down-left")>] FadeDownLeft
    | [<CompiledName("flip-up")>] FlipUp
    | [<CompiledName("flip-down")>] FlipDown
    | [<CompiledName("flip-left")>] FlipLeft
    | [<CompiledName("flip-right")>] FlipRight
    | [<CompiledName("slide-up")>] SlideUp
    | [<CompiledName("slide-down")>] SlideDown
    | [<CompiledName("slide-left")>] SlideLeft
    | [<CompiledName("slide-right")>] SlideRight
    | [<CompiledName("zoom-in")>] ZoomIn
    | [<CompiledName("zoom-in-up")>] ZoomInUp
    | [<CompiledName("zoom-in-down")>] ZoomInDown
    | [<CompiledName("zoom-in-left")>] ZoomInLeft
    | [<CompiledName("zoom-in-right")>] ZoomInRight
    | [<CompiledName("zoom-out")>] ZoomOut
    | [<CompiledName("zoom-out-up")>] ZoomOutUp
    | [<CompiledName("zoom-out-down")>] ZoomOutDown
    | [<CompiledName("zoom-out-left")>] ZoomOutLeft
    | [<CompiledName("zoom-out-right")>] ZoomOutRight

type AOSProps =
    | Animation of AnimationOptions
    | Offset of float
    | Delay of float
    | Duration of float
    | Easing of EasingOptions
    | Mirror of bool
    | Once of bool
    | Anchor of string
    | AnchorPlacement of AnchorPlacementOpitions


let private getCaseName (case : 'T) =
#if FABLE_COMPILER
    Fable.Core.Reflection.getCaseName case
#else
    // Get UnionCaseInfo value from the F# reflection tools
    let (caseInfo, _args) = FSharpValue.GetUnionFields(case, typeof<'T>)
    caseInfo.GetCustomAttributes()
    |> Seq.tryPick (function
                    | :? CompiledNameAttribute as att -> Some att.CompiledName
                    | _ -> None)
    |> Option.defaultWith (fun () -> caseInfo.Name)
#endif


let aos props =
    List.map ((function
        | Animation x           -> HTMLAttr.Custom ("data-aos", getCaseName x)
        | Offset x              -> HTMLAttr.Custom ("data-aos-offset", x)
        | Delay x               -> HTMLAttr.Custom ("data-aos-delay", x)
        | Duration x            -> HTMLAttr.Custom ("data-aos-duration", x)
        | Easing x              -> HTMLAttr.Custom ("data-aos-easing", getCaseName x)
        | Mirror x              -> HTMLAttr.Custom ("data-aos-mirror", x)
        | Once x                -> HTMLAttr.Custom ("data-aos-once", x)
        | Anchor x              -> HTMLAttr.Custom ("data-aos-anchor", x)
        | AnchorPlacement x     -> HTMLAttr.Custom ("data-aos-anchor-placement", getCaseName x))
        >> unbox<IHTMLProp>) props


let init<'T> (config: 'T): unit =
  importAll "aos/dist/aos.css"
  let AOS: obj = importDefault "aos"
  AOS?init(config)
    