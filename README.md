## Unity UI

# UGUI(Unity Graphic User Interface)
- Unity에서 제공하는 Unity built - in UI (4.6 이후)
- 추가 구매의 필요성이 없으며, 직관적인 UI 구성 요소 간의 Depth 조절이 가능.
- Canvas 단위로 Draqw cell이 관리되며, Sprite Atlas 관리(Folder 단위로도 가능)
- Particle Rendering 문제가 존재.
- Tweening을 기본으로 지원하지 않음.
- 동적 할당이 쉽고 편리하며, 효율적 측면에서 NGUL(Next - Gen User Interface)보다 좋음.
- UI 확장 Asset을 쉽게 구할 수 있으며, Unity에서도 지속적으로 관리.


## EventSystem Gamobject
- EventSystem은 Graphic Raycaster를 이용해 충돌된 오브젝트의 이벤트를 검출하는 수단, 상호 작용이 가능한 UI의 이벤트 처리를 담당.
- 하나의 Seane에 하나만 존재함.


## Cavas GameObject
- Canvas는 모든 UI 요소(gameobject, component)를 배치하는 영역.
- `RectTransform`, `Canvas`, `CanvasScaler`, `GraphicRaycater`.


### RectTransform Component
- RectTransform은 Transform을 상속 받아 만든 UI 전용의 Transform
    - Transform component와 마찬가지로 position(위치), rotation(회전), scale(크기)를 가지고 있으며, 사각형의 치수를 결정하는 width(폭), height(높이)가 존재.

    - Pivot과 Anchors를 설정할 수 있어, 더욱 편하게 UI 관리 및 배치가 가능.
        - [Pivot] : 
            - RectTransform 컴포넌트를 가지고 있는 오브젝트 본인의 중심점. 중심점 위치에 따라 위치를 설정했을 때 배치되는 지점으로, 회전할 때 돌아가는 축, 크기 변화 등이 다르게 설정.

        - [Anchors] :
            - 부모/자식 관계일 때 자식 오브젝트가 부모의 특정 변이나 꼭지점을 기준으로 고정되게 하는 기능.(단, 두 오브젝트 모두 RectTransform이 존재해야함.)
            - 부모 오브젝트의 크기가 변경될 때 고정된 축의 여백은 그대로 유지.
            - Anchor에 제공되는 Anchor Presets을 이용하면,  Anchor 설정이 굉장히 간편.
            - mouse, Alt + Click, shift + Click, Alt + shift + Click

    - RectTransform을 사용하는 경우 Resizing은 width, height를 통해서만 하고, scale을 수정하지 아니함.
    

### Canvas compopnent
- Canvas component는 UI가 배치되고, 화면에 랜더링되는 추상 공간을 나타냄.
    - [Render mode] : UI가 화면에 렌더링 되는 방버.
        - `Screen Space - Overlay` : 가장 흔히 사용되는 UI 배치 방법으로 UI가 월드의 오브젝트보다 앞에 그려짐.
        - `Screen Space - Camera` : UI가 그려지는 위치는 Render Camera와의 거리(Plane Distance)로 설정.(고정된 거리를 유지하며 canvas가 camera를 따라다님.)
        - `World Space` : 월드에 배치된 Object와 동일하게 카메라의 시야 내에서만 화면에 보임.

    - [Pixel Perfect] : Anti - Aliasing 없이 UI를 정밀하게 렌더링 할 때 사용.

    - [Render Camera] : UI를 렌더링 하는데 사용하는 camera.

    - [Plane Distance] : camera와 UI 사이의 거리.

    - [Event Camera] : UI 이벤트를 처리하는데 사용되는 카메라.


