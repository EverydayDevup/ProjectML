# ProjectMR
## Summary
- https://everyday-devup.tistory.com/category/ProjectMR

## Tech
> 1. Unity 시작 씬은 빈 씬으로 처리 
>> 첫 씬이 무거우면 게임 실행 시 검은 화면을 오래 볼 수 있음
> 2. 씬 로딩 간의 빈 씬 추가 
>> 씬 로드/언로드 사이에 리소스가 모두 올라갈 수 있음.\
>> 가벼운 로딩 씬을 추가함으로써 불필요한 메모리 증가를 막음
> 3. 옵저버 패턴 추가
>> 스크립트 간의 의존성을 줄이기 위해 이벤트 시스템을 추가.\
>> Gamepad를 움직일 경우, EventMessenger에서 GamepadOnMove 를 구독하는 객체에게 메시지를 보냄
> 4. 싱글톤 추가
>> MonoSingleton과 C# Singleton으로 나누어 Generic으로 구현
> 5. 게임 패드 개선
>> Unity에서 제공하는 On-Screen Stick을 사용할 경우 핸들러를 움직일 수도 있고 \
>> PointDown 위치에서 핸드러를 움직일 수도 있지만, 핸들의 배경은 움직일 수 있는 방안이 없음
>> GamepadArea를 추가하여 PointerDown 위치로 방향패드가 움직이고 핸들도 움직일 수 있도록 추가\
![Gamepad](Gif/Day01.Gamepad.gif)
> 6. 노치 대응
>> 단말기의 노치 대응을 위해 SafeAreaHelper 패키지를 추가 
> https://assetstore.unity.com/packages/tools/gui/safe-area-helper-130488
> 7. Debug.Log를 대체할 수 있는 Logger 클래스 추가
>> EDD_DEBUG 전처리기를 사용해서 Conditional Attribute 사용 \
>> 릴리즈 버전에서 로그와 관련된 함수 부분이 포함되지 않도록 함.
> 8. 카메라 컬링
>> 프러스텀 컬링은 Unity에서 기본적으로 적용 : 카메라안에 들어온 오브젝트만 그림 \
>> 오클루전 컬링 : 가려지는 오브젝트는 그리지 않음. 공간을 어떻게 자를지에 대한 매직넘버를 테스트 해야함 \
>> 컬링 마스크는 컬링 후에 레이어를 체크하기 때문에 멀티 카메라 사용 시 다른 영역을 바라보도록 해야함 \
>> 탑 다운 뷰 형태의 게임은 스카이 박스가 불필요하다면 사용하지 않아야함
> 9. 어드레서블
>> Resouces 폴더를 사용할 경우 앱 시작 시 룩업테이블을 만들기 위한 시간이 리소스 량에 비례하여 증가함 \
>> 에셋 번들을 사용할 경우 해당 이슈를 없앨 수 있고, 앱의 용량을 줄일 수 있음 \
>> 어드레서블은 어셋 번들을 사용하기 용이하도록 Unity에서 제공하는 유틸리티에 가까움 \
>> 어드레서블을 사용할 경우 어셋 번들을 만들 때 의존성을 확인하기 용이함 \
>> 어셋 번들을 만들 때 주의해야하는 것은 중복된 에셋이 각각 다른 에셋에 묶이는 것 \
>> ex) A 프리팹에 C가 필요하고, B 프리팹에 C가 필요한 경우, A, B를 에셋 번들로 묶으면 C가 중복됨 \
>> 공용 에셋은 별도의 에셋 번들로 관리하고, 가급적 에셋번들을 명시적으로 알 수 있도록 참조하는 에셋은 하나의 폴더로 묶어서 관리

## Build
> 빌드 폴더 위치
> Builds/플랫폼/ProjectML
>> <a href="https://github.com/EverydayDevup/ProjectMR/tree/main/Builds/Windows" download>Windows 실행파일 경로</a>