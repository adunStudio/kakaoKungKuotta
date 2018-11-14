# kakaoKungKuotta
재미있을 거 같아서 만드는 카카오 쿵쿵따.

단톡방에서 누가 말할 때마다 쿵쿵따를 자동으로 시전한다.
- 박병근: 심심하다.
- 나: 다람쥐 쿵쿵따!
- 양태윤: 저거 뭐임?
- 나: 임꺽정 쿵쿵따!

---

## 사용법:
1. 프로그램 실행
2. 실행중인 카카오톡 단톡방을 프로그램에서 선택
3. 출근

## 개발 예상 순서:
[009] 이전에 예상한 방식: 단톡방을 정해진 위치에 두고 이미지 캡처하여 OCR로 문자 판독 하려했으나 단톡방 프로세스에서 텍스트를 복사해오는 방식을 선택.

1. C#으로 한다. 익숙한 NodeJS로 빠르게 개발하고 싶지만 공부를 위해 C#
2. 실행중인 프로그램들의 리스트를 보여준다. (+GUI)
3. 단톡방의 텍스트를 복사해온다. (주기는? 변화를 어떻게 감지? 타이머?)
4. 복사한 텍스트에서 내가 쓴글, 남이 쓴글을 구별하고 한글이 아닌 특수문자등은 제외처리
5. 뭐 어찌어찌 하여 마지막 문자를 기준으로 끝말잇기(쿵쿵따) 글을 찾는다. (관련 API 검색)
6. 정해진 사이즈 이므로 이미 알고있는 input창으로 커서를 옮기고 키보드를 조작하여 글을 쓰고 보낸다.

## 개발로 얻는 이점:
내가 재밌다.

## 개발 기록:
#### 01. [005] 프로젝트 생성, 화면 전체 스크린샷
- C# 프로젝트 생성
- KKK 네임스페이스 (KakaoKungKuotta)
- 스크린샷을 위한 ScreenCapture 클래스

#### 02. [007] 캡처영역 생성

- 폼작업(투명, 빨간색 테두리, 드래그 이동, 항상 위)

#### 03. [008] 캡처영역 + 스크린샷

- 캡처영역 내에서 자동 스크린샷(현재 1초)
- 스크린샷 이미지 포맷 jpeg에서 png로 수정

#### 04. [009] 현재 실행중인 프로그램 목록 출력

- window 관련 함수 WindowImport 클래스로 이동
- 현재 실행중인 프로그램 목록 콘솔에 출력

#### 05. [011] winapi 함수 Win32 클래스로 이동 및 정리

- enum, flag 추가, summary 정리

#### 06. [012] 원하는 프로그램 핸들 가져오기

- Win32.FindWindow[013]

#### 07. [013] 가져온 핸들로부터 프로그램 위치, 크기, 상태 정보

- Win32.GetWindowPlacement
- 위치, 크기 정보에 기반하여 프로그램 위치에 빨간색 테두리 생성

#### 08. [014], [015] 키보드 핫키 완료, 후킹 도전중

- HotKeyHelper 클래스
- 후킹은 좀 더 공부후에 시도.

#### 09. [016], [017] 외부 스크립트 실행

- using Microsoft.CodeAnalysis.Scripting;
- using Microsoft.CodeAnalysis.CSharp.Scripting;

#### 10. [018], [019] 키보드, 간편한 핫키

```c#
Keyboard.HotKey(Keys.A,                () => { Console.WriteLine("a"); });
Keyboard.HotKey(Keys.A | Keys.Control, () => { Console.WriteLine("a + ctrl"); });
Keyboard.HotKey(Keys.A | Keys.Alt,     () => { Console.WriteLine("a + alt"); });
```

- PInvoke.* 라이브러리 적용

#### 11. [020] Camera, Command

```
// 캡처, 저장
Keyboard.HotKey(Keys.A | Keys.Control, () => { Console.WriteLine("ctrl + a");
    Camera.Capture().Save();
    // save() -> 현재 날짜 파일명으로 저장
});

// 콘솔창 토글
Keyboard.HotKey(Keys.A | Keys.Alt,     () => { Console.WriteLine("alt + a");
    Command.visible = !Command.visible;
});
```

- 캡쳐 기능
- 콘솔창 on/off