### Canvas Scaler
- Canvas에 배치된 모든 UI 요소의 크기, 픽셀 밀도를 제어하는데 이용.
    - [UI Scale Mode - Constant Pixel Size] :
        - 화면 크기에 관계 없이 UI 위치나 크기가 Pixel에 대한 단순한 배율로 지정.
        - Scale Factor : Canvas 아래에 배치되는 모든 UI 요소의 화면 내 비율.
        - Reference Pixel Per Unit : Image Component를 가지는 UI의 경우, Sprite에 "Pixel Per Unit"이 설정이 있으면, Sprite의 1 Pixel = UI의 1 Unit


    - [UI Scale Mode - Scale With Screen Size] : 화면의 크기에 따라 UI의 위치나 크기가 함께 수정.
        - Reference Resolution : UI의 적정 해상도 크기를 설정. (모바일 게임 제작시, 기기별 화면 비율이 제각각이므로 Scale With Screen Size 모드를 종종 이용.)
        - Screen Match Mode : 현재 해상도의 종횡비가 Reference Resolution과 다를 때, Canvas 영역 크기를 설정할 때 사용되는 모드.
            - Match Width Or Heigth : Canvas 영역의 Width or Height를 기준으로 Canvas 영역을 설정.(대개, 0.5 설정)
            - Expand : Canvas 크기가 Reference Resolution보다 작아지지 않도록, Canvas 영역의 수평 또는 수직으로 확장.
            - Shrink : Canvas 크기가 Reference Resolution보다 작아지지 않도록, Canvas 영역의 수평 또는 수직으로 자름.


     - [UI Scale Mode - Constant Physical Size] : 화면의 크기에 상관없이 UI 요소가 동일한 물리적인 크기로 유지.


### Graphic Raycater
- Canvas 오브젝트 하위에 배치된 UI 요소들에 광선을 쏴서 충돌처리를 함.



### TextMeshPro - Text
- 화면에 text를 표현하는 UI Component.
- Text rendering pipline으로 SDF(Singled Distance Field)를 이용.(Point 크기나 해상도 변화에도 Text를 깨끗하게 렌더링 함.)
- 최적화가 잘되어 있으며, 커스터마이징 및 다양한 텍스트 효과를 가짐.
    - `Button`, `InputField`, `DropDown`과 같이 화면에 Text를 표현하는 모든 UI는 `TextMeshPro - Text` Component를 가짐.
    - `Text` Component는 Lagacy로 곧 사용이 중지될 예정이므로, Text를 포함하는 다른 UI도 `TextMeshPro`가 붙은 것으로 대체하여 사용.
    - **참고** : 현재 `Toggle` 오브젝트만 `TextMeshPro - Text`가 아닌 `Text` 이용.

    - TextMeshPro - Text Componet
        - Text Input Box : 화면에 출력될 Text를 타이핑하는 공간, 여러 줄 입력시 Enter로 줄 바꿈 가능. 서식 있는 Text(Rich Text)
        - Text Style : Text Size, Color 등이 적용된 Text Style.

        - `[Main Settings]`
            - Font Asset : Text Rendering에 사용되는 Font Asset.
            - Material Preset : Text에 적용되는 Material(Shader : 색의 농담, 색조, 명암 효과를 주는 주체)
            - Font Style : Text에 굵게, 기울기 등의 효과 적용.
            - Font Size : Text 크기.
            - Auto Size : RectTransform과 Text 길이를 고려하여 동적으로 Font 크기 변화.
            - Vertex Color : Font 색상.
            - Color Gradient : 색상 그라데이션 설정.
            - Spacing Options : 문자, 문장, 줄 간격 등 조절.
            - Alignment : Text 정렬.

        
        - `[Extra Settings]`
            - Margins : 외곽 영역 간격 조절.
            - Rich Text : 서식 있는 Text 사용 여부.
            - Raycast Target : 상호작용 여부.
            - Sprite Asset : 특정 Text 명령을 입력하면, Text 대신하여 Image 출력.
            - Style Sheet Asset : 여러 스타일을 미리 지정해서 등록해두고, 서식 있는 Text처럼 <style="TEST">[Text Content]</style>과 같이 사용이 가능.


