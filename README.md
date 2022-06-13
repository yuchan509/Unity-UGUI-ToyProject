# Unity - UGUI(Unity Graphic User Interface)
##  Toy Projects
  - 01. Drag and Drop with Duplication
  - 02. Iventory & Slot
  - 03. Swipe
  - 04. FileBrowser - Image Update / Save


## Unity UI Manual


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