```c#
using UnityEngine;
// TextMeshPro에서 제공하는 class를 이용.
using TMPro; 

public class TMPStudy : MonoBehaviour
{
    private TextMeshProUGUI textComponet;

    private void Awake()
    {
        textComponet = GetComponent<TextMeshProUGUI>();

        textComponet.text      = "This Script is TextMeshPro Component";
        textComponet.color     = Color.blue;
        textComponet.fontSize  = 36;
        textComponet.fontStyle = FontStyles.Bold | FontStyles.Italic;
    }
}


// Rich Text(서식 있는 Text) 지원 - HTML 유사. (Text Input에 적용.)

<b> Font Style : B </b>
<i> Font Style : I </i>
<u> Font Style : U </u>
<s> Font Style : S </s>
<sup> 위 첨자 </sup>
<sub> 아래 첨자 </sub>
<size = 36> Font Size = 36 </size>
<size = +36> Current Font Size 36 up </size>
<size = -36> Current ont Size 36 down </size>
<pos = 10> 왼쪽 기준으로 문자열 위치 10만큼 이동
<color = blue> Font 색상을 blue로 설정 </color>
<#000000> Font 색상을 black으로 설정 </color>
...

```

- `TextMeshPro - Text` 는 기본적으로 영어(English) Font만을 지원하기에 한글 Font 등록이 필요.
    - Prpject에 사용할 Font File을 Project/Assets 부분에 포함.(시간이 다소 걸릴 수 있음.)
    - Font Asset 생성.(Window -> TextMeshPro -> Font Asset Creator)
        - `[Font Asset Creator - Font Settings]`
            - Source Font File : Font Asset으로 사용할 Font File 등록.
            - Sampling Point Size : Atlas에 등록되는 Text 크기(Auto sizing / Custom size)
            - Padding : Atlas에 등록되는 Text 사이의 거리.
            - Packing Method : Atlas를 빠르게 생성할 것인지 최적할 것인지를 설정(Fast / Optimum)
            - Atlas Resolution : 우리가 등록하는 Text를 저장하는 Atlas 크기.
             (크기에 따라 용량이 설정되며, 크기가 너무 작을 경우 Text의 해상도가 낮게 설정됨.)
            - Character Set : Atlas에 등록되는 Text 설정 방법.
             (Custom Characters : Custom Character List에 입력한 Text 등록.)

            - Save : 설정한 Font 저장.

       - `[Render Mode]`
            - RASTER : Hinting, Anti-Aliasing 모두 적용되지 않은 Rendering.
            - SMOOTH : Anti-Aliasing이 적용된 Rendering.
            (동적으로 사용할 때 Rendering이 가장 빠른 모드)

            - RASTER_HINTED : Hinting이 적용된 Rendering.
            (가장 선명한 글꼴 Rendering 옵션으로 Pixel 표현에 유리.)

            - SMOOTH_HINTED : Hinting, Anti-Aliasing이 적용된 Rendering.
            (문자가 커지거나 작아져도 라인이 부드럽게 연결.)

            - SDF(Signed Distance Field) : Bitmap Font의 겨우 스케일 적용 시 흐려지거나 Anti-Aliasing 문제가 발생하는데, 이를 해결하기 위해 거리에 따라 선명도를 계산하여 보여주는 방식. Shader를 활용하여 Outline과 같은 추가 효과 구현이 가능하며, 작은 글자는 잘 안보이고 Bitmap처럼 전체 문자를 전부 바꾸면 용량이 커진다는 단점이 있기에 필요한 문장만을 추가해 나가는 것울 추천.

            - **참고**
                - Anti-Aliasing : 계단 현상을 개선하는 기술.
                - Hinting : 글자 크기가 바뀌더라도 Hint를 참고해 모양을 변화시켜 Text를 뚜렷하게 보이도록 하는 기술.
                
